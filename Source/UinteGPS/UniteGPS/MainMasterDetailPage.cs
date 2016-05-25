using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public class MainMasterDetailPage : MasterDetailPage
	{
		#region PRIVATE VARIABLES
		private MenuScreen pageMasterMenu;

		private LiveMapScreen pageMapScreen;
		#endregion

		public MainMasterDetailPage ()
		{
			pageMasterMenu = new MenuScreen ();
			pageMapScreen = new LiveMapScreen ();
			pageMapScreen.MasterPage = this;

			Title = "";

			BackgroundColor = Color.Black;

			Master = pageMasterMenu;
			Detail = pageMapScreen;

			pageMasterMenu.Menu.ItemSelected += Menu_ItemSelected;
		}

		async void Menu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			OptionItem selectedItem = e.SelectedItem as OptionItem;
			if (selectedItem == null)
				return;

			IsPresented = false;

			var displayPage = GetShowPage(selectedItem.Id);
			if (displayPage != null)
			{
				Detail = displayPage;
			}

			((ListView)sender).SelectedItem = null;
		}

		#region PRIVATE METHODS
		private ContentPage GetShowPage(int id)
		{
			ContentPage newPage = null;

			switch (id) {
			case 0: // Browse Venues
				/*newPage = new LiveMapScreen ();
				((LiveMapScreen)newPage).MasterPage = this;*/
				if (Detail is LiveMapScreen) {
					var currentPage = Detail as LiveMapScreen;
					currentPage.ShowRouteLayout ();
				}
				break;
			case 1:
				DoLogout ();
				break;
			default:
				newPage = new ContentPage ();
				break;
			}

			return newPage;
		}

		async void DoLogout()
		{
			var action = await DisplayAlert ("UniteGPS", "Are you sure you want to log out?", "OK", "Cancel");

			if (action == true && App.MainNavigator != null) {
				App.MainNavigator.Logout ();
			}
		}
		#endregion
	}
}

