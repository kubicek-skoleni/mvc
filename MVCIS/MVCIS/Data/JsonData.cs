using MVCIS.Models;
using System.Text.Json;

namespace MVCIS.Data
{
    public class JsonData
    {
        public static List<Person> LoadData(string path)
        {
            var jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(jsonString);
        }
    }
}
