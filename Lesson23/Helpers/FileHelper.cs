using Lesson23.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson23.Helpers
{
    internal static class FileHelper<T>
    {
        private static readonly string[] _paths = new string[]
        {
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Medicines.txt",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Pharmacies.txt",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\SoldMedicines.txt",
            @"C:\Users\Mate_Okroshiashvili\Desktop\pharmacy\Users.txt",
        };

        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, T entity, bool append = true)
        {
            using (StreamWriter writer = new StreamWriter(
                _paths[Convert.ToInt32(fileType)], append: append))
            {
                writer.WriteLine(entity);
            }
        }

        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, IEnumerable<T> values, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(
                _paths[Convert.ToInt32(fileType)], append: append))
            {
                foreach (T entity in values) 
                {
                    writer.WriteLine(entity);
                }
            }
        }
        public static async Task WriteInFileAsync(
            FILE_TYPES fileType, IEnumerable<KeyValuePair<int, T>> values, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(
                _paths[Convert.ToInt32(fileType)], append: append))
            {
                foreach (KeyValuePair<int, T> entity in values) 
                {
                    writer.WriteLine(entity.Value);
                }
            }
        }
        public static async Task<IEnumerable<string[]>> ReadFromFileAsync(FILE_TYPES fileType)
        {
            IEnumerable<string[]> values = new List<string[]>();

            using (StreamReader reader = new StreamReader(
                _paths[Convert.ToInt32(fileType)]))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    values = values.Append(line.Split("|"));
                }
            }

            return values;
        }
    }
}
