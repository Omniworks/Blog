using System;

using Xamarin.Forms;

namespace AroundMe
{
	public class SearchPage : ContentPage
	{
		public SearchPage ()
		{
			Title = "Search";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


