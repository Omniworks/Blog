using System;
using System.Diagnostics;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace AroundMe
{
	public class MainModel:BaseViewModel
	{
		public ObservableCollection<result> Places = new ObservableCollection<result>();

		public MainModel ()
		{
		}

		private Command _LoadPlacesCommand;
		public Command LoadPlacesCommand
		{
			get
			{
				return _LoadPlacesCommand ?? (_LoadPlacesCommand = new Command(ExecuteLoadPlacesCommand));
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
				NearbyQuery query = await App.Service.GetPlacesForCoordinates(0.0, 0.0);

				if(query.results != null ) {
					foreach (result p in query.results) {
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

