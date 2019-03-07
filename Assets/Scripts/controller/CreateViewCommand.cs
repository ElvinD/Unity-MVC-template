using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using Ordina.View;

namespace Ordina.Controller {
    internal class CreateViewCommand : SimpleCommand {

        public override void Execute(INotification notification) {
            Main app = (Main) notification.Body;
            Debug.Log("creating mediator " + app);
            Facade.RegisterMediator(new ApplicationMediator(app));
            RegisterButtonMediators();
        }

        private void RegisterButtonMediators() {
            var objects = GameObject.FindGameObjectsWithTag(GameObjectTags.BUTTON);
            if (objects != null) {
                foreach (GameObject o in objects) {
                    ButtonView bv = new ButtonView(o);
                    string name = ButtonMediator.NAME + bv.Id;
                    Facade.RegisterMediator(new ButtonMediator(bv, name));
                }
            }
        }
    }
}