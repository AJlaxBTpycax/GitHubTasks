using System;
using System.Collections.Generic;

class Program
{
    static string playerName = "Детектив";
    static int creds = 50;
    static int reputation = 0;
    static bool hasWeapon = false;
    static bool knowsTruth = false;
    static List<string> clues = new List<string>();
    static Random rand = new Random();

    static void Main()
    {
        Console.Title = "NEURO CITY: Бесконечный цикл";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║   NEURO CITY 2084            ║");
        Console.WriteLine("║   Бесконечный цикл          ║");
        Console.WriteLine("╚══════════════════════════════╝\n");
        Console.ResetColor();

        Console.Write("Введите имя детектива: ");
        playerName = Console.ReadLine();

        while (true)
        {
            Console.Clear();
            ShowStatus();
            MainHub();
        }
    }

    static void ShowStatus()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n{playerName} | CR: {creds} | REP: {reputation}");
        Console.WriteLine($"Ключи: {string.Join(", ", clues)}");
        Console.ResetColor();
    }

    static void MainHub()
    {
        ShowHeader("Главное меню");
        Console.WriteLine("1. Начать новое расследование");
        Console.WriteLine("2. Посетить черный рынок");
        Console.WriteLine("3. Проверить архив дел");
        Console.WriteLine("4. Выйти из игры");

        switch (GetChoice(1, 4))
        {
            case 1: StartInvestigation(); break;
            case 2: VisitBlackMarket(); break;
            case 3: CheckCaseFiles(); break;
            case 4: Environment.Exit(0); break;
        }
    }

    static void StartInvestigation()
    {
        int caseType = rand.Next(1, 4);
        
        switch (caseType)
        {
            case 1:
                ShowHeader("Дело #451: Пропавший курьер");
                Console.WriteLine("Корпорация 'Нео-Экспресс' нанимает вас найти пропавшего сотрудника.");
                Console.WriteLine("1. Взять дело (100CR)");
                Console.WriteLine("2. Отказаться");

                if (GetChoice(1, 2) == 1)
                {
                    creds += 100;
                    InvestigateCourier();
                }
                break;

            case 2:
                ShowHeader("Дело #327: Взлом банка данных");
                Console.WriteLine("Неизвестные взломали серверы городского архива.");
                Console.WriteLine("1. Изучить место преступления");
                Console.WriteLine("2. Проигнорировать");

                if (GetChoice(1, 2) == 1)
                {
                    InvestigateHack();
                }
                break;

            case 3:
                ShowHeader("Дело #198: Подозрительное самоубийство");
                Console.WriteLine("Офицер корпоративной безопасности найден мертвым.");
                Console.WriteLine("1. Осмотреть тело");
                Console.WriteLine("2. Закрыть дело");

                if (GetChoice(1, 2) == 1)
                {
                    InvestigateSuicide();
                }
                break;
        }
    }

    static void InvestigateCourier()
    {
        Console.WriteLine("\nВы начинаете расследование...");
        Console.WriteLine("1. Опросить коллег");
        Console.WriteLine("2. Проверить последний маршрут");

        int choice = GetChoice(1, 2);
        
        if (choice == 1)
        {
            Console.WriteLine("\nКоллеги говорят, что курьер боялся чего-то...");
            clues.Add("Курьер в страхе");
        }
        else
        {
            Console.WriteLine("\nНа маршруте обнаружены следы борьбы!");
            clues.Add("Следы борьбы");
        }

        if (rand.Next(100) > 50)
        {
            Console.WriteLine("\nВы нашли курьера живым!");
            creds += 200;
            reputation += 2;
        }
        else
        {
            Console.WriteLine("\nКурьер мертв. Дело закрыто.");
            reputation -= 1;
        }

        Console.ReadKey();
    }

    static void VisitBlackMarket()
    {
        ShowHeader("Черный рынок");
        Console.WriteLine("1. Купить оружие (200CR)");
        Console.WriteLine("2. Купить информацию (50CR)");
        Console.WriteLine("3. Продать данные (+100CR)");
        Console.WriteLine("4. Вернуться");

        int choice = GetChoice(1, 4);
        
        switch (choice)
        {
            case 1 when creds >= 200:
                creds -= 200;
                hasWeapon = true;
                Console.WriteLine("\nПриобретен кибер-пистолет!");
                break;
            case 2 when creds >= 50:
                creds -= 50;
                clues.Add("Рынок: " + rand.Next(1000, 9999).ToString());
                Console.WriteLine("\nПолучены сомнительные данные...");
                break;
            case 3:
                creds += 100;
                if (clues.Count > 0) clues.RemoveAt(0);
                Console.WriteLine("\nДанные проданы. Кто-то недоволен...");
                reputation -= 1;
                break;
        }

        Console.ReadKey();
    }

    static void CheckCaseFiles()
    {
        ShowHeader("Архив дел");
        if (clues.Count == 0)
        {
            Console.WriteLine("Нет собранных улик.");
        }
        else
        {
            Console.WriteLine("Собранные улики:");
            foreach (var clue in clues)
            {
                Console.WriteLine("- " + clue);
            }
        }
        Console.ReadKey();
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        do
        {
            Console.Write("> ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max);
        
        return choice;
    }

    static void ShowHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"\n─── {title} ───");
        Console.ResetColor();
    }
}
