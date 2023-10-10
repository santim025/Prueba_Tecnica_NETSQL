using Microsoft.AspNetCore.Components;
using MudBlazor;
using Prueba_Tecnica.Client.Services;
using Prueba_Tecnica.Shared.DTO;

namespace Prueba_Tecnica.Client.Pages
{
    public partial class Index
    {
        #region INjects
        [Inject]
        public IConsumeService consumeService { get; set; }
        [Inject]
        public ISnackbar SnackBar { get; set; }
        #endregion

        #region Listados
        public List<ConsumptionPerSectionInfo> consumeInfo = new();
        public List<ConsumptionByTypeInfo> consumeByClient = new();
        public List<TrancheClientWithLossesInfo> withLossesInfos = new();
        #endregion

        #region Variables Date
        DateTime dateInitial = DateTime.Today;
        DateTime dateFinish = DateTime.Today;
        #endregion

        #region Mensaje 2 ejercicio
        public string MessageStyle { get; set; } = "";
        #endregion

        #region Overlay cargando pagina
        private Boolean inprogress = false;
        private string textInProgress = "";
        #endregion

        #region Funciones
        //Primer ejercicio
        public async Task SearchConsume()
        {
            inprogress = true;
            textInProgress = "CONSULTANDO...";

            consumeByClient.Clear();
            withLossesInfos.Clear();
            SearchRequest request = new();
            request.DateInitial = dateInitial;
            request.Datefinish = dateFinish;


            consumeInfo = await consumeService.GetAllConsumptionPerSection(request);

            if (consumeInfo.Count != 0)
            {
                showMessage("Datos cargados  correctamente", Severity.Success);
                StateHasChanged();
            }
            else
            {
                showMessage("Error consultando, intentelo nuevamente", Severity.Error);
            }

            inprogress = false;
            StateHasChanged();
        }
        //Segundo ejercicio
        public async Task SearchConsumeByClient()
        {
            inprogress = true;
            textInProgress = "CONSULTANDO...";

            consumeInfo.Clear();
            withLossesInfos.Clear();
            SearchRequest request = new();
            request.DateInitial = dateInitial;
            request.Datefinish = dateFinish;

            consumeByClient = await consumeService.ConsumeByCLient(request);

            if (consumeByClient.Count != 0)
            {
                var tramoConMasPerdidas = consumeByClient.OrderByDescending(x => Math.Max(x.PerdidaResidencial, Math.Max(x.PerdidaIndustrial, x.PerdidaComercial))).First();
                double perdidas = Math.Round(tramoConMasPerdidas.PerdidaIndustrial + tramoConMasPerdidas.PerdidaResidencial + tramoConMasPerdidas.PerdidaComercial,3);

                MessageStyle = $"El tramo con mas perdidas es {tramoConMasPerdidas.Linea}, con {perdidas * 100} %";

                showMessage("Datos cargados  correctamente", Severity.Success);
            }
            else
            {
                showMessage("Error consultando, intentelo nuevamente", Severity.Error);
            }

            inprogress = false;
            StateHasChanged();
        }
        //Tercer ejercicio
        public async Task SearchTwenty()
        {
            inprogress = true;
            textInProgress = "CONSULTANDO...";

            consumeByClient.Clear();
            consumeInfo.Clear();
            SearchRequest request = new();
            request.DateInitial = dateInitial;
            request.Datefinish = dateFinish;

            withLossesInfos = await consumeService.ObtainTwentyBadLines(request);

            if (withLossesInfos.Count != 0)
            {
                showMessage("Datos cargados correctamente", Severity.Success);
            }
            else
            {
                showMessage("Error consultando, intentelo nuevamente", Severity.Error);
            }

            inprogress = false;
            StateHasChanged();
        }

        void showMessage(string message, Severity severity)
        {
            SnackBar.Clear();
            SnackBar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            SnackBar.Add(message, severity);
        }
        #endregion
    }
}
