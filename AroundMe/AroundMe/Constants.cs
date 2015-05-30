using System;

namespace AroundMe
{
	public static class Constants
	{
		public const string APIKey = "YOUR_API_KEY";
		public const string PlacesQueryUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?types=cafe&location={0},{1}&opennow=true&rankby=distance&key={2}";
	}
}

