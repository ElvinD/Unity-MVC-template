using System;
using Ordina.Model;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

namespace Ordina.Controller {
    internal class InitStateCommand : SimpleCommand {
        public override void Execute(INotification notification) {
            ApplicationStateProxy stateProxy = Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
            stateProxy.SetState(ApplicationStates.USING_CAMERA);
        }
    }
}
