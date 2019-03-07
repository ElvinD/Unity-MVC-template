using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ordina.View {

    public class ButtonView : IUI_Animatible {

        public string Label { get; set; }
        public int Id { get; set; }
        protected static int IdCounter = 0;
        private Text textField;
        protected GameObject gameObject;

        public UnityEvent OnHideStartEvent;
        public UnityEvent OnHideCompleteEvent;
        public UnityEvent OnShowStartEvent;
        public UnityEvent OnShowCompleteEvent;

        public ButtonView(GameObject gameObject) {
            this.gameObject = gameObject;
            Id = IdCounter++;
            Init();
        }


        void Init() {
            Debug.Log("found gameobject: " + gameObject);
            Debug.Log("id for button: " + Id);
            Label = "Neem foto";
            if (gameObject.GetComponentInChildren<Text>() != null) textField = gameObject.GetComponentInChildren<Text>();
            if (textField != null) textField.text = Label;
            //OnHideStartEvent += (e, args) => Debug.Log("on hide event triggered");
            if (OnHideStartEvent != null)  OnHideStartEvent = new UnityEvent();
            if (OnHideCompleteEvent != null) OnHideCompleteEvent = new UnityEvent();
            if (OnShowStartEvent != null) OnShowStartEvent = new UnityEvent();
            if (OnShowCompleteEvent != null) OnShowCompleteEvent = new UnityEvent();

        }

        public void OnClick() {
            //Debug.Log("clicked" + this);
            OnHideStart();
        }

        public void Hide() {
        }

        public void Show() {
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
