using CitiesGame.Core.Helpers;

namespace CitiesGame.Core.Services
{
    public class CityDictionary
    {
        private readonly HashSet<string> _cities = new();

        public int Count => _cities.Count;

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл со списком городов не найден.", path);

            var lines = File.ReadAllLines(path);

            _cities.Clear();

            foreach (var line in lines)
            {
                var city = WordNormalizer.Normalize(line);

                if (!string.IsNullOrWhiteSpace(city))
                {
                    _cities.Add(city);
                }
            }
        }

        public bool Contains(string cityName)
        {
            return _cities.Contains(WordNormalizer.Normalize(cityName));
        }

        public IEnumerable<string> GetAll()
        {
            return _cities.OrderBy(x => x);
        }

        public IEnumerable<string> GetCitiesByLetter(char letter)
        {
            char lowerLetter = char.ToLower(letter);
            return _cities.Where(c => c.StartsWith(lowerLetter));
        }

        public bool HasUnusedCitiesByLetter(char letter, IEnumerable<string> usedCities)
        {
            char lowerLetter = char.ToLower(letter);
            return _cities.Any(c => c.StartsWith(lowerLetter) && !usedCities.Contains(c));
        }
    }
}