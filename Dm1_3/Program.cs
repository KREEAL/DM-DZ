using System;
using System.Collections.Generic;
using System.IO;
/*Дано множество {a,b,c,d,e,f}. Построить все слова длины 5, в которых ровно одна
буква повторяется 2 раза, остальные буквы не повторяются. Вывод в файл.
- Дано множество {a, b, c, d, e, f}. Построить все слова длины 6, в которых ровно 2
буквы повторяются 2 раза, остальные буквы не повторяются. Вывод в файл.*/
namespace Dm1_3
{
    class Program
    {
        static void firstMark() 
        {
            StreamWriter sw = new StreamWriter("firstMark.txt");
            int sw0=0;
            int n = 5;
            string w = "_____";
            char[] word = w.ToCharArray();

            bool repeatable = true;
            for (char c = 'a'; c <= 'f'; c++)
            {
                for (int apos1 = 0; apos1 < n; apos1++)
                {
                    for (int apos2 = apos1 + 1; apos2 < n; apos2++)
                    {

                        word[apos1] = c;
                        word[apos2] = c;

                        int[] other = new int[3];

                        for (int i = 0, j = 0; i < n; i++)
                        {
                            if (i != apos1 && i != apos2)
                            {
                                other[j] = i;
                                j++;
                            }

                        }
                        for (char c1 = 'a'; c1 <= 'f'; c1++)
                        {
                            for (char c2 = 'a'; c2 <= 'f'; c2++)
                            {
                                for (char c3 = 'a'; c3 <= 'f'; c3++)
                                {


                                    if (c1 != c2 && c1 != c3 && c2 != c3)
                                    {
                                        if (c1 != c && c2 != c && c3 != c)
                                        {
                                            word[other[0]] = c1;
                                            word[other[1]] = c2;
                                            word[other[2]] = c3;

                                            sw.WriteLine(word);
                                            sw0++;
                                        }
                                    }

                                }
                            }
                        }

                    }

                }

            }
            sw.WriteLine(sw0);
            sw.Close();
        }
        static void secondMark() 
        {
            StreamWriter sw = new StreamWriter("secondMark.txt");
            int sw1 = 0;
            int n = 6;
            string w = "______";
            char[] word = w.ToCharArray();
            
            for (char c = 'a'; c <= 'f'; c++)
            {
                c++;
                for (char c0 = 'a'; c0 <= 'f'; c0++)
                {
                    if (c0 != c)
                    {
                        for (int apos1 = 0; apos1 < n; apos1++)
                        {
                            for (int apos2 = apos1 + 1; apos2 < n; apos2++)
                            {
                                for (int bpos1 = 0; bpos1 < n; bpos1++)
                                {
                                    for (int bpos2 = bpos1 + 1; bpos2 < n; bpos2++)
                                    {
                                        if (apos1 == bpos1 || apos1 == bpos2 || apos2 == bpos1 || apos2 == bpos2)//что позиции разные у разных букв
                                            continue;
                                        word[apos1] = c;
                                        word[apos2] = c;
                                        word[bpos1] = c0;
                                        word[bpos2] = c0;

                                        int[] other = new int[2];
                                        for (int i = 0, j = 0; i < n; i++)
                                        {
                                            if (i != apos1 && i != apos2 && i != bpos1 && i != bpos2)
                                            {
                                                other[j] = i;
                                                j++;
                                            }

                                        }

                                        for (char c1 = 'a'; c1 <= 'f'; c1++)
                                        {
                                            for (char c2 = 'a'; c2 <= 'f'; c2++)
                                            {
                                                if (c1 != c2)
                                                {
                                                    if (c1 != c && c2 != c && c1 != c0 && c2 != c0)
                                                    {
                                                        word[other[0]] = c1;
                                                        word[other[1]] = c2;
                                                        sw.WriteLine(word);
                                                        sw1++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }
                    }
                }

            }
            sw.WriteLine(sw1);
            sw.Close();
        }
        static void Main(string[] args)
        {
            firstMark();
            secondMark();
        }

    }
}
