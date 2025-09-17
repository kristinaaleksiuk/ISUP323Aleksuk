// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public Expense(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Name}; {Amount} руб.";
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Expense> expenses = new List<Expense>();
        int operationCount;

        Console.WriteLine("Введите количество операций (от 2 до 40):");
        while (!int.TryParse(Console.ReadLine(), out operationCount) || operationCount < 2 || operationCount > 40)
        {
            Console.WriteLine("Ошибка! Введите число от 2 до 40:");
        }

        for (int i = 0; i < operationCount; i++)
        {
            Console.WriteLine($"Введите траты (Название услуги или товара; Количество денег):");
            string input = Console.ReadLine();
            var parts = input.Split(';');

            if (parts.Length != 2 || !decimal.TryParse(parts[1], out decimal amount))
            {
                Console.WriteLine("Ошибка! Неверный формат ввода.");
                i--; // Повторяем итерацию
                continue;
            }

            expenses.Add(new Expense(parts[0].Trim(), amount));
        }

        int choice;
        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Сортировка по цене");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт меню: ");

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка! Введите корректный номер пункта меню.");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nДанные о тратах:");
                    foreach (var expense in expenses)
                    {
                        Console.WriteLine(expense);
                    }
                    break;

                case 2:
                    if (expenses.Count > 0)
                    {
                        var total = expenses.Sum(e => e.Amount);
                        var average = expenses.Average(e => e.Amount);
                        var max = expenses.Max(e => e.Amount);
                        var min = expenses.Min(e => e.Amount);

                        Console.WriteLine($"\nСумма: {total} руб.");
                        Console.WriteLine($"Среднее: {average} руб.");
                        Console.WriteLine($"Максимальная трата: {max} руб.");
                        Console.WriteLine($"Минимальная трата: {min} руб.");
                    }
                    else
                    {
                        Console.WriteLine("Нет данных для статистики.");
                    }
                    break;

                case 3:
                    expenses.Sort((x, y) => x.Amount.CompareTo(y.Amount));
                    Console.WriteLine("\nТраты отсортированы по цене.");
                    break;

                case 4:
                    Console.WriteLine("Введите курс конвертации (1 руб. = ? валюты):");
                    if (decimal.TryParse(Console.ReadLine(), out decimal rate))
                    {
                        foreach (var expense in expenses)
                        {
                            var convertedAmount = expense.Amount * rate;
                            Console.WriteLine($"{expense.Name}: {convertedAmount} в другой валюте.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Неверный формат курса.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Введите название для поиска:");
                    string searchTerm = Console.ReadLine().ToLower();
                    var foundExpenses = expenses.Where(e => e.Name.ToLower().Contains(searchTerm)).ToList();

                    if (foundExpenses.Count > 0)
                    {
                        Console.WriteLine("\nРезультаты поиска:");
                        foreach (var expense in foundExpenses)
                        {
                            Console.WriteLine(expense);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ничего не найдено.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        } while (choice != 0);
    }
}