using System;
using System.Diagnostics;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace AroundMe
{
	public class MainViewModel:BaseViewModel
	{
		public ObservableCollection<Place> Places = new ObservableCollection<Place>();

		public MainViewModel ()
		{
		}

		private Command _LoadPlacesCommand;
		public Command LoadPlacesCommand
		{
			get
			{
				return _LoadPlacesCommand ?? (_LoadPlacesCommand = new Command(ExecuteLoadPlacesCommand, () => !IsBusy ));
			}            
		}

		private async void ExecuteLoadPlacesCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			LoadPlacesCommand.ChangeCanExecute();

			try
			{
				NearbyQuery query = await App.Service.GetPlacesForCoordinates(38.145176, 23.830061);

				if(query.Places != null ) {
					foreach (Place p in query.Places) {
						Places.Add (p);
					}
				}
			}
			catch(Exception ex) {
				Debug.WriteLine ("Error loading places: ", ex.Message);
			}
			finally {
				IsBusy = false;
				LoadPlacesCommand.ChangeCanExecute();
			}
		}
	}
}

