using System;
using Ordina.Model;
using PureMVC.Patterns.Mediator;

namespace Ordina.View {

    public class PanelResultsMediator : Mediator {

        public new const string NAME = "PalelResultsMediator";

        public PanelResultsMediator(string name, PanelResultsView viewComponent) : base(name, viewComponent) {
        }

        public PanelResultsView GetViewComponent() {
            return ViewComponent as PanelResultsView;
        }

        public override void OnRegister() {
        }

        private FileProxy GetFileProxy() {
            return (FileProxy)Facade.RetrieveProxy(FileProxy.NAME);
        }

        private ApplicationStateProxy GetApplicationStateProxy() {
            return Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
        }

        private ApplicationMediator GetApplicationMediator() {
            return Facade.RetrieveMediator(ApplicationMediator.NAME) as ApplicationMediator;
        }

        private UserDataProxy GetUserDataProxy() {
            return (UserDataProxy)Facade.RetrieveProxy(UserDataProxy.NAME);
        }
    }
}
