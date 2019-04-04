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
            RegisterResultsMediator();
        }

        private void RegisterPhoneCamMediator() {
            var canvasContainer = GameObject.FindGameObjectWithTag(GameObjectTags.PHONECAM_RENDER);
            if (canvasContainer == null) {
                Debug.LogWarning("Phone camera view needs a render canvas, but none was found");
                return;
            }
            var previewContainer = GameObject.FindGameObjectWithTag(GameObjectTags.PHONECAM_PREVIEW);
            if (previewContainer == null) {
                Debug.LogWarning("Phone camera view needs a preview canvas, but none was found");
                return;
            }
            PhoneCamView phonecam = new PhoneCamView(canvasContainer, previewContainer);
            Facade.RegisterMediator(new PhoneCamMediator(PhoneCamMediator.NAME, phonecam));
        }

        private void RegisterButtonMediators() {
            var objects = GameObject.FindGameObjectsWithTag(GameObjectTags.BUTTON);
            var copyProxy = Facade.RetrieveProxy(CopyProxy.NAME) as CopyProxy;
            string buttonLabel;
            if (objects != null) {
                foreach (GameObject o in objects) {
                    ButtonView bv = new ButtonView(o);
                    switch (bv.Config?.actions) {
                        case UIActions.TAKE_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.TAKE_PHOTO);
                            break;

                        case UIActions.LOAD_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.LOAD_PHOTO);
                            break;

                        case UIActions.UPLOAD_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.UPLOAD_DATA);
                            break;

                        case UIActions.RESET_PHOTO:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.CLEAR_PHOTO);
                            break;

                        default:
                            buttonLabel = copyProxy.GetCopy(CopyKeys.COPY_NOT_FOUND);
                            break;
                    }
                    bv.Label = buttonLabel;

                    string name = ButtonMediator.NAME + bv.Id;
                    Facade.RegisterMediator(new ButtonMediator(name, bv));
                }
            }
        }

        private void RegisterResultsMediator() {
            var resultsContainer = GameObject.FindGameObjectWithTag(GameObjectTags.TEXT_RESULTS);
            if (resultsContainer == null) {
                Debug.LogWarning("Application needs panel to show results, but none was found");
                return;
            }

            PanelResultsView resultsView = new PanelResultsView(resultsContainer);
            Facade.RegisterMediator(new PanelResultsMediator(PanelResultsMediator.NAME, resultsView));
        }
    }
}