namespace BitCoinAPI
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Net.Http;
	using Newtonsoft.Json;

	public static class CoinService
	{
		private static readonly HttpClient Client = new HttpClient();
		private const string Apiurl = "https://api.coindesk.com/v1/bpi/currentprice.json";

		public static List<CoinResponse> GetCoinPrice()
		{
			var coinBaseResults = JsonConvert.DeserializeObject<CoinDeskResults>(Client.GetAsync(Apiurl)
				.Result.Content.ReadAsStringAsync()
				.Result);
			var result = new List<CoinResponse>
			{
				new CoinResponse()
				{
					Name = coinBaseResults.Bpi.Usd.Code,
					ReportData = new List<ReportResult>
					{
						new ReportResult
						{
							Count = coinBaseResults.Bpi.Usd.Rate,
							Group = coinBaseResults.Time.Updated
						}
					}
				},
				new CoinResponse()
				{
					Name = coinBaseResults.Bpi.Gbp.Code,
					ReportData = new List<ReportResult>
					{
						new ReportResult
						{
							Count = coinBaseResults.Bpi.Gbp.Rate,
							Group = coinBaseResults.Time.Updated
						}
					}
				},
				new CoinResponse()
				{
					Name = coinBaseResults.Bpi.Eur.Code,
					ReportData = new List<ReportResult>
					{
						new ReportResult
						{
							Count = coinBaseResults.Bpi.Eur.Rate,
							Group = coinBaseResults.Time.Updated
						}
					}
				}
				};
			return result;
		}
	}
}
