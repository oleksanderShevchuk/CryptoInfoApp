using CryptoInfoApp.Helpers;
using CryptoInfoApp.Services;
using CryptoInfoApp.ViewModels;
using CryptoInfoApp.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoInfoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var cryptoService = new CoinGeckoService();
            DataContext = new MainViewModel(cryptoService);

            MainView.Navigate(new MainView { DataContext = DataContext });
        }
        private void SwitchLightThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri($"Themes/Light.xaml", UriKind.Relative));
        }
        private void SwitchDarkThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri($"Themes/Dark.xaml", UriKind.Relative));
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void LanguageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ComboBoxItem? selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null && selectedItem.Tag != null)
                {
                    string? selectedLanguage = selectedItem.Tag.ToString();
                    LanguageHelper.ChangeLanguage(selectedLanguage);
                }
            }
        }
    }
}