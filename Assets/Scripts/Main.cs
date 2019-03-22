using UnityEngine;
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
        public const string REQUEST_RETRIEVE_DATA = "request_retrieve_data";
        public const string REQUEST_STATE_CHANGE = "request_state_change";
        public const string SEND_STATE_CHANGE = "send_state_change";


    }
    #endregion

    #region Button actions
    [System.Serializable]
    public enum UIActions {
        TAKE_PHOTO,
        UPLOAD_PHOTO,
        RESET_PHOTO
    }
    #endregion

    #region Application states
    public enum ApplicationStates {
        STARTUP,
        USING_CAMERA,
        REVIEWING_PHOTO_PREVIEW,
        SHOWING_RESULTS
    }
    #endregion

    static class GameObjectTags {
        public const string BUTTON = "UI_Button";
        public const string PHONECAM_RENDER = "UI_CamRender";
        public const string PHONECAM_PREVIEW = "UI_CamPreview";
    }

    public class Main : MonoBehaviour {

        public static Main instance;

        void Start() {
            Main.instance = this;
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
            RegisterCommand(Notifications.REQUEST_RETRIEVE_DATA, () => new RetrieveDataCommand());
        }
    }
}
