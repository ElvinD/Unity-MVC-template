using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using Ordina.Model.RDW;
using System.Collections.Generic;
using System;

namespace Ordina.Model {
    public class CarProxy : Proxy, IProxy {

        public new const string NAME = "CarProxy";

        public CarProxy() : base(NAME, new List<CarVO>()) {
        }

        public List<CarVO> GetData() {
            return (List<CarVO>)Data;
        }

        public struct CarVO {
            public string id;
            public string pictureSourceURL;
            public VoertuigSpecificatieVO spec;
            public APK_KeuringVO apk;

            public CarVO(string id, string pictureSourceURL) : this() {
                this.id = id ?? throw new ArgumentNullException(nameof(id));
                this.pictureSourceURL = pictureSourceURL ?? throw new ArgumentNullException(nameof(pictureSourceURL));
            }
        }
    }
}