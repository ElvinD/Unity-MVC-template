using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using UnityEngine;

namespace Ordina {
    internal class CreateModelCommand : SimpleCommand {

        public override void Execute(INotification note) {
            Debug.Log("creating model: " + note);
            Facade.RegisterProxy(new CarProxy());
        }
    }
}