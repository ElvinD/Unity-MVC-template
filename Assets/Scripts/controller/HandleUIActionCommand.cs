using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using Ordina.View;
using Ordina.Model;
namespace Ordina.Controller {
    internal class HandleUIActionCommand : SimpleCommand {
        public override void Execute(INotification notification) {
            ApplicationStateProxy stateProxy = Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
            switch (notification.Name) {
                case Notifications.SEND_UI_ACTION:
                    ViewComponentConfig config = (notification.Body as ViewComponentConfig);
                    switch (config.actions) {
                        case ApplicationActions.TAKE_PHOTO:
                            Debug.Log("Take photo action heard");
                            break;

                        case ApplicationActions.UPLOAD_PHOTO:
                            Debug.Log("upload  photo action heard");
                            break;

                        case ApplicationActions.RESET_PHOTO:
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

