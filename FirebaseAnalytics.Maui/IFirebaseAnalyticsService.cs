namespace FirebaseAnalytics.Maui;

public interface IFirebaseAnalyticsService
{
    void LogEvent(string eventName, Dictionary<string, string>? parameters = null);
    
    void LogScreenView(string screenName);
}