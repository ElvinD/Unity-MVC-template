using PureMVC.Patterns.Mediator;
using UnityEngine;
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

        public override void OnRegister() {
            InitListeners();
        }

        public PhoneCamView GetViewComponent() {
            return ViewComponent as PhoneCamView;
        }
    }
}
