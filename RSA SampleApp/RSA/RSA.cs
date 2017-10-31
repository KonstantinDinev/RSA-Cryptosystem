using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class RSA : Program
    {
        private int P, Q; // Secret Parameters
        private int N;    // Not secret Parameter
        private int fN;   // Oiler's function - Secret Parameter
 
        public RSA()
        {
            //Console.SetWindowSize(80, 65);
            Console.Write("P = ");
            P = TryToParse("");
            PrimeNumber(P);
            Console.Write("Q = ");
            Q = TryToParse("");
            PrimeNumber(Q);

            if (flag == 2)
            {
                //Actual code goes here ;)
                N = P * Q;
                Console.WriteLine("\nN = P * Q\nN = {0} * {1}\nN = {2}\n", P, Q, N);
                // Oiler's function
                fN = (P - 1) * (Q - 1);
                Console.WriteLine("Ойлерова функция:\nф(N) = (P - 1) * (Q - 1)\nф(N) = {0} * {1}\nф(N) = {2}", P - 1, Q - 1, fN);
                GlobalfN = fN;

                int Ko;
                // Евклид (Най-голям общ делител!)
                int commonDivider = 0;

                do
                {
                    Console.Write("\nВъведете открития ключ Ко = ");
                    Ko = TryToParse("");

                    if (Ko <= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("По условие Ко трябва да е по-голямо от 1 !");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        KoRestart(Ko, commonDivider, fN);
                    }

                    if ((Ko >= fN))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("По условие Ко трябва да е по-малко от ф(N) !");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        //force exit (Environment.Exit(0) v extEuclid
                        KoRestart(Ko, commonDivider, fN); 
                    }

                    commonDivider = VzaimnoProsti(Ko, fN);
                    if (commonDivider == 1)
                    {
                        Console.WriteLine("Ko и ф(N) са взаимно прости!");
                        // Продължаваме действията на програмата във вложения цикъл!
                        // *******************************************************//
                        // Алгоритъм на Евклид за разлагане (Разширен алгоритъм)

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nРазширен алгоритъм на Евклид! (BackTrack algorithm!)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        for (int i = 0; i < fN; i++)
                        {
                            //Ако сменим нещо тук или в последната усл. конструкция, небето ще падне отгоре..
                            for (int j = 0; j < fN; j++) 
                            {
                                if ((Ko * i) + j == fN)
                                {
                                    // Условие от лекциите, което да принтира последната възможна комбинация
                                    if (j < Ko) 
                                    {
                                        Console.WriteLine("ф(N){3} = {0} * {1} + {2}", Ko, i, j, fN);
                                        int a = Ko;
                                        int jj = 0; int jjTemp = 0;

                                        //Разлагане на 2-ро ниво и т.н.
                                        do
                                        {
                                            //int jj = 0;
                                            for (int ii = 0; ii < a; ii++)
                                            {
                                                for (jj = 0; jj < a; jj++)
                                                {
                                                    if (j * ii + jj == a)
                                                    {
                                                        //needs to be updated.. j>jj
                                                        if (j >= jj)
                                                        {
                                                            if ((j == 1) && (jj == 1)) { Console.WriteLine("ф(N){3} = {0} * {1} + {2}", j, ii = a, jj = 0, a); break; }
                                                            Console.WriteLine("ф(N){3} = {0} * {1} + {2}", j, ii, jj, a);
                                                            //следващо събираемо
                                                            jjTemp = jj; 
                                                        }
                                                    }
                                                }
                                            }

                                            a = j; //следващ множител
                                            j = jjTemp;

                                        } while (a != 1);  //Усл. за спиране
                                        if (a == 1) break; //Закърпено
                                    }
                                }
                            }
                        }

                        Console.WriteLine("\nНатиснете Ентер, за да продължите алгоритъма на Евклид!");
                        Console.ReadKey();
                        //backtrack here
                        GCD(fN, Ko);

                    }
                    else
                    {
                        Console.WriteLine("Ко и ф(N) не са взаимно прости! Техен най-голям общ делител е {0}", commonDivider);
                        //restart Ko entering
                        Console.WriteLine("\n\nЗа да продължите напред Ko и ф(N) трябва да са взаимно прости!");
                        Console.WriteLine("Натиснете, който и да е бутон, за да продължите и въвете Ко отново!...\n");
                        Console.ReadKey();
                        KoRestart(Ko, commonDivider, fN);
                    }

                } while ((Ko <= 1) || (Ko >= fN));
                // Условие: 1 < Ko < ф(N) и (Ко, ф(N))=1  "while((Ko > 1) && (Ko > fN));"

            }
            else
            {
                Console.WriteLine("\n\nНеобходими са две прости числа, за продължаване напред!");
                Console.WriteLine("През, който и да е бутон да въведете числата отново!...\n");
                Console.ReadKey();
                Restart();
            }

            Console.ReadKey();
        }

        static public void Restart()
        {
            flag = 0;
            RSA cryptoSys = new RSA();
        }



        private void KoRestart(int Ko, int commonDivider, int fN)
        {
            //Евклид (Най-голям общ делител!)
            commonDivider = 0;

            do
            {
                Console.Write("\nВъведете открития ключ Ко = ");
                Ko = TryToParse("");

                if (Ko <= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("По условие Ко трябва да е по-голямо от 1 !");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    KoRestart(Ko, commonDivider, fN);
                }

                if ((Ko >= fN))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("По условие Ко трябва да е по-малко от ф(N) !");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    KoRestart(Ko, commonDivider, fN);
                }

                commonDivider = VzaimnoProsti(Ko, fN);
                if (commonDivider == 1)
                {
                    Console.WriteLine("Ko и ф(N) са взаимно прости!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nРазширен алгоритъм на Евклид! (BackTrack algorithm!)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    for (int i = 0; i < fN; i++)
                    {
                        for (int j = 0; j < fN; j++)
                        {
                            if ((Ko * i) + j == fN)
                            {
                                if (j < Ko)
                                {
                                    Console.WriteLine("ф(N){3} = {0} * {1} + {2}", Ko, i, j, fN);
                                    int a = Ko;
                                    int jj = 0; int jjTemp = 0;
                                    do
                                    {
                                        for (int ii = 0; ii < a; ii++)
                                        {
                                            for (jj = 0; jj < a; jj++)
                                            {
                                                if (j * ii + jj == a)
                                                {
                                                    if (j >= jj)
                                                    {
                                                        if ((j == 1) && (jj == 1)) { Console.WriteLine("ф(N){3} = {0} * {1} + {2}", j, ii = a, jj = 0, a); break; }
                                                        Console.WriteLine("ф(N){3} = {0} * {1} + {2}", j, ii, jj, a);
                                                        jjTemp = jj;
                                                    }
                                                }
                                            }
                                        }
                                        a = j;
                                        j = jjTemp;
                                    } while (a != 1);
                                    if (a == 1) break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("\nНатиснете Ентер, за да продължите алгоритъма на Евклид!");
                    Console.ReadKey();
                    GCD(fN, Ko);
                }
                else
                {
                    Console.WriteLine("Ко и ф(N) не са взаимно прости! Техен най-голям общ делител е {0}", commonDivider);
                    //restart Ko entering
                    Console.WriteLine("\n\nЗа да продължим напред Ko и ф(N) трябва да са взаимно прости!");
                    Console.WriteLine("Натиснете, който и да е бутон, за да продължим и въведем Ко отново!...\n");
                    Console.ReadKey();
                    KoRestart(Ko, commonDivider, fN);
                }
            } while ((Ko <= 1) || (Ko >= fN));
        }

    }
}
