using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DellyShopApp.Helpers
{
    public class Settings
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static string SelectLanguage
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectLanguage), string.Empty); 
            set => AppSettings.AddOrUpdateValue(nameof(SelectLanguage), value); 
        }
    }
}