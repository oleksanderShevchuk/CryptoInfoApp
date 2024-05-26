using CryptoInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoInfoApp.Components
{
    /// <summary>
    /// Interaction logic for TableCoins.xaml
    /// </summary>
    public partial class TableCoins : UserControl
    {
        public TableCoins()
        {
            InitializeComponent();
        }
        public ObservableCollection<Coin> Coins
        {
            get { return (ObservableCollection<Coin>)GetValue(CoinsProperty); }
            set { SetValue(CoinsProperty, value); }
        }

        public static readonly DependencyProperty CoinsProperty =
            DependencyProperty.Register("Coins", typeof(ObservableCollection<Coin>), typeof(TableCoins), new PropertyMetadata(null));
    }
}
