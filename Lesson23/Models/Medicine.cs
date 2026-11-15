using Lesson21.Enums;
using Lesson23.Exceptions;
using Lesson23.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson21.Models
{
    internal class Medicine : IGeneralInterface
    {
        public int Id { get; set; }
        public string MedicineManufacturer { get; set; } = string.Empty;
        public string MedicineName { get; set; } = string.Empty;
        public string MedicineDescription { get; set;} = string.Empty;
        public SICKNESS_LEVEL SICKNESS_LEVEL { get; set; }
        public MEDICINE_PURPOSE MEDICINE_PURPOSE { get; set; }
        public int MedicineQuantity { get; set; } = 1;
        public decimal Price { get; set; }
        public static int MedicineCount { get; set; }

        public Medicine(string medicineManufacturer, string medicineName, string medicineDescription,
            SICKNESS_LEVEL sickness_Level, MEDICINE_PURPOSE medicine_Purpose, int medicineQuantity,
            decimal price)
        {
            MedicineCount++;
            Id = MedicineCount;
            MedicineManufacturer = medicineManufacturer;
            MedicineName = medicineName;
            MedicineDescription = medicineDescription;
            SICKNESS_LEVEL = sickness_Level;
            MEDICINE_PURPOSE = medicine_Purpose;
            MedicineQuantity = medicineQuantity;
            Price = price;
        }

        // ChangePrice
        public async Task<bool> ChangePriceAsync(decimal newPrice)
        {
            try
            {
                if (newPrice <= 0)
                {
                    throw new InvalidValueException("Price should be more than zero!");
                }

                Price = newPrice;
                Console.WriteLine("Price has been changed successfully!");
                return true;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"{ex.Message}, {ex.ThrownAt}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // ChangeQuantity
        public async Task<bool> ChangeQuantity(int quantity) 
        {
            try
            {
                if(quantity <= 0)
                {
                    throw new InvalidValueException("Quantity should be more than zero!");
                }

                MedicineQuantity = quantity;
                Console.WriteLine("Quantity has been changed successfully");
                return true;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"{ex.Message}, {ex.ThrownAt}");
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Id}|{MedicineManufacturer}|{MedicineName}|" +
                $"{MEDICINE_PURPOSE}|{MedicineQuantity}|{Price}";
        }

        public string WriteInConsole()
        {
            return $"[{Id}] - {MedicineManufacturer}, {MedicineName}, {MEDICINE_PURPOSE.ToString()}" +
                $"{MedicineQuantity}, Price: {Price}.";
        }
    }
}
