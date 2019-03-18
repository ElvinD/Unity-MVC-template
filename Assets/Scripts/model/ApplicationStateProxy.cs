using System.Collections.ObjectModel;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

namespace Ordina.Model {
    public class ApplicationStateProxy : Proxy, IProxy {

        public new const string NAME = "ApplicationStateProxy";

        public ApplicationStateProxy() : base(NAME, new StateVO()) {
        }

        public void SetState(ApplicationStates state) {
            if (GetState() != state) {
                (Data as StateVO).CurrentState = state;
                Debug.Log("setting state to: " + state);
                SendNotification(Notifications.SEND_STATE_CHANGE, state);
            } else {
                Debug.Log("same state: " + state);
            }
        }

        public ApplicationStates GetState() {
            return (Data as StateVO).CurrentState;
        }

    }
    public class StateVO {
        public ApplicationStates CurrentState;

        public StateVO() {
            CurrentState = ApplicationStates.STARTUP;
        }
    }
}