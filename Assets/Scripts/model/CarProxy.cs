using System.Collections.ObjectModel;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

namespace Ordina.Model {
    public class CarProxy : Proxy, IProxy {

        public new const string NAME = "CarProxy";

        public CarProxy() : base(NAME, new ObservableCollection<CarVO>()) {
}

        private class CarVO {
        }
    }
}