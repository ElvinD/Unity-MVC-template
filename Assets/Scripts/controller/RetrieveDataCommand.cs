using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using UnityEngine;
using Ordina.Model.RDW;
using Ordina.Service.RDW;
using Ordina.Model;
using Ordina.View;

namespace Ordina.Controller {
    internal class RetrieveDataCommand : SimpleCommand {

        public override void Execute(INotification notification) {

            UploadImage();
        }

        private void UploadImage() {
            RestService<OpenALPRVO> restService = new RestService<OpenALPRVO> {
                onRDWDataResultDelegate = (OpenALPRVO result) => {
                    Debug.Log("retrieved a result from api: " + result);
                    if (result.results.Count > 0) {

                    } else {
                        Debug.Log("No licenseplates found");
                        GetStateProxy().SetState(ApplicationStates.USING_CAMERA);
                    }
                }
            };
            Main application = GetApplicationMediator().GetViewComponent();
            application.StartCoroutine(restService.UploadImage(RDWSpecs.OpenALPR_URL + RDWSpecs.OpenALPR_KEY, GetUserDataProxy().GetData().SelectedPhoto.bytes));
        }

        private UserDataProxy GetUserDataProxy() {
            return Facade.RetrieveProxy(UserDataProxy.NAME) as UserDataProxy;
        }

        private ApplicationMediator GetApplicationMediator() {
            return Facade.RetrieveMediator(ApplicationMediator.NAME) as ApplicationMediator;
        }

        private ApplicationStateProxy GetStateProxy() {
            return Facade.RetrieveProxy(ApplicationStateProxy.NAME) as ApplicationStateProxy;
        }
    }
}