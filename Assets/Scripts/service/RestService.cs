using System.Collections;
using System.Collections.Generic;
using System.IO;
using CI.HttpClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ordina.Service.RDW {

    public class RestService<T> {

        public delegate void OnDataResultDelegate(T data);
        public OnDataResultDelegate onDataResultDelegate;


        public RestService() {
        }

        public IEnumerator UploadImage(string restAPI_URL, byte[] bytes) {
            yield return new WaitForEndOfFrame();
            HttpClient client = new HttpClient();
            string imagebase64 = System.Convert.ToBase64String(bytes);
            var content = new StringContent(imagebase64);
            //Debug.Log ("upload to RDW Started");
            client.Post(new System.Uri(restAPI_URL), content, HttpCompletionOption.AllResponseContent, OnDataRequestComplete, (u) => { });
        }

        private T ParseDataResults(string results) {
            return JsonUtility.FromJson<T>(results);
        }

        private void OnDataRequestComplete(HttpResponseMessage r) {
            var byteArray = r.ReadAsByteArray();
            var responseData = System.Text.Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            onDataResultDelegate?.Invoke(ParseDataResults(responseData));
        }

        public IEnumerator RetrieveRDWInfo(string restAPI_URL, string key, string plate) {
            yield return new WaitForEndOfFrame();
            HttpClient client = new HttpClient();
            client.Get(new System.Uri(restAPI_URL + plate + "&$$app_token=" + key), HttpCompletionOption.AllResponseContent, (r) => {
                var byteArray = r.ReadAsByteArray();
                string responseData = System.Text.Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                Debug.Log("retreived from RDW:  " + responseData);
                if (!string.IsNullOrEmpty(responseData)) {
                    if (responseData[0] == '[' && responseData[responseData.Length - 2] == ']') {
                        responseData = responseData.Remove(0, 1);
                        responseData = responseData.Remove(responseData.Length - 2, 1);
                        onDataResultDelegate?.Invoke(ParseDataResults(responseData));
                    }
                }
            });
        }
    }
}
