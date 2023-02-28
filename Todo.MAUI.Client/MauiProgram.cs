using Microsoft.Extensions.Logging;
using Todo.Client.Shared;

namespace Todo.MAUI.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddScoped<TodoClient>();
		builder.Services.AddScoped(sp =>
		{
			var client = new HttpClient();

			client.BaseAddress = new Uri("https://localhost:7123");
			client.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");

			return client;
		});

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


		return builder.Build();
	}
}