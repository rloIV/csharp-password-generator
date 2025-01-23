using System;
using System.Text;

namespace PasswordGeneratorAppV2
{
    /// <summary>
    /// Represents the settings for password generation.
    /// </summary>
    class Password
    {
        public int PasswordLength { get; set; } = 8;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSpecialCharacters { get; set; } = false;

        public override string ToString()
        {
            return $"Current Settings:\n" +
                   $"- Password Length: {PasswordLength}\n" +
                   $"- Include Uppercase Letters: {(IncludeUppercase ? "Yes" : "No")}\n" +
                   $"- Include Lowercase Letters: {(IncludeLowercase ? "Yes" : "No")}\n" +
                   $"- Include Numbers: {(IncludeNumbers ? "Yes" : "No")}\n" +
                   $"- Include Special Characters: {(IncludeSpecialCharacters ? "Yes" : "No")}\n";
        }
    }
    /// <summary>
    /// Main program for generating passwords.
    /// </summary>
    internal class Program
    {
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()_+=-{}[]<>?";

        static int GetPasswordLength()
        {
            Console.Write("Enter password length (1-64): ");
            int passwordLength;
            while (!int.TryParse(Console.ReadLine(), out passwordLength) || passwordLength <= 0 || passwordLength > 64)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 64.");
            }
            return passwordLength;
        }

        static bool GetUserPreference(string question)
        {
            Console.Write($"{question} (y/n): ");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return choice == 'y' || choice == 'Y';
        }

        static string AssessPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (ContainsCharacterFromSet(password, SmallLetters)) score++;
            if (ContainsCharacterFromSet(password, CapitalLetters)) score++;
            if (ContainsCharacterFromSet(password, Numbers)) score++;
            if (ContainsCharacterFromSet(password, SpecialCharacters)) score++;

            return score switch
            {
                >= 5 => "Strong",
                3 or 4 => "Medium",
                _ => "Weak",
            };
        }

        static bool ContainsCharacterFromSet(string input, string characterSet)
        {
            foreach (var ch in input)
            {
                if (characterSet.Contains(ch)) return true;
            }
            return false;
        }

        static string GeneratePassword(Password settings)
        {
            var characterPool = new StringBuilder();

            if (settings.IncludeLowercase) characterPool.Append(SmallLetters);
            if (settings.IncludeUppercase) characterPool.Append(CapitalLetters);
            if (settings.IncludeNumbers) characterPool.Append(Numbers);
            if (settings.IncludeSpecialCharacters) characterPool.Append(SpecialCharacters);

            if (characterPool.Length == 0)
            {
                throw new InvalidOperationException("No character types selected for password generation.");
            }

            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < settings.PasswordLength; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }

            return password.ToString();
        }

        static void Main(string[] args)
        {
            Console.Clear();
            var settings = new Password();

            while (true)
            {
                Console.WriteLine("\nPassword Generator Program V2");
                Console.WriteLine(settings); // Display current settings
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Change password length");
                Console.WriteLine("2. Configure password components");
                Console.WriteLine("3. Generate password and check strength");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(settings);
                        Console.WriteLine("Change Password Length:");
                        settings.PasswordLength = GetPasswordLength();
                        Console.WriteLine($"New password length is: {settings.PasswordLength}. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine(settings);
                        Console.WriteLine("Configure Password Components:");
                        settings.IncludeUppercase = GetUserPreference("Include uppercase letters?");
                        settings.IncludeLowercase = GetUserPreference("Include lowercase letters?");
                        settings.IncludeNumbers = GetUserPreference("Include numbers?");
                        settings.IncludeSpecialCharacters = GetUserPreference("Include special characters?");
                        Console.WriteLine("Password components updated. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Generating password...");
                            string password = GeneratePassword(settings);
                            string strength = AssessPasswordStrength(password);
                            Console.WriteLine($"Generated Password: {password}");
                            Console.WriteLine($"Password Strength: {strength}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select an option from the menu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
