using System;

using Xamarin.Forms;

namespace AroundMe
{
	public class App : Application
	{
		public static GoogleService Service = new GoogleService();

		public App ()
		{
			// The root page of your application
			MainPage = new AroundMe.MainPage ();
		}
			
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

