using System;
using System.Collections.Generic;
using System.IO;

namespace DM1
{
    class Program
    { //Все перестановки
        public static int n;
        static void Perestanovki(int k,bool[] used,Stack<int> l,StreamWriter sw) //k-длина
        {
            if (k == n)
            {
                foreach (int i in l)
                {
                    
                    sw.Write(i);
                }

                sw.WriteLine("");
               return;
        }
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;     //Добавляем в текущую перестановку элемент a[i]
                    l.Push(i);
                    Perestanovki(k + 1,used,l,sw);           //Рекурсивно перебираем все перестановки, продолжающиеся a[i]
                    l.Pop();
                    used[i] = false;    //Убираем из текущей перестановки элемент a[i]
                }
            }
        }
        static void Main(string[] args)
        {
            Stack<int> l = new Stack<int>();//стек для перестановок
            SortedSet<int> a = new SortedSet<int>();


            n = 5;

            /* перестановки */
            StreamWriter sw1 = new StreamWriter("perestanovki.txt");//файл для перестановок

            bool[] used = new bool[n];
            for (int i = 0; i < n; i++)
                a.Add(i);
            Perestanovki(0,used,l,sw1);
            sw1.Close();

            /* булеан  */
            //сделано через двоичные последовательности
            StreamWriter sw2 = new StreamWriter("bulean.txt");

            List<int> buleanL = new List<int>(a);// перевел в лист для удобства работы с [i]
            int count = (int)(Math.Pow(2, n) - 1);
            var sets = new string[count];
            for (int n = 1; n <= count; n++)
            {
                var s = "";

                var tmp = n;
                for (var i = 0; tmp > 0; i++)
                {
                    int reminder;
                    tmp = Math.DivRem(tmp, 2, out reminder);
                    if (reminder > 0)
                        s += buleanL[i] + ",";
                }
                s = s.Substring(0, s.Length - 1);
                sets[n - 1] = s;
            }
            Array.Sort(sets);
            sw2.WriteLine(string.Join("\n", sets));
            sw2.Close();

        }
    }
}
