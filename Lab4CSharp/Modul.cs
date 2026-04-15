using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4CSharp
{
    // ==========================================
    // ЗАВДАННЯ 1.6: Клас DRomb (Ромб)
    // ==========================================
    public class DRomb
    {
        protected int d1, d2;
        protected int c; // колір
        protected double a; // сторона

        public DRomb(int d1, int d2, int color)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.c = color;
            this.a = Math.Sqrt(Math.Pow(d1 / 2.0, 2) + Math.Pow(d2 / 2.0, 2));
        }

        public int D1
        {
            get { return d1; }
            set { d1 = value; a = Math.Sqrt(Math.Pow(d1 / 2.0, 2) + Math.Pow(d2 / 2.0, 2)); }
        }

        public int D2
        {
            get { return d2; }
            set { d2 = value; a = Math.Sqrt(Math.Pow(d1 / 2.0, 2) + Math.Pow(d2 / 2.0, 2)); }
        }

        public int Color
        {
            get { return c; }
        }

        // Індексатор
        public object this[int index]
        {
            get
            {
                if (index == 0) return d1;
                if (index == 1) return d2;
                if (index == 2) return c;
                throw new Exception("Неприпустиме значення індексу.");
            }
            set
            {
                if (index == 0) D1 = Convert.ToInt32(value);
                else if (index == 1) D2 = Convert.ToInt32(value);
                else if (index == 2) c = Convert.ToInt32(value);
                else throw new Exception("Неприпустиме значення індексу.");
            }
        }

        // Перевантаження операторів
        public static DRomb operator ++(DRomb r)
        {
            r.a++;
            r.d1++;
            return r;
        }

        public static DRomb operator --(DRomb r)
        {
            r.a--;
            r.d1--;
            return r;
        }

        public static bool operator true(DRomb r) => r.IsSquare();
        public static bool operator false(DRomb r) => !r.IsSquare();

        public static DRomb operator +(DRomb r, int scalar)
        {
            return new DRomb(r.d1 + scalar, r.d2 + scalar, r.c);
        }

        public static implicit operator string(DRomb r)
        {
            return $"DRomb(a={r.a:F2}, d1={r.d1}, d2={r.d2}, колір={r.c})";
        }

        public static explicit operator DRomb(string s)
        {
            string[] parts = s.Split(',');
            if (parts.Length == 3 &&
                int.TryParse(parts[0], out int diag1) &&
                int.TryParse(parts[1], out int diag2) &&
                int.TryParse(parts[2], out int col))
            {
                return new DRomb(diag1, diag2, col);
            }
            throw new Exception("Невірний формат рядка. Очікується 'd1,d2,color'");
        }

        // Методи
        public double Area() => (d1 * d2) / 2.0;
        public double Perimeter() => 4 * a;
        public bool IsSquare() => d1 == d2;

        public void ShowFullInfo()
        {
            Console.WriteLine($"[Колір: {Color}] Сторона: {a:F2} | Діагоналі ({d1}, {d2}) | Площа: {Area():F1} | Периметр: {Perimeter():F1} | Квадрат: {(IsSquare() ? "Так" : "Ні")}");
        }
    }

    // ==========================================
    // ЗАВДАННЯ 2.6: Клас VectorULong
    // ==========================================
    public class VectorULong
    {
        protected ulong[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vec = 0;

        public VectorULong(uint size, ulong initValue)
        {
            this.size = size;
            IntArray = new ulong[size];
            for (int i = 0; i < size; i++) IntArray[i] = initValue;
            num_vec++;
        }

        public void Output()
        {
            Console.WriteLine(string.Join(", ", IntArray));
        }

        public ulong this[uint index]
        {
            get
            {
                if (index >= size) { codeError = -1; return 0; }
                codeError = 0;
                return IntArray[index];
            }
            set
            {
                if (index >= size) codeError = -1;
                else
                {
                    codeError = 0;
                    IntArray[index] = value;
                }
            }
        }

        public static VectorULong operator +(VectorULong v1, VectorULong v2)
        {
            uint maxSize = Math.Max(v1.size, v2.size);
            VectorULong res = new VectorULong(maxSize, 0);
            for (uint i = 0; i < maxSize; i++)
            {
                ulong val1 = i < v1.size ? v1[i] : 0;
                ulong val2 = i < v2.size ? v2[i] : 0;
                res[i] = val1 + val2;
            }
            return res;
        }
    }

    // ==========================================
    // ЗАВДАННЯ 3.6: Школяр
    // ==========================================
    public struct SchoolboyStruct
    {
        public string PIB;
        public int ClassNum;
        public string Phone;
        public int[] Grades;

        public bool HasTwo() => Grades.Contains(2);
        public override string ToString() => $"{PIB}, Клас: {ClassNum}, Оцінки: [{string.Join(",", Grades)}]";
    }

    
    public record SchoolboyRecord(string PIB, int ClassNum, string Phone, int[] Grades)
    {
        public bool HasTwo() => Grades.Contains(2);
        public override string ToString() => $"{PIB}, Клас: {ClassNum}, Оцінки: [{string.Join(",", Grades)}]";
    }

    public class Task3
    {
        public static void RunTask()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 3: РОБОТА ЗІ ШКОЛЯРАМИ ---");

            // Варіант 1: Структури
            List<SchoolboyStruct> structList = new List<SchoolboyStruct>
            {
                new SchoolboyStruct { PIB = "Іванов І.І.", ClassNum = 10, Phone = "111", Grades = new[] { 5, 4, 5, 5 } },
                new SchoolboyStruct { PIB = "Петров П.П.", ClassNum = 9, Phone = "222", Grades = new[] { 3, 2, 4, 3 } }
            };

            structList.RemoveAll(s => s.HasTwo());
            structList.Insert(0, new SchoolboyStruct { PIB = "Новий Учень (Struct)", ClassNum = 5, Phone = "000", Grades = new[] { 5, 5, 5, 5 } });

            Console.WriteLine("Результат (Структури):");
            structList.ForEach(s => Console.WriteLine(s.ToString()));

            // Варіант 2: Кортежі
            List<(string PIB, int ClassNum, string Phone, int[] Grades)> tupleList = new()
            {
                ("Іванов І.І.", 10, "111", new[] { 5, 4, 5, 5 }),
                ("Петров П.П.", 9, "222", new[] { 3, 2, 4, 3 })
            };

            tupleList.RemoveAll(t => t.Grades.Contains(2));
            tupleList.Insert(0, ("Новий Учень (Tuple)", 5, "000", new[] { 5, 5, 5, 5 }));

            Console.WriteLine("\nРезультат (Кортежі):");
            tupleList.ForEach(t => Console.WriteLine($"{t.PIB}, Клас: {t.ClassNum}, Оцінки: [{string.Join(",", t.Grades)}]"));

            // Варіант 3: Записи (Records)
            List<SchoolboyRecord> recordList = new List<SchoolboyRecord>
            {
                new SchoolboyRecord("Іванов І.І.", 10, "111", new[] { 5, 4, 5, 5 }),
                new SchoolboyRecord("Петров П.П.", 9, "222", new[] { 3, 2, 4, 3 })
            };

            recordList.RemoveAll(r => r.HasTwo());
            recordList.Insert(0, new SchoolboyRecord("Новий Учень (Record)", 5, "000", new[] { 5, 5, 5, 5 }));

            Console.WriteLine("\nРезультат (Записи):");
            recordList.ForEach(r => Console.WriteLine(r.ToString()));
        }
    }
}