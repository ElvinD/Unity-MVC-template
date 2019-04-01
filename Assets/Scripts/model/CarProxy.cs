using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using Ordina.Model.RDW;
using System.Collections.Generic;

namespace Ordina.Model {
    public class CarProxy : Proxy, IProxy {

        public new const string NAME = "CarProxy";

        public CarProxy() : base(NAME, new List<CarVO>()) {
        }

        public List<CarVO> GetData() {
            return (List<CarVO>)Data;
        }

        public struct CarVO {
            public string pictureSourceURL;
            public VoertuigSpecificatieVO spec;
            public APK_KeuringVO apk;
        }
    }
}