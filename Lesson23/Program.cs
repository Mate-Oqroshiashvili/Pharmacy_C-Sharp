using Lesson21.Models;
using Lesson21.Enums;
using Lesson23.Helpers;
using Lesson23.Enums;

Pharmacy pharmacy = new Pharmacy("PSP", 100000m);

List<Medicine> medicines = new List<Medicine>
{
    new Medicine("Bayer", "Aspirin", "Pain reliever", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.PainRelief, 100, 5.50m),
    new Medicine("Pfizer", "Amoxicillin", "Antibiotic medicine", SICKNESS_LEVEL.Severe, MEDICINE_PURPOSE.Antibiotic, 150, 12.00m),
    new Medicine("Roche", "Tamiflu", "Antiviral medicine", SICKNESS_LEVEL.Severe, MEDICINE_PURPOSE.Antiviral, 50, 25.00m),
    new Medicine("Novartis", "Voltaren", "Anti-inflammatory medicine", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.AntiInflammatory, 80, 12.50m),
    new Medicine("GSK", "Zyrtec", "Allergy relief", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.AllergyRelief, 60, 8.00m),
    new Medicine("Bayer", "Paracetamol", "Fever reducer", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.FeverReduction, 200, 4.50m),
    new Medicine("Johnson", "Coldrex", "Cold and cough relief", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.CoughAndCold, 90, 9.50m),
    new Medicine("Sanofi", "Omeprazole", "Digestive health medicine", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.DigestiveHealth, 70, 11.00m),
    new Medicine("Pfizer", "Lipitor", "Cardiovascular medicine", SICKNESS_LEVEL.Critical, MEDICINE_PURPOSE.CardiovascularHealth, 40, 30.00m),
    new Medicine("Solgar", "Vitamin C", "Vitamin and mineral supplement", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.VitaminAndMineralSupplement, 120, 7.00m)
};

List<User> users = new List<User>
{
    new User("Giorgi Beridze", 25, "giorgi@gmail.com", "pass123", 100m, 85f, SICKNESS_LEVEL.Mild),
    new User("Nika Kapanadze", 30, "nika@gmail.com", "pass123", 250m, 90f, SICKNESS_LEVEL.Moderate),
    new User("Ana Maisuradze", 22, "ana@gmail.com", "pass123", 150m, 75f, SICKNESS_LEVEL.Mild),
    new User("Mariam Gelashvili", 35, "mariam@gmail.com", "pass123", 300m, 95f, SICKNESS_LEVEL.Severe),
    new User("Luka Tsiklauri", 28, "luka@gmail.com", "pass123", 200m, 80f, SICKNESS_LEVEL.Moderate),
};

List<SoldMedicine> soldMedicines = new List<SoldMedicine>
{
    new SoldMedicine("Bayer", "Aspirin", "Pain reliever", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.PainRelief, 100, 5.50m, 11.00m, 2, users[0]),
    new SoldMedicine("Pfizer", "Amoxicillin", "Antibiotic medicine", SICKNESS_LEVEL.Severe, MEDICINE_PURPOSE.Antibiotic, 150, 12.00m, 24.00m, 2, users[1]),
    new SoldMedicine("Roche", "Tamiflu", "Antiviral medicine", SICKNESS_LEVEL.Severe, MEDICINE_PURPOSE.Antiviral, 50, 25.00m, 25.00m, 1, users[2]),
    new SoldMedicine("Novartis", "Voltaren", "Anti-inflammatory medicine", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.AntiInflammatory, 80, 12.50m, 25.00m, 2, users[3]),
    new SoldMedicine("GSK", "Zyrtec", "Allergy relief", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.AllergyRelief, 60, 8.00m, 16.00m, 2, users[4]),
    new SoldMedicine("Bayer", "Paracetamol", "Fever reducer", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.FeverReduction, 200, 4.50m, 13.50m, 3, users[0]),
    new SoldMedicine("Johnson", "Coldrex", "Cold and cough relief", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.CoughAndCold, 90, 9.50m, 19.00m, 2, users[1]),
    new SoldMedicine("Sanofi", "Omeprazole", "Digestive health medicine", SICKNESS_LEVEL.Moderate, MEDICINE_PURPOSE.DigestiveHealth, 70, 11.00m, 33.00m, 3, users[2]),
    new SoldMedicine("Pfizer", "Lipitor", "Cardiovascular medicine", SICKNESS_LEVEL.Critical, MEDICINE_PURPOSE.CardiovascularHealth, 40, 30.00m, 60.00m, 2, users[3]),
    new SoldMedicine("Solgar", "Vitamin C", "Vitamin and mineral supplement", SICKNESS_LEVEL.Mild, MEDICINE_PURPOSE.VitaminAndMineralSupplement, 120, 7.00m, 35.00m, 5, users[4])
};

foreach (var medicine in medicines)
{
    if (pharmacy.Medicines.ContainsKey(medicine.SICKNESS_LEVEL))
    {
        pharmacy.Medicines
                .First(x => x.Key == medicine.SICKNESS_LEVEL)
                .Value.Add(medicine);
    }
    else
    {
        List<Medicine> newMedicines = new List<Medicine>();
        newMedicines.Add(medicine);
        pharmacy.Medicines
            .Add(medicine.SICKNESS_LEVEL, newMedicines);
    }
}

foreach (var medicine in soldMedicines)
{
    if (pharmacy.SoldMedicines.ContainsKey(medicine.SICKNESS_LEVEL))
    {

        pharmacy.SoldMedicines
                .First(x => x.Key == medicine.SICKNESS_LEVEL)
                .Value.Add(medicine);
    }
    else
    {
        List<SoldMedicine> newMedicines = new List<SoldMedicine>();
        newMedicines.Add(medicine);
        pharmacy.SoldMedicines
            .Add(medicine.SICKNESS_LEVEL, newMedicines);
    }
}

users[0].Medicines.Add(soldMedicines[0]);
users[0].Medicines.Add(soldMedicines[1]);

users[1].Medicines.Add(soldMedicines[2]);
users[1].Medicines.Add(soldMedicines[3]);

users[2].Medicines.Add(soldMedicines[4]);
users[2].Medicines.Add(soldMedicines[5]);

users[3].Medicines.Add(soldMedicines[6]);
users[3].Medicines.Add(soldMedicines[7]);

users[4].Medicines.Add(soldMedicines[8]);
users[4].Medicines.Add(soldMedicines[9]);

//FileHelper<Pharmacy>.WriteInFile(FILE_TYPES.Pharmacies, pharmacy, false);
//FileHelper<Medicine>.WriteInFile(FILE_TYPES.Medicines, medicines, false);
//FileHelper<SoldMedicine>.WriteInFile(FILE_TYPES.SoldMedicines, soldMedicines, false);
//FileHelper<User>.WriteInFile(FILE_TYPES.Users, users, false);
await JSONFileHelper<User>.WriteInFileAsync(FILE_TYPES.Users, users);

//FileHelper<Pharmacy>.ReadFromFile(FILE_TYPES.Pharmacies);
//Console.WriteLine();
//FileHelper<Medicine>.ReadFromFile(FILE_TYPES.Medicines);
//Console.WriteLine();
//FileHelper<SoldMedicine>.ReadFromFile(FILE_TYPES.SoldMedicines);
//Console.WriteLine();
//FileHelper<User>.ReadFromFile(FILE_TYPES.Users);

bool isOver = false;

do
{
    Console.WriteLine($"1. Show Medicines\n" +
                  $"2. Exit");
    int.TryParse(Console.ReadLine(), out int choice);

    switch (choice)
    {
        case 1:
            var deserializedUsers = await JSONFileHelper<User>.ReadFromFileAsync(FILE_TYPES.Users);

            foreach (var du in deserializedUsers.ToList())
            {
                Console.WriteLine(du.WriteInConsole());
            }
            continue;
        case 2:
            Console.WriteLine("Application has been successfully terminated!");
            Environment.Exit(555);
            continue;
    }

    Console.WriteLine("want to continue? (y/n)");
    char.TryParse(Console.ReadLine(), out char answer);

    if (answer == 'y')
    {
        isOver = false;
    }
    else
    {
        isOver = true;
    }
}
while (!isOver);