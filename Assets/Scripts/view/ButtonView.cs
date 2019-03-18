using UnityEngine;
using UnityEngine.UI;

namespace Ordina.View {

    public class ButtonView : BaseAppearanceView, IUI_Animatible {

        public string Label {
            get { return _label; }
            set {
                _label = value;
                if (gameObject.GetComponentInChildren<Text>() != null) textField = gameObject.GetComponentInChildren<Text>();
                if (textField != null) {
                    textField.text = _label;
                }
            }
        }

        private string _label;
        private Text textField;
        protected GameObject gameObject;
        public ViewComponentConfig Config { get; private set; }

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
                Debug.LogWarning("Button with id: " + Id + " did not find a IDE config for this component, this is bad mojo. Throw some bad Error or smth.");
            }
        }

        new public void InitEvents() {
            base.InitEvents();
            Button button = gameObject.GetComponent<Button>();
            if (button) {
                button.onClick.AddListener(OnClick);
            } else {
                Debug.LogWarning("No button found, are you sure this is the right kind of game object?");
            }
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        protected void OnClick() {
            OnClickEvent?.Invoke();
        }
    }
}
