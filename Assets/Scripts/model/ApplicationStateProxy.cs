using System.Collections.ObjectModel;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

namespace Ordina.Model {
    public class ApplicationStateProxy : Proxy, IProxy {

        public new const string NAME = "ApplicationStateProxy";

        public ApplicationStateProxy() : base(NAME, new ObservableCollection<StateVO>()) {
}

        private class StateVO {
        }
    }
}