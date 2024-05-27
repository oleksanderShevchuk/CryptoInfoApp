namespace CryptoInfoApp.Data
{
    public static class ChartRangeConstants
    {
        public const string OneDay = "1d";
        public const string SevenDays = "7d";
        public const string OneMonth = "1m";
        public const string OneYear = "1y";

        public static readonly List<string> All = new List<string> { OneDay, SevenDays, OneMonth, OneYear };
    }
}
