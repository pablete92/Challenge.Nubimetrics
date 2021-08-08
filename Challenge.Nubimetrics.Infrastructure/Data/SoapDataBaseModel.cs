using Challenge.Nubimetrics.Infrastructure.Enums;

namespace Challenge.Nubimetrics.Infrastructure.Data
{
    public abstract class SoapDataBaseModel
    {
        public const string EstadoNombre = "Estado";
        protected readonly string EstadoResultadoSoap;

        protected SoapDataBaseModel(string estadoResultadoSoap)
        {
            EstadoResultadoSoap = estadoResultadoSoap;
        }

        public EstadoSoapDataModel Estado { get { return this.EstadoResultadoSoap.ToUpper() == "OK" ? EstadoSoapDataModel.Ok : EstadoSoapDataModel.Error; } }
        public bool ResultadoEsValido() { return this.Estado == EstadoSoapDataModel.Ok; }
    }
}
