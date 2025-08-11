#if !(ANDROID || IOS)
namespace FirebaseAnalytics.Maui;

public class FirebaseAnalyticsService : IFirebaseAnalyticsService
{
    public void LogEvent(string eventName, Dictionary<string, string>? parameters = null) { }
    
    public void LogScreenView(string screenName) { }
}
#endif