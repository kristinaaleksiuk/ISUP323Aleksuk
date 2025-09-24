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
        string text = "Это пример текста с несколькими словами";

        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string shortest = words[0];

        foreach (string word in words)
        {
            if (word.Length < shortest.Length)
                shortest = word;
        }
        Console.WriteLine($"Самое короткое слово: '{shortest}'");
        string predlo = "Первое предложение. Второе! Третье?";
        // Предложения
        int sentences = text.Split('.', '!', '?')
                           .Count(s => !string.IsNullOrWhiteSpace(s));
        // Буквы
        char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'a', 'e', 'i', 'o', 'u' };
        int vowelCount = text.ToLower().Count(c => vowels.Contains(c));
        int consonantCount = text.ToLower().Count(c => char.IsLetter(c) && !vowels.Contains(c));

        Console.WriteLine($"Предложения: {sentences}");
        Console.WriteLine($"Гласные: {vowelCount}, Согласные: {consonantCount}");

        string longest = words[0];

        foreach (string word in words)
        {
            if (word.Length > longest.Length)
                longest = word;
        }
        Console.WriteLine($"Самое длинное слово: '{longest}' (длина: {longest.Length})");

        string textchaast = "Пример текста для анализа частоты букв";

        // Статистика частотности букв
        var letterFrequency = text.ToLower()
                                 .Where(char.IsLetter)
                                 .GroupBy(c => c)
                                 .ToDictionary(g => g.Key, g => g.Count())
                                 .OrderByDescending(pair => pair.Value);

        // Вывод результатов
        foreach (var pair in letterFrequency)
        {
            Console.WriteLine($"Буква '{pair.Key}': {pair.Value} раз");
            var top = text.ToLower()
                            .Where(char.IsLetter)
                            .GroupBy(c => c)
                            .OrderByDescending(g => g.Count())
                            .Take(5);

            Console.WriteLine("Топ-5 букв:");
            foreach (var group in top)
                Console.WriteLine($"  '{group.Key}': {group.Count()} раз");
        }
    }
}

