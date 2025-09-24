// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Пожалуйста, введите текст (минимум 100 символов):");
        string userInput = Console.ReadLine();

        if (string.IsNullOrEmpty(userInput) || userInput.Length < 100)
        {
            Console.WriteLine($"Ошибка! Вы ввели только {userInput?.Length ?? 0} символов. Нужно минимум 100 символов.");
            return;
        }
        Console.WriteLine($"Отлично! Вы ввели {userInput.Length} символов.");
        Console.WriteLine("Текст принят для дальнейшей обработки.");
    }
}