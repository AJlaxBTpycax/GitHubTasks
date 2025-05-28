namespace Task1
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Сложение (+)");
            Console.WriteLine("2. Вычитание (-)");
            Console.WriteLine("3. Умножение (*)");
            Console.WriteLine("4. Деление (/)");
            Console.WriteLine("5. Остаток от деления (%)");
            Console.WriteLine("6. Инкремент (++)");
            Console.WriteLine("7. Декремент (--)");

            Console.Write("Выберите операцию (введите номер или символ): ");
            string operation = Console.ReadLine()?.Trim();

            Console.Write("Введите первое число: ");
            double num1 = double.Parse(Console.ReadLine());

            double num2 = 0;
            bool isUnary = operation == "6" || operation == "++" || 
                          operation == "7" || operation == "--";

            if (!isUnary)
            {
                Console.Write("Введите второе число: ");
                num2 = double.Parse(Console.ReadLine());
            }

            double result = Calculate(operation, num1, num2, out bool error);

            if (error)
                Console.WriteLine("Ошибка: деление на ноль!");
            else if (operation != null)
                Console.WriteLine($"Результат: {result}");

            Console.ReadKey();
        }

        static double Calculate(string operation, double num1, double num2, out bool error)
        {
            error = false;

            switch (operation?.ToLower())
            {
                case "1":
                case "+":
                    return num1 + num2;
                case "2":
                case "-":
                    return num1 - num2;
                case "3":
                case "*":
                    return num1 * num2;
                case "4":
                case "/":
                    if (num2 == 0)
                    {
                        error = true;
                        return 0;
                    }
                    return num1 / num2;
                case "5":
                case "%":
                    return num1 % num2;
                case "6":
                case "++":
                    return num1 + 1;
                case "7":
                case "--":
                    return num1 - 1;
                default:
                    Console.WriteLine("Неверная операция!");
                    return 0;
            }
        }
    }
}
