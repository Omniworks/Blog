using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Android.Gms.Maps;

namespace AroundMe
{
	public class MapPage : ContentPage
	{
		private readonly StackLayout main_stack;

		private MainViewModel ViewModel
		{
			get { return BindingContext as MainViewModel; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AroundMe.MapPage"/> class.
		/// </summary>
		public MapPage ()
		{
			//set the totle of the tabbar item
			Title = "Map";

			//Assign out ViewModel to the page's binding context
			BindingContext = new MainViewModel ();

			//create main stack panel for page
			main_stack = new StackLayout ();

			//assign content to page
			Content = main_stack;

			//setup and display the map
			SetupMap();		
		}

		/// <summary>
		/// Get the place list from Google's Location API, create the map and add location pins.
		/// </summary>
		private async void SetupMap()
		{
			//execute load places through our viewmodel (which also gets current posotion)
			await ViewModel.ExecuteLoadPlacesCommand ();

			//create a new Position object with our current coordinates
			var my_position = new Position (App.Locator.Latitude, App.Locator.Longitude);
				
			//initialize the map object
			var map = new Map( MapSpan.FromCenterAndRadius( my_position, Distance.FromKilometers(1)) ) 
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			//loop on the places list and create pins
			foreach (Place p in ViewModel.Places) {
				var pin = new Pin {
					Type = PinType.Place,
					Position = new Position(p.geometry.location.lat, p.geometry.location.lng),
					Label = p.name,
					Address = p.vicinity
				};

				//ad place pin to map
				map.Pins.Add (pin);
			}

			//add map to existing stack layout assigned to page
			main_stack.Children.Add (map);
		}

	}
}


