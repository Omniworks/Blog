using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AroundMe
{
	public class GoogleService
	{
		public GoogleService ()
		{
		}
			
		private async Task<R> GetRequest<R>(string url)
		{
			HttpClient httpClient = new HttpClient();

			HttpResponseMessage response = await httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode)
				throw (new Exception(response.Content.ToString()));

			string responseString = response.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<R>(responseString);
		}

		public async Task<NearbyQuery> GetPlacesForCoordinates( Double latitude, Double longitude)
		{
			var url = String.Format (Constants.PlacesQueryUrl, latitude.ToString().Replace(',','.'), longitude.ToString().Replace(',','.'), Constants.APIKey);

			return await GetRequest<NearbyQuery>( url );
		}
	}
}
	