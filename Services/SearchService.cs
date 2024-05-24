using CryptoInfoApp.Models;
using System.Collections.ObjectModel;

namespace CryptoInfoApp.Services
{
    public static class SearchService
    {
        public static ObservableCollection<Coin> SearchCoins(ObservableCollection<Coin> coins, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return coins;
            }

            var filteredCoins = new ObservableCollection<Coin>(
                coins.Where(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                 c.Symbol.Contains(query, StringComparison.OrdinalIgnoreCase)));

            return filteredCoins;
        }
    }
}
