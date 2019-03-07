using PureMVC.Patterns.Mediator;
using UnityEngine;
namespace Ordina.View {
    public class ButtonMediator: Mediator {
        public new const string NAME = "ButtonMediator-";

        public ButtonMediator(ButtonView viewComponent, string name) : base(name, viewComponent) {
        }

        public override void OnRegister() {
            //CarProxy proxy = (CarProxy)Facade.RetrieveProxy(CarProxy.NAME);
            Debug.Log("we have view component: " + GetViewComponent() + "from " + MediatorName);
        }

        public ButtonView GetViewComponent() {
            return ViewComponent as ButtonView;
        }
    }
}
