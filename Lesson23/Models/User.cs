using Lesson21.Enums;
using Lesson23.Exceptions;
using Lesson23.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lesson21.Models
{
    internal class User : IGeneralInterface
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        private string _password = string.Empty;
        public string Password 
        {
            get
            {
                return _password;
            }
            private set
            {
                _password = value;
            }
        }
        public int Age { get; set; }
        public decimal Balance { get; set; }
        public float Score { get; set; }
        public SICKNESS_LEVEL SicknessLevel { get; set; }
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public static int UserCount { get; set; }
        public USER_ROLE USER_ROLE { get; set; } = USER_ROLE.REGULAR;

        public User(string fullname, int age, string email, string password, 
            decimal balance, float score, SICKNESS_LEVEL sicknessLevel)
        {
            UserCount++;
            Id = UserCount;
            Fullname = fullname;
            Age = age;
            Email = email;
            Password = password;
            Balance = balance;
            Score = score;
            SicknessLevel = sicknessLevel;
        }

        // ChangePassword
        public async Task<bool> ChangePassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password) || password.Length < 8 ||
                   !password.Any(c => char.IsDigit(c) && char.IsUpper(c)
                   && char.IsSymbol(c)))
                {
                    throw new InvalidPasswordException("Password should be " +
                        "minimum 8 symbols and should contain one digit, " +
                        "one symbol and one uppercase letter!");
                }

                Password = password;
                Console.WriteLine("Password Changed Successfully!");
                return true;
            }
            catch(InvalidPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // DepositBalance
        public async Task<bool> DepositBalance(decimal amount)
        {
            try
            {
                if(amount <= 0)
                {
                    throw new InvalidValueException("Amount should be more than zero!");
                }

                Balance += amount;
                Console.WriteLine($"{amount:C}₾ has been deposited successfully!");
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

        // ChangeSicknessLevel
        public async Task ChangeSicknessLevel(SICKNESS_LEVEL sl)
        {
            SicknessLevel = sl;
            Console.WriteLine("Sickness level changed successfully!");
        }

        // TransferScoresToBalance
        public async Task<bool> TransferScoresToBalance()
        {
            try
            {
                if(Score < 100)
                {
                    throw new InvalidValueException("Score should be atleast 100 to be transfered to balance!");
                }

                decimal amountToBeTransfered = (decimal)Score / 100;
                Balance += amountToBeTransfered;
                Console.WriteLine($"Scores has been transfered to balance! Current Balance: {Balance}. Current Score: {Score}");
                return true;
            }
            catch(InvalidValueException ex)
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

        public override string ToString()
        {
            return $"{Id}|{Fullname}|{Age}|{Score}|{SicknessLevel.ToString()}";
        }

        public string WriteInConsole()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n");

            foreach (var item in Medicines) 
            {
                sb.Append($"    {item.WriteInConsole()}\n");
            }

            return $"[{Id}] - {Fullname}, Age: {Age}, Score: {Score}, Sickness Level: {SicknessLevel.ToString()}. {sb.ToString()}";
        }
    }
}
