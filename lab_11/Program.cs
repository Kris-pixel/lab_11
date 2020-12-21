using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace lab_11
{
    class Program
    {
        public class Abiturient
        {
            public string lastName;
            public string name;
            public string adres;
            public int phNumber;
            public int[] marks;
            public const string uO = "BSTU";
            public static int amout;

            public Abiturient(string ln, string n, string a, int tel)
            {
                lastName = ln;
                name = n;
                adres = a;
                phNumber = tel;
                marks = new int[13];
                Random rnd = new Random();
                for (int i = 0; i < marks.Length; i++)
                {
                    marks[i] = rnd.Next(0, 10);
                }
                amout++;
            }

            public void Info()
            {
                Console.WriteLine($"Имя:{name}");
                Console.WriteLine($"Фамилия: {lastName}");
                Console.WriteLine($"Учреждение образования:{uO}");
                Console.WriteLine($"Адрес: {adres}");
                Console.WriteLine($"Телефон: {phNumber}");
                foreach (int mark in marks)
                    Console.Write(mark + "; ");
                Console.WriteLine(" \n ");
            }

            public void MiddleScore(out double midScore)
            {
                int sum = 0;
                for (int i = 0; i < marks.Length; i++)
                {
                    sum += marks[i];
                }
                midScore = sum / marks.Length;
            }
            public (int, int) MinMax(ref int min, ref int max)
            {
                Array.Sort(marks);
                min = marks[0];
                max = marks[marks.Length - 1];
                return (min, max);
            }

            public int TotalScore()
            {
                int sum = 0;
                foreach (int mark in marks)
                    sum += mark;
                return sum;
            }
        }
        static void Main(string[] args)
        {
            string[] month = { "September", "October", "November", "December", "January", "February", "March", "April", "May", "June", "Julay", "August" };

            var month4 = from i in month
                         where i.Length == 5
                         select i;

            foreach (var a in month)
                Console.Write(a + " ");

            Console.WriteLine(" \n");
            Console.WriteLine("Месяцы из 5 букв");
            foreach( var a in month4)
                Console.Write(a+" ");
            Console.WriteLine(" \n");

            Console.WriteLine("Зимние и летние месяцы");
            var sumwint = month.Skip(3).Take(3).Concat(month.Skip(9).Take(3)) ;
            foreach (var x in sumwint)
                Console.Write(x + " ");
            Console.WriteLine(" \n");

            Console.WriteLine("Мессяцы по алфавиту");
            var alpha = from i in month
                        orderby i
                        select i;
            foreach (var x in alpha)
                Console.Write(x + " ");
            Console.WriteLine(" \n");

            Console.WriteLine("Сколько месяцев содержащих букву u и не менее 4 букв?");
            var u4 = (from i in month
                     where i.Contains("u") && i.Length >= 4
                     select i).Count();
            Console.WriteLine(u4);
            Console.WriteLine("");


            List<Abiturient> Abits = new List<Abiturient>();
            Abiturient abs = new Abiturient("Фэирчаилд", "Клэри", "Ленина 29", 9083432);
            Abiturient abs1 = new Abiturient("Лайтвуд", "Александр", "Свердлова 9?", 239587);
            Abiturient abs2 = new Abiturient("Лайтвуд", "Изабель",  "Ленина 12.", 1846372);
            Abiturient abs3 = new Abiturient("Эрондейл", "Джейс", "Ленина 24", 00264738);
            Abiturient abs4 = new Abiturient("Моргенштерн", "Себастьян", "Немига 4.", 94536275);
            Abiturient abs5 = new Abiturient("Пенхаллоу", "Алина", "Сансетстрит 76?", 39536275);
            Abiturient abs6 = new Abiturient("Бейн", "Магнус", "Некифорова 444", 64057985);
            Abits.Add(abs);
            Abits.Add(abs1);
            Abits.Add(abs2);
            Abits.Add(abs3);
            Abits.Add(abs4);
            Abits.Add(abs5);
            Abits.Add(abs6);

            /*количество строк длины n и т*/
            Console.WriteLine("количество строк длины n и m");
            int n = 5;
            int m = 7;
            var linstr = (from a in Abits
                         where a.name.Length <= n && a.lastName.Length > m
                         select a).Count();
            Console.WriteLine(linstr);
            Console.WriteLine(" ");

            /*список строк, которые содержат заданное слово*/
            var th = "д";
            Console.WriteLine($"список строк, которые содержат {th}");
            var contD = Abits.Where(x => x.lastName.Contains(th));
            foreach (var a in contD)
                Console.WriteLine(a.lastName);
            Console.WriteLine(" ");


            /*Максимальную строку*/
            Console.WriteLine("Максимальные строки");
            var maxstr =Abits.Max(x => x.name).Concat(Abits.Max(x=>x.lastName).Concat(Abits.Max(x=>x.adres)));
            foreach (var x in maxstr)
                Console.Write(x+" ");
            Console.WriteLine("");

            /*Первую строку, содержащую точку или ?*/
            Console.WriteLine("Первая скрока, содержащая . или ?");
            var vopros =(from a in Abits
                       where a.adres.Contains("?") || a.adres.Contains(".")
                       select a.adres)
                       .First();
            Console.WriteLine(vopros);
            Console.WriteLine("");

            /*Последнюю строку с самым коротким словом*/
            Console.WriteLine("Последняя строка с самым коротким словом");
            var lasts = Abits.Min(x => x.lastName);
            Console.WriteLine(lasts) ;
            Console.WriteLine("");

            /*Упорядоченный массив по первому слову*/
            Console.WriteLine("Упорядоченный массив по первому слову");
            var order = (from a in Abits
                        orderby a.name
                        select a.name).ToArray();
            foreach (var x in order)
               Console.WriteLine( x);
            Console.WriteLine("");

            /*4. Придумайте и напишите свой собственный запрос, в котором было
            бы не менее 5 операторов из разных категорий: условия, проекций,
            упорядочивания, группировки, агрегирования, кванторов и разиения.*/
            Console.WriteLine("5 операций");
            var smth = (from a in Abits
                        where a.lastName.Contains("д")
                        orderby a.name
                        select a.name)
                        .Skip(1)
                        .Take(2)
                        .Reverse();
            foreach (var x in smth)
                Console.WriteLine(x);
            Console.WriteLine("");

            /*5. Придумайте запрос с оператором Join*/
            Console.WriteLine("запрос с оператором Join");
            int[] key = { 4, 5, 6, 7, 10 };
            var jtyt = Abits.Join(key,
                x => x.name.Length,
                q => q,
                (x, q) => new
                {
                    id = string.Format("{0}",q),
                    x.name,
                });
            foreach (var x in jtyt)
                Console.WriteLine(x);
            Console.WriteLine("");
        }
    }
}
