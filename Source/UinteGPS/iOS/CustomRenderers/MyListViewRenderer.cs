using System;
using Xamarin.Forms;
using UniteGPS;
using UniteGPS.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly:ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]
namespace UniteGPS.iOS
{
	public class MyListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			try
			{
				base.OnElementChanged (e);

				if (Control == null)
					return;

				var tableView = Control as UITableView;
				tableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}

