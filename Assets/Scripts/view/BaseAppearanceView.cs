using UnityEngine.Events;

namespace Ordina.View {
    public abstract class BaseAppearanceView {

        protected static int IdCounter = 0;
        public int Id { get; set; }

        public UnityEvent OnHideStartEvent;
        public UnityEvent OnHideCompleteEvent;
        public UnityEvent OnShowStartEvent;
        public UnityEvent OnShowCompleteEvent;
        public UnityEvent OnClickEvent;

        public void InitEvents() {
            OnHideStartEvent = new UnityEvent();
            OnHideCompleteEvent = new UnityEvent();
            OnShowStartEvent = new UnityEvent();
            OnShowCompleteEvent = new UnityEvent();
            OnClickEvent = new UnityEvent();
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
