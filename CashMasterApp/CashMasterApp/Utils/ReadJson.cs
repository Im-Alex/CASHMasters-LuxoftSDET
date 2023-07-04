using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CashMasterApp.Utils
{
    /// <summary>
    /// Provides methods to read denominations from a JSON file.
    /// </summary>
    public class ReadJson
    {
        private Dictionary<string, List<decimal>> _denominations;
        private string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadJson"/> class with the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the JSON file.</param>
        public ReadJson(string filePath)
        {
            _filePath = filePath;
            LoadDenominations();
        }
        private void LoadDenominations()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                var jsonData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<decimal>>>>(json);

                if (jsonData.ContainsKey("Denominaciones"))
                {
                    _denominations = jsonData["Denominaciones"];
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"{_filePath} not found");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to load file {e.Message}");
            }
        }
        /// <summary>
        /// Retrieves the denominations for the specified country.
        /// </summary>
        /// <param name="country">The country code.</param>
        /// <returns>A list of denominations for the country.</returns>

        public List<decimal> GetDenominationFromCountry(string country) {
            try
            {
                if (_denominations != null && _denominations.ContainsKey(country))
                {
                    return _denominations[country];
                }
                
            }catch(FileNotFoundException)
            {
                Console.WriteLine("Not found");
            }
            return new List<decimal>();
        }


    }
}
