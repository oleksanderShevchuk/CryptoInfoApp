using CryptoInfoApp.Models;
using System.Collections.ObjectModel;

namespace CryptoInfoApp.Services
{
    public interface ISearchService
    {
        ObservableCollection<Coin> SearchCoins(ObservableCollection<Coin> coins, string query);
    }
}
