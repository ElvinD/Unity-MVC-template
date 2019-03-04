using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

namespace Ordina {
    internal class CreateViewCommand : SimpleCommand {
        
        public override void Execute(INotification notification) {
            Main app = (Main) notification.Body;
            Debug.Log("creating mediator " + app);
            Facade.RegisterMediator(new ApplicationMediator(app));
        }
    }
}