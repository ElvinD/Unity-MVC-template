using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;
namespace Ordina.Model {

    /*
     * CopyProxy is used for storing copy like labels, texts etc for UI elements like buttons and panels
     */    
    public class CopyProxy : Proxy, IProxy {

        public new const string NAME = "CopyProxy";

        public CopyProxy() : base(NAME, new Dictionary<string, string>()) {
        }

        public override void OnRegister() {
            GetData().Add(CopyKeys.TAKE_PICTURE, "Neem foto");
            GetData().Add(CopyKeys.CLEAR_PICTURE, "Verwijder foto");
            GetData().Add(CopyKeys.UPLOAD_DATA, "Haal info op");
            GetData().Add(CopyKeys.COPY_NOT_FOUND, "Label ontbreekt");
            GetData().Add(CopyKeys.RESET, "Opnieuw");
        }

        protected Dictionary<string, string> GetData() {
            return (Dictionary<string, string>)Data;
        }

        public string GetCopy(string key) {
            string result = CopyKeys.COPY_NOT_FOUND;
            if (GetData().TryGetValue(key, out result)) {
                return result;
            }
            else {
                return result;
            }
        }

    }
    public struct CopyVO {
        public string label;
        public string value;
    }

    public static class CopyKeys {
        public const string TAKE_PICTURE = "TAKE_PICTURE";
        public const string CLEAR_PICTURE = "CLEAR_PICTURE";
        public const string RESET = "RESET";
        public const string COPY_NOT_FOUND = "COPY_NOT_FOUND";
        public const string UPLOAD_DATA = "UPLOAD_DATA";
        
    }
}