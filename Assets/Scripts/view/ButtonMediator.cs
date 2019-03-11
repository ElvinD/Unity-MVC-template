﻿using PureMVC.Patterns.Mediator;
using UnityEngine;
namespace Ordina.View {
    public class ButtonMediator: Mediator {
        public new const string NAME = "ButtonMediator-";

        public ButtonMediator(ButtonView viewComponent, string name) : base(name, viewComponent) {
        }

        protected void InitListeners() {
            if (GetViewComponent() != null) {
                GetViewComponent().InitEvents();
                GetViewComponent().OnClickEvent.AddListener(OnButtonClicked);
            } else {
                Debug.Log("ButtonMediator not ready: " + this);
            }
        }

        protected void OnButtonClicked() {
            //Debug.Log("heard click from: " + GetViewComponent().Id);
            SendNotification(Notifications.SEND_UI_ACTION, GetViewComponent().Config);
        }

        public override void OnRegister() {
            InitListeners();

        }

        public ButtonView GetViewComponent() {
            return ViewComponent as ButtonView;
        }
    }
}
