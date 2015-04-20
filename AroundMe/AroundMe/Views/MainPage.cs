using System;

using Xamarin.Forms;

namespace AroundMe
{
	public class MainPage : ContentPage
	{
		private MainModel ViewModel
		{
			get { return BindingContext as MainModel; }
		}

		public MainPage ()
		{
			BindingContext = new MainModel ();

			var main_stack = new StackLayout ();

			var header_label = new Label () {
				Text = "Places",
				FontSize = 20,
				BackgroundColor = Color.Accent,
				TextColor = Color.FromHex("FFFFFF"),
				HeightRequest = 40,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			var places_list = new ListView () {
				IsPullToRefreshEnabled=true,
				RefreshCommand = ViewModel.LoadPlacesCommand,
				ItemsSource = ViewModel.Places
			};
			places_list.SetBinding(ListView.IsRefreshingProperty, "IsBusy");

			var cell = new DataTemplate (typeof(ImageCell));
			cell.SetBinding (TextCell.TextProperty, "name");
			cell.SetBinding (ImageCell.ImageSourceProperty, "icon");

			places_list.ItemTemplate = cell;

			main_stack.Children.Add (header_label);
			main_stack.Children.Add(places_list);

			Content = main_stack;

			ViewModel.LoadPlacesCommand.Execute (null);
		}
	}
}


