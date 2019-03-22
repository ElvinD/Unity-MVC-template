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
        public OnDataResultDelegate onRDWDataResultDelegate;


        public RestService() {
        }

        public IEnumerator UploadImage(string restAPI_URL, byte[] bytes) {
            yield return new WaitForEndOfFrame();
            HttpClient client = new HttpClient();
            string imagebase64 = System.Convert.ToBase64String(bytes);
            var content = new StringContent(imagebase64);
            //Debug.Log ("upload to RDW Started");
            client.Post(new System.Uri(restAPI_URL), content, HttpCompletionOption.AllResponseContent, OnUploadImageComplete, (u) => { });
        }

        private T ParseImageResults(string results) {
            return JsonUtility.FromJson<T>(results);
        }

        private void OnUploadImageComplete(HttpResponseMessage r) {

            var byteArray = r.ReadAsByteArray();
            var responseData = System.Text.Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            onRDWDataResultDelegate?.Invoke(ParseImageResults(responseData));

            //openALPRResult = ParseALPRResults(PictureAlprData);

            //if (openALPRResult.results?.Count > 0) {
            //    InitRDWData(openALPRResult.results.Count);
            //    StartCoroutine(RetrieveRDWInfo(openALPRResult.results[0].plate));
            //} else {
            //    Debug.Log("No plates found!");
            //    onRDWDataResultDelegate();
            //}
        }
    }
}
