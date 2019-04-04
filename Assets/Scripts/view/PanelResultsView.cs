using System;
using Ordina.View;
using UnityEngine;
using UnityEngine.UI;
namespace Ordina.View {

    public class PanelResultsView : BaseAppearanceView, IUI_Animatible {

        private Text textField;
        protected GameObject gameObject;

        public PanelResultsView(GameObject gameObject) {
            this.gameObject = gameObject;
            Id = IdCounter++;
            Init();
        }

        void Init() {
            if (gameObject.GetComponentInChildren<Text>() != null) {
                textField = gameObject.GetComponentInChildren<Text>();
                //var rect = textField.GetComponentInParent<RectTransform>();
                //rect.sizeDelta = new Vector2(textField.transform., textField.preferredHeight);
            }
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}
