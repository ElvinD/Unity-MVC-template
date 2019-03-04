using UnityEngine;
using PureMVC.Patterns.Command;

namespace Ordina {

    public class StartupCommand : MacroCommand {
       protected override void InitializeMacroCommand() {
            AddSubCommand(() => new CreateModelCommand());
            AddSubCommand(() => new CreateViewCommand());

        }
    }
}