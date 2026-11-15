using Lesson21.Enums;
using Lesson23.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson21.Models
{
    internal class Pharmacy : IGeneralInterface
    {
        public int Id { get; set; }
        public string PharmacyName { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public SortedList<SICKNESS_LEVEL, List<Medicine>> Medicines = new SortedList<SICKNESS_LEVEL, List<Medicine>>();
        public SortedList<SICKNESS_LEVEL, List<SoldMedicine>> SoldMedicines = new SortedList<SICKNESS_LEVEL, List<SoldMedicine>>();
        public static int PharmacyCount { get; set; }

        public Pharmacy(string pharmacyName, decimal budget)
        {
            PharmacyCount++;
            Id = PharmacyCount;
            PharmacyName = pharmacyName;
            Budget = budget;
        }

        // ShowAllMedicines
        public async Task ShowAllMedicines()
        {
            try
            {
                if (!Medicines.Any())
                    throw new Exception("No Medicines Found in Pharmacy!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<Medicine>> medicines in Medicines)
                {
                    foreach (Medicine medicine in medicines.Value)
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ShowMedicinesByPurpose
        public async Task ShowMedicinesByPurpose(MEDICINE_PURPOSE purpose)
        {
            try
            {
                if (!Medicines.Any())
                    throw new Exception("No Medicines Found in Pharmacy!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<Medicine>> medicines in Medicines)
                {
                    foreach (Medicine medicine in medicines.Value
                        .Where(m => m.MEDICINE_PURPOSE == purpose))
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ShowMedicineBySicknessLevel
        public async Task ShowMedicineBySicknessLevel(SICKNESS_LEVEL sl)
        {
            try
            {
                if (!Medicines.Any())
                    throw new Exception("No Medicines Found in Pharmacy!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<Medicine>> medicines in Medicines)
                {
                    foreach (Medicine medicine in medicines.Value
                        .Where(m => m.SICKNESS_LEVEL == sl))
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ShowAllSoldMedicines
        public async Task ShowAllSoldMedicines()
        {
            try
            {
                if (!SoldMedicines.Any())
                    throw new Exception("No Medicines Are Sold!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<SoldMedicine>> medicines in SoldMedicines)
                {
                    foreach (SoldMedicine medicine in medicines.Value)
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ShowSoldMedicinesByPurpose
        public async Task ShowSoldMedicinesByPurpose(MEDICINE_PURPOSE purpose)
        {
            try
            {
                if (!SoldMedicines.Any())
                    throw new Exception("No Medicines Are Sold!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<SoldMedicine>> medicines in SoldMedicines)
                {
                    foreach (SoldMedicine medicine in medicines.Value
                        .Where(m => m.MEDICINE_PURPOSE == purpose))
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ShowSoldMedicineBySicknessLevel
        public async Task ShowSoldMedicineBySicknessLevel(SICKNESS_LEVEL sl)
        {
            try
            {
                if (!SoldMedicines.Any())
                    throw new Exception("No Medicines Are Sold!");

                foreach (KeyValuePair<SICKNESS_LEVEL, List<SoldMedicine>> medicines in SoldMedicines)
                {
                    foreach (SoldMedicine medicine in medicines.Value
                        .Where(m => m.SICKNESS_LEVEL == sl))
                    {
                        Console.WriteLine($"{medicines.Key}: {medicine.WriteInConsole()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return $"{Id}|{PharmacyName}|{Budget}";
        }

        public string WriteInConsole()
        {
            return $"[{Id}] - {PharmacyName}, Budget: {Budget}.";
        }
    }
}
