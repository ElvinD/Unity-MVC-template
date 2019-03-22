using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ordina.View {
    public class PhoneCamView : BaseAppearanceView, IUI_Animatible {

        private readonly GameObject _renderContainer;
        private readonly RawImage _renderCanvas;
        private readonly GameObject _previewContainer;
        private readonly Image _previewCanvas;
        private WebCamDevice _camDevice;
        private WebCamTexture _camTexture;

        public PhoneCamView(GameObject renderContainer, GameObject previewContainer) {
            _renderContainer = renderContainer;
            _previewContainer = previewContainer;
            if (_renderContainer.GetComponent<RawImage>()) {
                _renderCanvas = _renderContainer.GetComponent<RawImage>();
            } else {
                Debug.LogWarning("Container needs a render canvas RawImage object");
                return;
            }
            if (_previewContainer.GetComponent<Image>()) {
                _previewCanvas = _previewContainer.GetComponent<Image>();
            } else {
                Debug.LogWarning("Container needs a preview canvas Image object");
                return;
            }
            Init();
            ActivateCamera();
        }

        void Init() {
            HidePreview();
            if (Application.platform != RuntimePlatform.Android) {
                GetIDECamera();
            }

            foreach (var device in WebCamTexture.devices) {
                if (Application.platform == RuntimePlatform.Android) {
                    if (!device.isFrontFacing) {
                        _camDevice = device;
                    }
                } else {
                    _camDevice = device;
                }
            }
            _camTexture = new WebCamTexture(_camDevice.name, 1280, 720, 30);
            _renderCanvas.texture = _camTexture;
        }

        /*
         * Coroutines are only available from Monobehaviours, so we inject the main application       
         */
        public void TakePicture(Action<byte[]> onSuccess, MonoBehaviour application) {
            application.StartCoroutine(TakePictureEnum(onSuccess));
        }

        protected IEnumerator TakePictureEnum(Action<byte[]> onSuccess) {

            yield return new WaitForEndOfFrame();
            Texture2D photo = new Texture2D(_camTexture.width, _camTexture.height);

            photo.SetPixels(_camTexture.GetPixels());
            photo.Apply();
            byte[] b = photo.EncodeToJPG(75);
            onSuccess(b);
        }

        public void ShowPreview(byte[] bytes) {
            Texture2D previewTexture = new Texture2D(1, 1);
            previewTexture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(previewTexture, new Rect(0, 0, 1280, 720), new Vector2(1f, 1f));
            _previewCanvas.sprite = sprite;
            _previewContainer.SetActive(true);
        }

        public void HidePreview() {
            if (_previewCanvas && _previewCanvas.sprite) {
                UnityEngine.Object.Destroy(_previewCanvas.mainTexture);
                UnityEngine.Object.Destroy(_previewCanvas.sprite);
                Resources.UnloadUnusedAssets();
            }
            _previewContainer.SetActive(false);
        }

        public void ActivateCamera() {
            if (_camTexture) {
                _camTexture.Play();
            };
        }

        public void DeActivateCamera() {
            if (_camTexture) {
                _camTexture.Stop();
            };
        }

        private IEnumerator GetIDECamera() {
            yield return Application.RequestUserAuthorization(
                UserAuthorization.WebCam);
        }

        public void Hide() {
        }

        public void Show() {
        }
    }
}
