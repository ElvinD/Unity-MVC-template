using UnityEngine;
using PureMVC.Patterns.Facade;

namespace Ordina {

    static class ApplicationKeys {
        public const string MAIN = "MainApplication";
        public const string MAIN_FACADE = "MainFacade";
    }

    public class Main : MonoBehaviour {

        void Start() {
            ApplicationFacade facade = (ApplicationFacade)Facade.GetInstance(() => new ApplicationFacade(ApplicationKeys.MAIN));
            facade.Startup(this);
        }
    }


    public class ApplicationFacade : Facade {

        #region Notification name constants

        public const string STARTUP = "startup";

        #endregion

        public ApplicationFacade(string key) : base() { }


        public void Startup(Main app) {
            //Debug.Log("started app: " + app);
            SendNotification(STARTUP, app);
        }


        protected override void InitializeController() {
            base.InitializeController();
            RegisterCommand(STARTUP, () => new StartupCommand());

        }

    }
}
