using System.Globalization;
using System.Windows.Markup;
using System.Windows;

namespace CryptoInfoApp.Helpers
{
    public static class LanguageHelper
    {
        public static event EventHandler<string>? LanguageChanged;

        public static void ChangeLanguage(string? lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            ResourceDictionary dict = new ResourceDictionary();
            switch (lang)
            {
                case "uk":
                    dict.Source = new Uri("Resources/Localization/Strings.uk.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Resources/Localization/Strings.en.xaml", UriKind.Relative);
                    break;
            }

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);

            foreach (Window window in Application.Current.Windows)
            {
                if (window is FrameworkElement frameworkElement)
                {
                    frameworkElement.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
                }
            }
            OnLanguageChanged(lang);
        }

        private static void OnLanguageChanged(string lang)
        {
            LanguageChanged?.Invoke(null, lang);
        }
    }
}
