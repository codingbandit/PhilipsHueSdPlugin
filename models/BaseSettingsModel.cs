namespace PhilipsHueSdPlugin.Models
{
    public class BaseSettingsModel
    {
        public string hueHubIp { get; set; } = string.Empty;
        public string appUserId { get; set; } = string.Empty;
        public virtual bool IsValid()
        {
            return !(string.IsNullOrWhiteSpace(hueHubIp) || string.IsNullOrWhiteSpace(appUserId));
        }

    }
}