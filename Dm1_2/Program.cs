using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Дано множество {a,b,c,d,e,f} построить все слова длины 5 в которых ровно две буквы а
//а остальные повторяются/ не повторяются
namespace narot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = 5;
            string w = "_____";
            char[] word = w.ToCharArray();

            StreamWriter swF = new StreamWriter("nonRepeatable.txt");
            int swt = 0, swf = 0;
            StreamWriter swT = new StreamWriter("Repeateble.txt");

            bool repeatable = false;

            for (int apos1 = 0; apos1 < n; apos1++)
            {
                for (int apos2 = apos1 + 1; apos2 < n; apos2++)
                {

                    word[apos1] = 'a';
                    word[apos2] = 'a';

                    int[] other = new int[3];

                    for (int i = 0, j = 0; i < n; i++)
                    {
                        if (i != apos1 && i != apos2)
                        {
                            other[j] = i;
                            j++;
                        }

                    }

                    for (char c1 = 'b'; c1 <= 'f'; c1++)
                    {
                        for (char c2 = 'b'; c2 <= 'f'; c2++)
                        {
                            for (char c3 = 'b'; c3 <= 'f'; c3++)
                            {

                                //if (repeatable)
                                //{
                                    word[other[0]] = c1;
                                    word[other[1]] = c2;
                                    word[other[2]] = c3;
                                    swT.WriteLine(word);
                                    swt++;
                                    //Console.WriteLine(word);
                                    //list.Add(word.ToString());
                                //}
                                //else
                                //{
                                    if (c1 != c2 && c1 != c3 && c2 != c3)
                                    {
                                        word[other[0]] = c1;
                                        word[other[1]] = c2;
                                        word[other[2]] = c3;
                                        swF.WriteLine(word);
                                        swf++;
                                        //Console.WriteLine(word);
                                        //list.Add(word.ToString());
                                    }
                                //}

                            }
                        }
                    }

                }

            }
            swF.WriteLine(swf);
            swT.WriteLine(swt);
            swF.Close();
            swT.Close();
            Console.WriteLine(list.Count);
        }
       
    }
}