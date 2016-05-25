using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UniteGPS
{
	public class OptionItem : INotifyPropertyChanged 
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int Id{ get; set; }
		public String text;
		public String detail;

		public OptionItem()
		{
			Text = "";
			Detail = "";
		}

		public OptionItem(int id, String text, String detail)
		{
			Id = id;
			Text = text;
			Detail = detail;
		}

		public String Text {
			get{
				return text;
			}
			set{
				text = value;
				OnPropertyChanged ("Text");
			} 
		}

		public String Detail {
			get{
				return detail;
			}
			set{
				detail = value;
				OnPropertyChanged ("Detail");
			} 
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, 
					new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class MenuScreen : ContentPage
	{
		#region PUBLIC MEMBERS
		public ListView Menu { get; set; }
		#endregion

		#region PRIVATE MEMBERS
		readonly ObservableCollection<OptionItem> OptionItems = new ObservableCollection<OptionItem>();
		#endregion

		public MenuScreen ()
		{
			Title = "Menu Page";

			BackgroundColor = Color.FromRgb(0x0, 0x91, 0xd1);

			InitializeListItems();

			var LogoImage = new Image {
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("Images/UinteGps.png"),
				HeightRequest = 55,
				WidthRequest = 100,
			};

			Menu = new ListView
			{
				HasUnevenRows = true,
				ItemsSource = OptionItems,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent,
				RowHeight = 55,
			};

			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "Text");
			cell.SetBinding(TextCell.DetailProperty, "Detail");
			cell.SetValue(VisualElement.BackgroundColorProperty, Color.Transparent);
			cell.SetValue (TextCell.TextColorProperty, Color.White);

			Menu.ItemTemplate = cell;

			Content = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					new StackLayout{
						Spacing = 0,
						Padding = new Thickness(0, 10, 0, 0),
						HorizontalOptions = LayoutOptions.Start,
						Children = {
							LogoImage,
							Menu,
						}
					},
					new StackLayout{
						Padding = 0,
						Spacing = 0,
						HorizontalOptions = LayoutOptions.End,
						VerticalOptions = LayoutOptions.FillAndExpand,
						WidthRequest = 1,
						BackgroundColor = Color.FromRgb(75, 75, 75),
					}
				}
			};
		}

		private void InitializeListItems()
		{
			OptionItems.Add (new OptionItem (0, "Routes", ""));
			//OptionItems.Add (new OptionItem (1, "Logout", ""));
		}
	}
}

