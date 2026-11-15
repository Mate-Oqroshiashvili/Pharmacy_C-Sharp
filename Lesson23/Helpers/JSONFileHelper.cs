using Lesson23.Enums;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Lesson23.Helpers
{
    internal static class JSONFileHelper<T>
    {
        private static readonly string[] _paths = new string[]
        {
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Medicines.json",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Pharmacies.json",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\SoldMedicines.json",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Users.json",
        };

        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
        };

        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, T entity)
        {
            try
            {
                var serialized = JsonSerializer.Serialize(entity, _options);
                await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileType)], serialized);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, IEnumerable<T> values)
        {
            try
            {
                var serialized = JsonSerializer.Serialize(values, _options);
                await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileType)], serialized);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, IEnumerable<KeyValuePair<int, T>> values)
        {
            try
            {
                var serialized = JsonSerializer.Serialize(values, _options);
                await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileType)], serialized);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task<IEnumerable<T>> ReadFromFileAsync(FILE_TYPES fileType)
        {
            try
            {
                string text = await File.ReadAllTextAsync(_paths[Convert.ToInt32(fileType)]);

                var deserialized = JsonSerializer
                    .Deserialize<IEnumerable<T>>(text, _options);

                return deserialized ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>();
            }
        }
    }
}
