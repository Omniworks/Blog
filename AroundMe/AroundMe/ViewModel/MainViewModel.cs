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

		//Command property for loading places operation bound
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
			//check if an operation is already in progress and if true then return
			if (IsBusy)
				return;

			//set IsBusy flag true to indicate that a load  operation is starting 
			IsBusy = true;

			//notify abbor command state change (as it is bound to busy flag)
			LoadPlacesCommand.ChangeCanExecute();

			try
			{
				//get current location
				bool DidGetLocation = await App.Locator.GetLocation();
					
				if(DidGetLocation) {
					//execute the load operation
					NearbyQuery query = await App.Service.GetPlacesForCoordinates(App.Locator.Latitude, App.Locator.Longitude);

					//populate places list with results
					if(query.Places != null ) {
						foreach (Place p in query.Places) {
							Places.Add (p);
						}
					}
				}
			}
			catch(Exception ex) {
				Debug.WriteLine ("Error loading places: ", ex.Message);
			}
			finally {
				//an operation is finished
				IsBusy = false;

				//notify abbor command state change (as it is bound to busy flag)
				LoadPlacesCommand.ChangeCanExecute();
			}
		}
	}
}

