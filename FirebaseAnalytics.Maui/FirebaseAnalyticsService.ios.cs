#if IOS
using Firebase.Analytics;
using Foundation;

namespace FirebaseAnalytics.Maui;

public class FirebaseAnalyticsService : IFirebaseAnalyticsService
{
    public void LogEvent(string eventName, Dictionary<string, string>? parameters = null)
    {
        var dict = new NSMutableDictionary();
        if (parameters != null)
        {
            foreach (var p in parameters)
                dict.SetValueForKey(new NSString(p.Value), new NSString(p.Key));
        }
        Analytics.LogEvent(eventName, dict);
    }

    public void LogScreenView(string screenName)
    {
        Analytics.LogEvent(Analytics.EventScreenView, NSDictionary.FromObjectAndKey(
            new NSString(screenName), Analytics.ParameterScreenName
        ));
    }
}
#endif