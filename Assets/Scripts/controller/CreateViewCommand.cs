using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using Ordina.View;
using Ordina.Model;

namespace Ordina.Controller {
    internal class CreateViewCommand : SimpleCommand {

        public override void Execute(INotification notification) {
            Main app = (Main)notification.Body;
            Facade.RegisterMediator(new ApplicationMediator(app));
            RegisterButtonMediators();
            RegisterPhoneCamMediator();
        }

        private void RegisterPhoneCamMediator() {
            var canvasContainer = GameObject.FindGameObjectWithTag(GameObjectTags.PHONECAM_RENDER);
            if (canvasContainer == null) {
                Debug.LogWarning("Phone camera view needs a render canvas, but none was found");
                return;
            }
            PhoneCamView phonecam = new PhoneCamView(canvasContainer);
            Facade.RegisterMediator(new PhoneCamMediator(phonecam, PhoneCamMediator.NAME));
        }

        private void RegisterButtonMediators() {
            var objects = GameObject.FindGameObjectsWithTag(GameObjectTags.BUTTON);
            var copyProxy = Facade.RetrieveProxy(CopyProxy.NAME) as CopyProxy;
            string buttonLabel;
            if (objects != null) {
                foreach (GameObject o in objects) {
                    ButtonView bv = new ButtonView(o);
                    switch (bv.Config?.actions) {
                        case ApplicationActions.TAKE_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.TAKE_PICTURE);
                            break;

                        case ApplicationActions.UPLOAD_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.UPLOAD_DATA);
                            break;

                        case ApplicationActions.RESET_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.CLEAR_PICTURE);
                            break;

                        default:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.COPY_NOT_FOUND);
                            break;
                    }
                    bv.Label = buttonLabel;

                    string name = ButtonMediator.NAME + bv.Id;
                    Facade.RegisterMediator(new ButtonMediator(bv, name));
                }
            }
        }
    }
}