using UnityEngine;
using System.Collections.Generic;
using PureMVC.Patterns.Facade;
using Ordina.Controller;
using Ordina.View;

namespace Ordina {

    #region Application key constants
    static class ApplicationKeys {
        public const string MAIN = "MainApplication";
        public const string MAIN_FACADE = "MainFacade";
    }
    #endregion

    #region Notification name constants
    static class Notifications {
        public const string STARTUP = "startup";
        public const string SEND_UI_ACTION = "send_ui_action";
    }
    #endregion
    //[System.Serializable]
    public enum ApplicationActions {
        TAKE_PHOTO,
        UPLOAD_PHOTO,
        RESET_PHOTO
    }

    static class GameObjectTags {
        public const string BUTTON = "UI_Button";
    }

    public class Main : MonoBehaviour {

        void Start() {
            ApplicationFacade facade = (ApplicationFacade)Facade.GetInstance(() => new ApplicationFacade(ApplicationKeys.MAIN));
            facade.Startup(this);
        }
    }


    public class ApplicationFacade : Facade {

        public ApplicationFacade(string key) : base() { }


        public void Startup(Main app) {
            //Debug.Log("started app: " + app);
            SendNotification(Notifications.STARTUP, app);
        }


        protected override void InitializeController() {
            base.InitializeController();
            RegisterCommand(Notifications.STARTUP, () => new StartupCommand());
            RegisterCommand(Notifications.SEND_UI_ACTION, () => new HandleUIActionCommand());

        }

    }
}
