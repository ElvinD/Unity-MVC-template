using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using UnityEngine;
using Ordina.Model.RDW;
using Ordina.Service.RDW;
using Ordina.Model;
using Ordina.View;
using static Ordina.Model.CarProxy;

namespace Ordina.Controller {
    internal class RetrieveDataCommand : SimpleCommand {

        public override void Execute(INotification notification) {

            UploadImageAndRetrieveRDWData();
        }

        private void UploadImageAndRetrieveRDWData() {

            RestService<OpenALPRVO> restService = new RestService<OpenALPRVO> {
                onDataResultDelegate = (OpenALPRVO result) => {
                    Debug.Log("retrieved a result from api: " + result);
                    if (result.results.Count > 0) {
                        StoreCarData(result);
                        RetrieveRDWData();
                    } else {
                        Debug.Log("No licenseplates found");
                        GetStateProxy().SetState(ApplicationStates.USING_CAMERA);
                    }
                }
            };
            Main application = GetApplicationMediator().GetViewComponent();
            application.StartCoroutine(restService.UploadImage(RDWSpecs.OpenALPR_URL + RDWSpecs.OpenALPR_KEY, GetUserDataProxy().GetData().SelectedPhoto.bytes));
        }

        private void StoreCarData(OpenALPRVO carData) {
            for (var i = 0; i < carData.results.Count; i++) {
                CarVO car = new CarVO(carData.results[i].plate, GetUserDataProxy().GetData().SelectedPhoto.url);
                GetCarProxy().GetData().Add(car);
            }
        }

        private void RetrieveRDWData() {
            /*
             * For now only grab the first result, but this could be expanded with a list of selectable plates or something           
             */
            CarVO car = GetCarProxy().GetData()[0];
            RestService<VoertuigSpecificatieVO> restService = new RestService<VoertuigSpecificatieVO> {
                onDataResultDelegate = (VoertuigSpecificatieVO result) => {
                    Debug.Log("retrieved a result from RDW: " + result);
                }
            };
            Main application = GetApplicationMediator().GetViewComponent();
            application.StartCoroutine(restService.RetrieveRDWInfo(RDWSpecs.RDW_URL, RDWSpecs.RDW_KEY, car.id));

        }

        private CarProxy GetCarProxy() {
            return Facade.RetrieveProxy(CarProxy.NAME) as CarProxy;
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