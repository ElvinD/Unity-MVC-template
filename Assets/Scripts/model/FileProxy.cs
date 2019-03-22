using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;


namespace Ordina.Model {
    public class FileProxy : Proxy, IProxy {

        private static int IdCounter = 0;

        public new const string NAME = "FileProxy";

        public FileProxy() : base(NAME, new Dictionary<string, FileVO>()) {
        }

        public FileVO StoreFileReference(byte[] bytes) {
            string hash;
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) {
                hash = Convert.ToBase64String(sha1.ComputeHash(bytes));
            }
            DateTime date = System.DateTime.Now;
            string url = Application.persistentDataPath + "/" + string.Format("{0}_foto_{1}.jpg", Application.productName, date.ToString("yyyy-MM-dd_HH-mm-ss"));
            GetData().Add(url, new FileVO(FileProxy.IdCounter++, url, hash, date, bytes));
            FileStorageService.SaveToFile(url, bytes);
            ListFiles();
            return GetData()[url];
        }

        public Dictionary<string, FileVO> GetData() {
            return (Dictionary<string, FileVO>)Data;
        }

        private void ListFiles() {
            foreach (KeyValuePair<string, FileVO> entry in GetData()) {
                Debug.Log("stored pictures in proxy: " + entry.Key);
            }
        }
    }

    [System.Serializable]
    public struct FileVO {
        public readonly int id;
        public readonly string url;
        public readonly string hash;
        public readonly DateTime created;
        public readonly byte[] bytes;

        public FileVO(int id, string url, string hash, DateTime created, byte[] bytes) {
            this.id = id;
            this.url = url;
            this.hash = hash;
            this.created = created;
            this.bytes = bytes;
        }
    }

    public static class FileStorageService {

        public static void SaveToFile(string url, byte[] bytes) {
            System.IO.File.WriteAllBytes(url, bytes);
        }

        public static byte[] ReadFile(string url) {
            return System.IO.File.ReadAllBytes(url);
        }
    }
}
