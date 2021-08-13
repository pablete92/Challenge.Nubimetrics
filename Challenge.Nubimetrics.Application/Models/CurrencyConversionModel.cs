using Newtonsoft.Json;

namespace Challenge.Nubimetrics.Application.Models
{
    public partial class CurrencyConversionModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public string DecimalPlaces { get; set; }

        [JsonProperty("to_dolar")]
        public CurrencyConversionToDolarModel ToDolar { get; set; }
    }

    public partial class CurrencyConversionToDolarModel
    {
        [JsonProperty("currency_base")]
        public string CurrencyBase { get; set; }

        [JsonProperty("currency_quote")]
        public string CurrencyQuote { get; set; }

        [JsonProperty("ratio")]
        public string Ratio { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("inv_rate")]
        public string InvRate { get; set; }

        [JsonProperty("creation_date")]
        public string CreationDate { get; set; }

        [JsonProperty("valid_until")]
        public string ValidUntil { get; set; }
    }
}