using Microsoft.AspNetCore.Components.WebView.Maui;
using CW.Data;
using MudBlazor.Services;
using CW.Services;
using Microsoft.Extensions.Logging;

namespace CW;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddMudServices();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
	
		
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<IUserService, UserService>();

		return builder.Build();
	}
}
