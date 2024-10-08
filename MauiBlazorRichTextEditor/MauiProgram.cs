﻿using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using Syncfusion.Maui.Core.Hosting;

namespace MauiBlazorRichTextEditor
{
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

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddSyncfusionBlazor();
            builder.ConfigureSyncfusionCore();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ViewModel>();
            builder.Services.AddSingleton<App>();
            return builder.Build();
        }
    }
}
