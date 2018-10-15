using System;
using Xamarin.Forms;
using TallerAPI.Xamarin.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TallerAPI.Xamarin
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();


			MainPage = new ListViewPage1();
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
