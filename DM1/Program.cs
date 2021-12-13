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
            StreamWriter sw1 = new StreamWriter("res1.txt");//файл для перестановок

            n = 5;
            bool[] used = new bool[n];
            for (int i = 0; i < n; i++)
                a.Add(i);
            Perestanovki(0,used,l,sw1);
            sw1.Close();
        }
    }
}
