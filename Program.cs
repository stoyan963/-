using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string password = "";
        string filePath = "pass.dat";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Меню ===");
            Console.WriteLine("1. Генерирай парола");
            Console.WriteLine("2. Покажи паролата");
            Console.WriteLine("3. Запиши в файл");
            Console.WriteLine("4. Зареди от файл");
            Console.WriteLine("5. Изход");
            Console.Write("Избор: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    password = GeneratePassword(12);
                    Console.WriteLine("Паролата е генерирана!");
                    break;
                case "2":
                    Console.WriteLine("Паролата: " + password);
                    break;
                case "3":
                    string encrypted = Encrypt(password);
                    File.WriteAllText(filePath, encrypted);
                    Console.WriteLine("Записано!");
                    break;
                case "4":
                    if (File.Exists(filePath))
                    {
                        string enc = File.ReadAllText(filePath);
                        password = Decrypt(enc);
                        Console.WriteLine("Заредено!");
                    }
                    else Console.WriteLine("Няма файл.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Невалиден избор.");
                    break;
            }

            Console.WriteLine("\nНатисни Enter...");
            Console.ReadLine();
        }
    }

    static string GeneratePassword(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%";
        Random rand = new Random();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++)
            sb.Append(chars[rand.Next(chars.Length)]);
        return sb.ToString();
    }

    static string Encrypt(string text)
    {
        char key = 'X';
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
            sb.Append((char)(c ^ key)); // XOR криптиране
        return sb.ToString();
    }

    static string Decrypt(string text) => Encrypt(text); // XOR работи и в двете посоки
}
