using System;

using Xamarin.Forms;

namespace AroundMe
{
	public class FavoritesPage : ContentPage
	{
		public FavoritesPage ()
		{
			Title = "Favorites";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


