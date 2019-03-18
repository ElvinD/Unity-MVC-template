using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using Ordina.View;
using Ordina.Model;
using PureMVC.Patterns.Mediator;

namespace Ordina.Controller {
    internal class HandleUIActionCommand : SimpleCommand {
        public override void Execute(INotification notification) {
            ApplicationStateProxy stateProxy = Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
            Mediator mediator;
            switch (notification.Name) {
                case Notifications.SEND_UI_ACTION:
                    ViewComponentConfig config = (notification.Body as ViewComponentConfig);
                    switch (config.actions) {
                        /*
                         * This space reserved for additional checks on actions. For example showing the user a modal first if confirmation is needed.
                         */
                        case UIActions.TAKE_PHOTO:
                            //SendNotification(Notifications.REQUEST_TAKE_PHOTO);
                            mediator = Facade.RetrieveMediator(PhoneCamMediator.NAME) as PhoneCamMediator;
                            (mediator as PhoneCamMediator).TakePicture();
                            //Debug.Log("Take photo action heard");
                            break;

                        case UIActions.UPLOAD_PHOTO:
                            Debug.Log("upload  photo action heard");
                            break;

                        case UIActions.RESET_PHOTO:
                            stateProxy.SetState(ApplicationStates.USING_CAMERA);
                            Debug.Log("reset  photo action heard");
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

