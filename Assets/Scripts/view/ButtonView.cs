using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ordina.View {

    public class ButtonView : IUI_Animatible {

        public string Label { 
            get { return _label; }
            set { _label = value;
                if (gameObject.GetComponentInChildren<Text>() != null) textField = gameObject.GetComponentInChildren<Text>();
                if (textField != null) {
                    textField.text = _label;
                }
            }
        }
        private string _label;
        protected static int IdCounter = 0;
        private Text textField;
        protected GameObject gameObject;

        public ViewComponentConfig Config { get; private set; }
        public int Id { get; set; }
        public UnityEvent OnHideStartEvent;
        public UnityEvent OnHideCompleteEvent;
        public UnityEvent OnShowStartEvent;
        public UnityEvent OnShowCompleteEvent;
        public UnityEvent OnClickEvent;

        public ButtonView(GameObject gameObject, string label = "Default button") {
            this.gameObject = gameObject;
            Id = IdCounter++;
            Init();
            Label = label;
        }

        void Init() {
            Config = gameObject.GetComponent<ViewComponentConfig>();
            if (Config != null) {
                //Debug.Log("found view config: " + _config);
            } else {
                Debug.Log("Button with id: " + Id + " did not find a IDE config for this component, this is bad mojo. Throw some bad Error or smth.");
            } 
        }

        public void InitEvents() {
            OnHideStartEvent = new UnityEvent();
            OnHideCompleteEvent = new UnityEvent();
            OnShowStartEvent = new UnityEvent();
            OnShowCompleteEvent = new UnityEvent();
            OnClickEvent = new UnityEvent();
            Button button = gameObject.GetComponent<Button>();
            if (button) {
                button.onClick.AddListener(OnClick);
            } else {
                Debug.Log("No button found, are you sure this is the right kind of game object?");
            }
        }

        public void Hide() {
        }

        public void Show() {
        }

        protected void OnClick() {
            OnClickEvent?.Invoke();
        }

        protected void OnHideStart() {
            OnHideStartEvent?.Invoke(); 
        }

        protected void OnHideComplete() {
            OnHideCompleteEvent?.Invoke();
        }

        protected void OnShowStart() {
            OnShowStartEvent?.Invoke();
        }

        protected void OnShowComplete() {
            OnShowCompleteEvent?.Invoke();
        }
    }
}
