namespace CitiesGame.Core.Helpers
{
    public static class WordNormalizer
    {
        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input
                .Trim()
                .ToLower()
                .Replace('ё', 'е');
        }

        public static List<char> GetPossibleMoveLetters(string city)
        {
            var result = new List<char>();
            var normalized = Normalize(city);

            for (int i = normalized.Length - 1; i >= 0; i--)
            {
                char ch = normalized[i];

                if (ch != 'ь' && ch != 'ъ' && ch != 'ы')
                {
                    result.Add(ch);
                }
            }

            return result;
        }
    }
}