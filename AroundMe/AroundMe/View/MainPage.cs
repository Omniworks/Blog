using System;

using Xamarin.Forms;

namespace AroundMe
{
	public class MainPage : TabbedPage
	{
		public MainPage()
		{
			Title = "TabPage";

			var mapPage = new MapPage ();
			var searchPage = new SearchPage ();
			var favoritesPage = new FavoritesPage ();

			Children.Add (mapPage);
			Children.Add (searchPage);
			Children.Add (favoritesPage);
		}
	}
}


