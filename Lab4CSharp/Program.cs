using System;

namespace Lab4CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ТЕСТУВАННЯ ЛАБОРАТОРНОЇ РОБОТИ №4 (Варіант 6) ===\n");

            // --- Завдання 1.6 ---
            Console.WriteLine("--- ЗАВДАННЯ 1: Клас DRomb ---");
            DRomb romb = new DRomb(10, 10, 1); // d1=10, d2=10, колір=1
            Console.WriteLine((string)romb);
            Console.WriteLine($"Індекс 0 (d1): {romb[0]}");

            romb++;
            Console.WriteLine($"Після інкременту (++): {(string)romb}");

            if (romb) Console.WriteLine("Перевірка true/false: Це квадрат (діагоналі рівні)!");
            else Console.WriteLine("Перевірка true/false: Це не квадрат.");

            // --- Завдання 2.6 ---
            Console.WriteLine("\n--- ЗАВДАННЯ 2: Клас VectorULong ---");
            VectorULong v1 = new VectorULong(3, 5);
            VectorULong v2 = new VectorULong(3, 2);

            Console.Write("Вектор 1: ");
            v1.Output();
            Console.Write("Вектор 2: ");
            v2.Output();

            VectorULong v3 = v1 + v2;
            Console.Write("Результат v1 + v2: ");
            v3.Output();

            // --- Завдання 3.6 ---
            Task3.RunTask();

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}