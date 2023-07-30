using Android.App;
using Android.Runtime;

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
namespace CW;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
     //  await CheckInternet();
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    private async void CheckInternet()
    {
        var hasInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        var internetType = Connectivity.Current.ConnectionProfiles.FirstOrDefault();

        await App.Current.MainPage.DisplayAlert("Internet", $"Status : {hasInternet} of type {internetType}", "OK");
    }
}
