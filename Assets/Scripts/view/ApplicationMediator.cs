using PureMVC.Patterns.Mediator;
using UnityEngine;
namespace Ordina.View {
    public class ApplicationMediator : Mediator {

        public new const string NAME = "ApplicationMediator";

        public ApplicationMediator(Main viewComponent = null) : base(NAME, viewComponent) {
        }

        public Main GetViewComponent() {
            return ViewComponent as Main;
        }
    }
}
