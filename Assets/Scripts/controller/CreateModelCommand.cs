using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using Ordina.Model;

namespace Ordina.Controller {
    internal class CreateModelCommand : SimpleCommand {

        public override void Execute(INotification notification) {
            Facade.RegisterProxy(new ApplicationStateProxy());
            Facade.RegisterProxy(new CopyProxy());
            Facade.RegisterProxy(new FileProxy());
            Facade.RegisterProxy(new UserDataProxy());
            Facade.RegisterProxy(new CarProxy());
        }
    }
}