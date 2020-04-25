using System;

namespace BitCoinAPI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CoinDeskResults
    {
        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("bpi")]
        public Bpi Bpi { get; set; }
    }

    public class Bpi
    {
        [JsonProperty("USD")]
        public Eur Usd { get; set; }

        [JsonProperty("GBP")]
        public Eur Gbp { get; set; }

        [JsonProperty("EUR")]
        public Eur Eur { get; set; }
    }

    public class Eur
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate_float")]
        public double RateFloat { get; set; }
    }

    public class Time
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("updatedISO")]
        public DateTimeOffset UpdatedIso { get; set; }
    }

    public class CoinResponse
    {
        public string Name { get; set; }
        public List<ReportResult> ReportData { get; set; }
    }
    public class ReportResult
    {
        public string Group { get; set; }
        public string Count { get; set; }
    }
}
