namespace VertigoGames.General.Runtime.Scripts.Utility
{
    public static class StringAbbreviationHelper
    {
        public static string ToAbbreviatedText(this int amount)
        {
            return amount switch
            {
                < 1000 => amount.ToString(),
                < 1_000_000 => (amount / 1000f).ToString("0.#") + "K",
                < 1_000_000_000 => (amount / 1_000_000f).ToString("0.#") + "M",
                _ => (amount / 1_000_000_000f).ToString("0.#") + "B"
            };
        }
    }
}