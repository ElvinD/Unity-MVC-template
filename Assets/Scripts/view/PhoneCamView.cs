using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ordina.View {
    public class PhoneCamView : BaseAppearanceView, IUI_Animatible {

        private readonly RawImage _renderCanvas;
        private WebCamDevice _camDevice;
        private WebCamTexture _camTexture;

        public PhoneCamView(GameObject renderContainer) {
            if (renderContainer.GetComponent<RawImage>()) {
                _renderCanvas = renderContainer.GetComponent<RawImage>();
            } else {
                Debug.LogWarning("Container needs a render canvas RawImage object");
                return;
            }
            Init();
            Activate();
        }

        void Init() {
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

        public void Activate() {
            if (_camTexture) {
                _camTexture.Play();
            };
        }

        public void DeActivate() {
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
