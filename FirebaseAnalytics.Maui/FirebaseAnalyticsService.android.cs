#if ANDROID
using Android.OS;
using Firebase.Analytics;

namespace FirebaseAnalytics.Maui;

public class FirebaseAnalyticsService : IFirebaseAnalyticsService
{
    readonly FirebaseAnalytics _analytics;

    public FirebaseAnalyticsService()
    {
        _analytics = FirebaseAnalytics.GetInstance(Platform.CurrentActivity);
    }

    public void LogEvent(string eventName, Dictionary<string, string>? parameters = null)
    {
        var bundle = new Bundle();
        if (parameters != null)
        {
            foreach (var p in parameters)
                bundle.PutString(p.Key, p.Value);
        }
        _analytics.LogEvent(eventName, bundle);
    }

    public void LogScreenView(string screenName)
    {
        var bundle = new Bundle();
        bundle.PutString(FirebaseAnalytics.ParamScreenName, screenName);
        _analytics.LogEvent(FirebaseAnalytics.EventScreenView, bundle);
    }
}
#endif