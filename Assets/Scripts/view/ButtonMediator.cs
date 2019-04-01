using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;
namespace Ordina.View {
    public class ButtonMediator : Mediator {
        public new const string NAME = "ButtonMediator-";

        public ButtonMediator(ButtonView viewComponent, string name) : base(name, viewComponent) {
        }

        protected void InitListeners() {
            if (GetViewComponent() != null) {
                GetViewComponent().InitEvents();
                GetViewComponent().OnClickEvent.AddListener(OnButtonClicked);
            } else {
                Debug.Log("ButtonMediator not ready: " + this);
            }
        }

        protected void OnButtonClicked() {
            //Debug.Log("heard click from: " + GetViewComponent().Id);
            SendNotification(Notifications.SEND_UI_ACTION, GetViewComponent().Config);
        }

        public override void OnRegister() {
            InitListeners();

        }

        public ButtonView GetViewComponent() {
            return ViewComponent as ButtonView;
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
                            switch (GetViewComponent().Config.actions) {
                                case UIActions.TAKE_PHOTO:
                                case UIActions.LOAD_PHOTO:
                                    GetViewComponent().Hide();
                                    break;

                                case UIActions.RESET_PHOTO:
                                case UIActions.UPLOAD_PHOTO:
                                    GetViewComponent().Show();
                                    break;


                                default:
                                    break;
                            }
                            break;

                        case ApplicationStates.SHOWING_RESULTS:
                            break;

                        case ApplicationStates.USING_CAMERA:
                            switch (GetViewComponent().Config.actions) {
                                case UIActions.TAKE_PHOTO:
                                case UIActions.LOAD_PHOTO:
                                    GetViewComponent().Show();
                                    break;

                                case UIActions.RESET_PHOTO:
                                case UIActions.UPLOAD_PHOTO:
                                    GetViewComponent().Hide();
                                    break;


                                default:
                                    break;
                            }

                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
