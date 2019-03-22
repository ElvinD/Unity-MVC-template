using Ordina.Model;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

namespace Ordina.Model {

    /*
     *  Stores interactions made by user
     *  For example; which photo is currently active
     */
    public class UserDataProxy : Proxy, IProxy {

        public new const string NAME = "UserDataProxy";

        public UserDataProxy() : base(NAME, new UserData()) {
        }

        public void SelectPhoto(FileVO file) {
            if (!System.Object.ReferenceEquals(GetData().SelectedPhoto, file)) {
                GetData().SelectedPhoto = file;
                Debug.Log("selecting a photo in proxy");
            } else {
                Debug.Log("same photo selected");
            }
        }

        public UserData GetData() {
            return (UserData)Data;
        }


        public class UserData {
            public FileVO SelectedPhoto;
        }
    }
}
