using Lesson21.Enums;
using Lesson23.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson21.Models
{
    internal class SoldMedicine : Medicine, IGeneralInterface
    {
        public decimal PriceToPay { get; set; }
        public int MedicineQuantityToBuy { get; set; }
        public User User { get; set; }

        public SoldMedicine(string medicineManufacturer, string medicineName, 
            string medicineDescription, SICKNESS_LEVEL sicknessLevel, 
            MEDICINE_PURPOSE medicinePurpose, int medicineQuantity, decimal price,
            decimal priceToPay, int medicineQuantityToBuy, User user) 
            : base(medicineManufacturer, medicineName, medicineDescription, 
                  sicknessLevel, medicinePurpose, medicineQuantity, price)
        {
            PriceToPay = priceToPay;
            MedicineQuantityToBuy = medicineQuantityToBuy;
            User = user;
        }

        public override string ToString()
        {
            return $"{Id}|{MedicineManufacturer}|{MedicineName}|" +
                $"{MEDICINE_PURPOSE.ToString()}|{MedicineQuantity}|{Price}|{PriceToPay}|{MedicineQuantityToBuy}";
        }

        public new string WriteInConsole()
        {
            return $"[{Id}] - {MedicineManufacturer}, {MedicineName}, {MEDICINE_PURPOSE.ToString()}" +
                $"{MedicineQuantity}, Price To Pay: {PriceToPay}, Medicine Quantity To Buy: {MedicineQuantityToBuy}.";
        }
    }
}
