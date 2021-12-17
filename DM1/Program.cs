using System;
using System.Collections.Generic;
using System.IO;

namespace DM1
{
    class Program

    {
        public static int n;
        public static int m;

        //сочетания_без_повторений
        public static bool NextSetBezPovtorenii(ref int[] a, int n, int m)
        {
            int k = m;
            for (int i = k - 1; i >= 0; --i)
                if (a[i] < n - k + i + 1)
                {
                    ++a[i];
                    for (int j = i + 1; j < k; ++j)
                        a[j] = a[j - 1] + 1;
                    return true;
                }
            return false;
        }
        public static void PrintSochetanije(ref int[] a, int n,StreamWriter sw)
        {
            int num = 1;
            for (int i = 0; i < n; i++)
                sw.Write(a[i]+" ");
            sw.WriteLine();
        }
        //Сочетания с повторением
        public static bool NextSetSPovtoreniem(ref int[] a, int h, int m)
        {
            int j = m - 1;
            while (j >= 0 &&  a[j] == h) j--;


            if (j < 0) return false;

            if (a[j] >= h)
                j--;
            a[j]++;
            if (j == m - 1) return true;
            for (int k = j + 1; k < m; k++)
                a[k] = a[j];
            return true;
        }


        //Все перестановки
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

            /*сочетание без повторений*/
            StreamWriter sw3 = new StreamWriter("SochetanieBezPovtorov.txt");
            m = 3;
            int[] mass = new int[n];
            a.CopyTo(mass);
            if(n >= m)
            {
                while (NextSetBezPovtorenii(ref mass, n, m))
                    PrintSochetanije(ref mass, m,sw3);
            }

            sw3.Close();

            /*Сочетание с повторениями*/
            StreamWriter sw4 = new StreamWriter("SochetanieSPovtoreniem.txt");
            int h = Math.Max(n, m); // размер массива а выбирается как max(n,m)
            int[] mass2 = new int[h];
            a.CopyTo(mass2);
            Console.WriteLine(mass2.Length);
            foreach (int i in mass2)
                Console.WriteLine(i);
            for (int i = 0; i < h; i++)
                mass2[i] = 1;
            while (NextSetSPovtoreniem(ref mass2, n,m))
                PrintSochetanije(ref mass2, m,sw4);
            sw4.Close();

            /*Размещения без повторений*/
            StreamWriter sw5 = new StreamWriter("RacmeshenijeBezPovtorov");


        }
    }
}
