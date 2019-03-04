using PureMVC.Patterns.Mediator;
using UnityEngine;
namespace Ordina {
    public class ApplicationMediator : Mediator {

        public new const string NAME = "ApplicationMediator";


        public ApplicationMediator(Main viewComponent = null) : base(NAME, viewComponent) {
        }

        public override void OnRegister() {
            //CarProxy proxy = (CarProxy)Facade.RetrieveProxy(CarProxy.NAME);
        }
    }
}
