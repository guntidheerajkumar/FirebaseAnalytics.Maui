# FirebaseAnalytics.Maui

A cross-platform **Firebase Analytics** service for **.NET MAUI Blazor** apps. Easily log analytics events and screen views from your Blazor pages with minimal setup.

-----

## 📦 Installation

1.  **Add NuGet package** to your MAUI Blazor project:

    ```bash
    dotnet add package FirebaseAnalytics.Maui
    ```

2.  Add Firebase configuration files:

      * **Android** → Place `google-services.json` in `Platforms/Android/`
      * **iOS** → Place `GoogleService-Info.plist` in `Platforms/iOS/`

3.  Enable Firebase Analytics in your Firebase Console.

-----

## ⚙️ Setup

In your `MauiProgram.cs` file, register the Firebase Analytics service:

```csharp
using FirebaseAnalytics.Maui;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register Firebase Analytics service
        builder.Services.AddFirebaseAnalytics();

        return builder.Build();
    }
}
```

-----

## 🚀 Usage

### Log a Custom Event

You can inject the `IFirebaseAnalyticsService` to log custom events anywhere in your Blazor pages.

```razor
@page "/"
@inject IFirebaseAnalyticsService Analytics

<h3>Home</h3>
<button @onclick="TrackEvent">Log Purchase</button>

@code {
    void TrackEvent()
    {
        Analytics.LogEvent("purchase", new()
        {
            { "item_id", "123" },
            { "price", "19.99" }
        });
    }
}
```

-----

### Log a Screen View

To manually log a screen view, inject the service and call `LogScreenView`.

```razor
@page "/product"
@inject IFirebaseAnalyticsService Analytics

<h3>Product Page</h3>

@code {
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            Analytics.LogScreenView("Product Page");
        }
    }
}
```

-----

### 🔄 Automatic Screen Tracking (Optional)

For automatic page navigation tracking, you can inject `NavigationManager` and subscribe to the `LocationChanged` event.

```razor
@inject NavigationManager Nav
@inject IFirebaseAnalyticsService Analytics

@code {
    protected override void OnInitialized()
    {
        Nav.LocationChanged += (s, e) =>
        {
            var pageName = Nav.Uri.Split('/').LastOrDefault() ?? "Home";
            Analytics.LogScreenView(pageName);
        };
    }
}
```

-----

## 📌 Notes

  * This package supports **Android** and **iOS**.
  * Other platforms use a **no-op implementation**, ensuring your code compiles everywhere without errors.
  * The `LogEvent` parameters map directly to **Firebase custom event parameters**.
  * Firebase will **batch and send events automatically** in the background.
