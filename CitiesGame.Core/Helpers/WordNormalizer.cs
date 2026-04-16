namespace CitiesGame.Core.Helpers
{
    public static class WordNormalizer
    {
        private static readonly HashSet<char> IgnoredLetters = new() { 'ь', 'ъ', 'ы', 'й' };

        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input
                .Trim()
                .ToLower()
                .Replace('ё', 'е');
        }

        public static IEnumerable<char> GetPossibleMoveLetters(string city)
        {
            var normalized = Normalize(city);

            for (int i = normalized.Length - 1; i >= 0; i--)
            {
                char ch = normalized[i];

                if (!IgnoredLetters.Contains(ch))
                    yield return ch;
            }
        }
    }
}