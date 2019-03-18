using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine;
using Ordina.Model;

namespace Ordina.View {
    public class PhoneCamMediator : Mediator {
        public new const string NAME = "PhoneCamMediator";

        public PhoneCamMediator(PhoneCamView viewComponent, string name) : base(name, viewComponent) {
        }

        protected void InitListeners() {
            if (GetViewComponent() != null) {
                GetViewComponent().InitEvents();
            } else {
                Debug.Log("PhoneCamMediator not ready: " + this);
            }
        }

        public void TakePicture() {
            GetViewComponent().TakePicture(OnPictureTaken);
        }

        public override string[] ListNotificationInterests() {
            return new string[] { Notifications.SEND_STATE_CHANGE };
        }

        public override void HandleNotification(INotification notification) {
            switch (notification.Name) {
                case Notifications.SEND_STATE_CHANGE:
                    ApplicationStates state = (ApplicationStates)notification.Body;
                    switch (state) {
                        case ApplicationStates.REVIEWING_PHOTO_PREVIEW:
                            GetViewComponent().DeActivateCamera();
                            FileVO file = GetUserDataProxy().GetData().SelectedPhoto;
                            GetViewComponent().ShowPreview(file.url);
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

        private UserDataProxy GetUserDataProxy() {
            return (UserDataProxy)Facade.RetrieveProxy(UserDataProxy.NAME);
        }

        private void OnPictureTaken(byte[] bytes) {
            FileVO file = GetFileProxy().StoreFileReference(bytes);
            GetUserDataProxy().SelectPhoto(file);
            GetApplicationStateProxy().SetState(ApplicationStates.REVIEWING_PHOTO_PREVIEW);
        }
    }
}
