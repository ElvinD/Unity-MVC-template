using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine;
using Ordina.Model;

namespace Ordina.View {
    public class PhoneCamMediator : Mediator {
        public new const string NAME = "PhoneCamMediator";

        public PhoneCamMediator(string name, PhoneCamView viewComponent) : base(name, viewComponent) {
        }

        protected void InitListeners() {
            if (GetViewComponent() != null) {
                GetViewComponent().InitEvents();
            } else {
                Debug.Log("PhoneCamMediator not ready: " + this);
            }
        }

        public void TakePicture() {
            GetViewComponent().TakePicture(OnPictureTaken, GetApplicationMediator().GetViewComponent());
        }

        /*
         *  Currently used for testing, but it could be used for loading a previously taken picture
         *  In that case replace the hardcoded url with something you saved in the playerprefs        
         */
        public void LoadPicture() {
            string url = Application.persistentDataPath + "/" + "test.jpg";
            var bytes = FileStorageService.ReadFile(url);
            if (bytes != null) {
                OnPictureTaken(bytes);
            } else Debug.LogWarning("Picture not found: " + url);
        }

        /*
         * Mediatores ARE allowed to perform actions on the model, but better practice would be to use a command.
         * Currently selecting a photo doesnt trigger any notifications, so it's okayish - but may change in future.       
         */
        private void OnPictureTaken(byte[] bytes) {
            FileVO file = GetFileProxy().StoreFileReference(bytes);
            GetUserDataProxy().SelectPhoto(file);
            GetApplicationStateProxy().SetState(ApplicationStates.REVIEWING_PHOTO_PREVIEW);
        }

        public override string[] ListNotificationInterests() {
            return new string[] { Notifications.SEND_STATE_CHANGE };
        }

        /*
         *  The phone mediator responds to state changes
         */
        public override void HandleNotification(INotification notification) {
            switch (notification.Name) {
                case Notifications.SEND_STATE_CHANGE:
                    ApplicationStates state = (ApplicationStates)notification.Body;
                    switch (state) {
                        case ApplicationStates.REVIEWING_PHOTO_PREVIEW:
                            GetViewComponent().DeActivateCamera();
                            FileVO file = GetUserDataProxy().GetData().SelectedPhoto;
                            GetViewComponent().ShowPreview(file.bytes);
                            break;

                        case ApplicationStates.SHOWING_RESULTS:
                            break;

                        case ApplicationStates.USING_CAMERA:
                            GetViewComponent().HidePreview();
                            GetViewComponent().ActivateCamera();
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        public override void OnRegister() {
            InitListeners();
        }

        public PhoneCamView GetViewComponent() {
            return ViewComponent as PhoneCamView;
        }

        private FileProxy GetFileProxy() {
            return (FileProxy)Facade.RetrieveProxy(FileProxy.NAME);
        }

        private ApplicationStateProxy GetApplicationStateProxy() {
            return Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
        }

        private ApplicationMediator GetApplicationMediator() {
            return Facade.RetrieveMediator(ApplicationMediator.NAME) as ApplicationMediator;
        }

        private UserDataProxy GetUserDataProxy() {
            return (UserDataProxy)Facade.RetrieveProxy(UserDataProxy.NAME);
        }
    }
}
