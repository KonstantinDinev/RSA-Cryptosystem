using System;
using System.Collections.Generic;
using System.Text;

namespace RSA
{
    class Program
    {
        //global
        protected static int flag = 0;
        protected static int GlobalfN = 0;

        static void Main(string[] args)
        {
            Signature();
            RSA cryptoSys = new RSA();
        }

        protected static int TryToParse(string value)
        {
            int parseNumber;
            value = Console.ReadLine();
            bool result = Int32.TryParse(value, out parseNumber);
            if (result)
            {
                Console.WriteLine("Въвеждането на число {0} е успешно!", parseNumber);
            }
            else
            {
                if (value == null) value = "";
                Console.Write("Въведената стойност {0} не отговаря на типа данни...\nВъведете отново! = ", value);
                
                RSA.Restart();
            }
            return Math.Abs(parseNumber);
        }

        protected static int PrimeNumber(int number)
        {
            int cnt = 0;
            for(int i = 2; i < number; i++)
                if(number % i == 0) cnt++;
            Console.Write("Числото {0} е ", number);
            if (cnt == 0)
            {
                Console.Write("просто число!\n");
                flag = flag + 1;    
            }
            else
            {
                Console.Write("съставно\n");
            }
            return number;
        }

        protected static int VzaimnoProsti(int number1, int number2)
        {
            //Търсим най-голям общ делител
            //Докато разликата между двете числа е по-малка или по-голяма от 0
            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 -= number2;
                }
                else
                {
                    // Ако (M>N) M=M-N; else N=N-M; за да са равностойни
                    number2 -= number1;
                }
            }//while
            return number1; //Връща най-големия общ делител
        }


        unsafe protected static int GCD(int a, int b) //GCD
        {
            long d, x, y;

            int r;
            if (a < 0) a = -a; Console.WriteLine("\nф(N)=> a = {0}", a);
            if (b < 0) b = -b; Console.WriteLine("Ko ==> b = {0}", b);
            if (b > a)
            { /* swap */
                r = b; b = a; a = r;
            }
            Console.WriteLine("");
            while (b > 0)
            {
                //vry6tane na algorityma! :D :D :D :D
                extended_euclid(a, b, &x, &y, &d);
                r = a % b;
                a = b;
                b = r;
                //Console.WriteLine("a = {0}", a);
                Console.WriteLine("");
                //extended_euclid(a, b, &x, &y, &d);
            }

            return a;
        }


        unsafe public static void extended_euclid(long a, long b, long* x, long* y, long* d)
        /* Калкулира * *x + b * *y = gcd(a, b) = *d */
        {
            long q, r, x1, x2, y1, y2;
            if (b == 0)
            {
                *d = a; 
                *x = 1;
                *y = 0;
                return;
            }
            x2 = 1;
            x1 = 0;
            y2 = 0;
            y1 = 1;
            while (b > 0)
            {
                q = a / b;
                r = a - q * b; Console.WriteLine("r = a - q * b --- {0} = {1} - {2} * {3}", r, a, q, b);
                *x = x2 - q * x1;
                *y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = *x;
                y2 = y1;
                y1 = *y;
            }
            *d = a;
            *x = x2; Console.WriteLine("\n   A = {0}", *x);
            *y = y2; Console.WriteLine("   B = {0}", *y);

            //Извеждам секретния ключ Кс ;)
            if (*y < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   Kc = {0}\n", GlobalfN + *y);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   Kc = {0}\n", *y);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //End ;)
            Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("Поздравления! Вие върнахте успешно разширения алгоритъм на Евклид!");
            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;

            //Exit from the program! Press any button..
            Console.ReadKey();
            //ako maxna tozi red 6te prodylja razlaganeto do krai
            Environment.Exit(0);

        }

        private static void Signature()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            
Console.WriteLine("                                                                              "); Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine(" -----------------------------------------------------------------------------"); Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine(" +ThisProgramIsMadeByMe:           Constantine                  Dinev-        ");
Console.WriteLine(" yyyyyyyyyyyyyyyyyyyyyyy+.     `yyyyyyyyyyyysss+:`           .yyyh:syyy.      ");
Console.WriteLine(" yyyyyyyyyyyyyyyyyyyyyyyyy/  /yyyyyCyrillusyssyyyy+`        `yysyyyyyyys      ");
Console.WriteLine(" yyyyysyyyyysssssssyyyyyyyy-.yyyyyyyyyysssyoyysyyyyy`      .+yyyyyyysyyy+     ");
Console.WriteLine(" yyyyyyyy          /yyyyyyyo+hyyyyy:`        osyyyyho      syyyyyyyyyyyyy:    ");
Console.WriteLine("`yyyyyyyy          -yyyyyyh::hyyyss/y:                    :yyyyyyo.yyyyyyy.   ");
Console.WriteLine(" yyyyyyys          ysyyyyys  +yyyyyyyy.sso+--.           -yyyyyyy.  yyyyyys`  ");
Console.WriteLine(" yyyyyyyyssossossosssyyys+`     +yyyyyo+yyyyyyso/       -yyyyyyy/    yyyyyyo  ");
Console.WriteLine(" yysyКонстантинsyyyyyyy+-         -/oosoyyДиневyyys:    syyyyyyo     yyyyyyy: ");
Console.WriteLine(" yyyyyyysyssssssyyyyyyyyy+            ``-+osyyyyyyyy   :yyyyyyy-     +yyyyyyy-");
Console.WriteLine("`ys+:yCorleozo-yyoyyyyyyy+/sss+oys        `-syyyyyyy .yyyyyyyyyyyyyyyyyyyyyys");
Console.WriteLine(" +oyyyyy           +yyyyyyy/yossyyy+-        oyyyyyys`syyyyyyyyyyyyyyyyyyyyyyy");
Console.WriteLine(" yyyyyyy           `yyyyyyh-yyyssyyyysooo/-/oyyyyyyy-:yyyyyyyoКонстантин+-yyyy");
Console.WriteLine(" ysyyoyy            yyyyyyh+  /yyyyyyyyyyyyyyyyyyys-.oyyyyys.           oyyyyo");
Console.WriteLine("`syyos:             oyyyyyyy   `-+osyyyyyyyyyyyy+-  -+yyyyy+             yyyyy");
Console.WriteLine("                                                                              ");  Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("                            This Program Is Made By:                           "); 
Console.WriteLine("                   | Константин Динев - Constantine Corleozo |                 ");
Console.WriteLine(" RSA Криптосистема с алгоритъм на Евклид - RSA Cryptosystem with Euclidean Algo"); Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine(" ------------------------------------------------------------------------------"); Console.ForegroundColor = ConsoleColor.Gray;

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
