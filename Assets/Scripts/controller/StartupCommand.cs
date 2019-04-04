using PureMVC.Patterns.Command;

namespace Ordina.Controller {

    public class StartupCommand : MacroCommand {
        protected override void InitializeMacroCommand() {
            AddSubCommand(() => new CreateModelCommand());
            AddSubCommand(() => new CreateViewCommand());
            AddSubCommand(() => new InitStateCommand());

        }
    }
}