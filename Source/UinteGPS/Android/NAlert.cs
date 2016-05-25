using Android.App;
using Android.Content;
using Android.Net;

namespace UniteGPS.Android
{
	public class NAlert
	{
		public static ProgressDialog LoadingDialog;
		//Activity _context;

        public static void ShowLoadingDialog(Context context,string message="Loading...")
        {
            if (LoadingDialog != null && LoadingDialog.IsShowing)
            {
                LoadingDialog.Dismiss();
            }

            LoadingDialog = ProgressDialog.Show(context, "", message, true);
			LoadingDialog.IncrementProgressBy (100);
        }

        public static void HideLoadingDialog()
        {
            if (LoadingDialog != null && LoadingDialog.IsShowing)
            {
                LoadingDialog.Dismiss();
            }
        }
		public static void NetworkAlert(Context context)
		{
			var builder = new AlertDialog.Builder(context);
			builder.SetTitle("UniteGPS");
			builder.SetMessage("Check your connection and try again").SetCancelable(false).SetPositiveButton("Ok", delegate {});
				builder.Show();
		}

		public static void ShowAlert (Context context, string title, string message)
		{
			var alert = new AlertDialog.Builder (context);
			alert.SetTitle (title);
			alert.SetMessage (message);
			alert.SetPositiveButton ("OK", delegate {
			});
			alert.SetCancelable (false);
			alert.Show ();
		}
	}
}