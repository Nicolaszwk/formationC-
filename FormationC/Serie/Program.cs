using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Serie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicOperation(3, 4, '+');
            BasicOperation(6, 2, '/');
            BasicOperation(3, 0, '/');
            BasicOperation(6, 9, 'L');
            Console.WriteLine(" ");

            IntegerDivision(12, -4);
            IntegerDivision(13, -4);
            IntegerDivision(12, 0);
            Console.WriteLine(" ");

            Pow(8, -1);
            Pow(8, 0);
            Pow(8, 7);
            Console.WriteLine(" ");

            GoodDay(3);
            GoodDay(9);
            GoodDay(12);
            GoodDay(16);
            GoodDay(21);
            Console.WriteLine(" ");

            Console.ReadKey();
        }

        // Exercice 1 : Opérations de base
        static void BasicOperation(int a, int b, char operateur)
        {
            int r;
            switch (operateur)
            {
                case '+':
                    r = a + b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;

                case '-':
                    r = a - b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;

                case '*':
                    r = a * b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;

                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine(a + " " + operateur + " " + b + " = " + "Opération invalide");
                        break;
                    }
                    else
                    {
                        r = a / b;
                        Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                        break;
                    }
                default:
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + "Opération invalide");
                    break;

            }
        }

        static void IntegerDivision(int a, int b)
        {
            if (b != 0)
            {
                int q = a / b;
                int r = a % b;

                if (r == 0)
                {
                    Console.WriteLine(a + " = " + q + " * " + b);
                }
                else
                {
                    Console.WriteLine(a + " = " + q + " * " + b + " + " + r);
                }
            }
            else
            {
                Console.WriteLine(a + " : " + b + " = Opération invalide");
            }
        }

        static void Pow(int a, int b)
        {
            if (b < 0)
            {
                Console.WriteLine(a + " ^ " + b + " = Opération invalide");
            }
            if (b == 0)
            {
                Console.WriteLine(a + " ^ " + b + " = 1");
            }
            else
            {
                int r = a;

                for (int i = 0; i < b - 1; i++)
                {
                    r = r * a;
                }

                Console.WriteLine(a + " ^ " + b + " = " + r);
            }
        }

        // Exercice 2 : Horloge parlante

        static void GoodDay(int heure)
        {
            if (0 <= heure && heure <= 6)
            {
                Console.WriteLine("Merveilleuse nuit!");
            }
            else if (heure > 6 && heure < 12)
            {
                Console.WriteLine("Bonne matinée!");
            }
            else if (heure == 12)
            {
                Console.WriteLine("Bon appétit!");
            }
            else if (heure >= 13 && heure <= 18)
            {
                Console.WriteLine("Profitez de votre après-midi!");
            }
            else if (heure > 18)
            {
                Console.WriteLine("Passez une bonne soirée!");
            }
            else
            {
                Console.WriteLine("Veuillez rentrer une valeur entre 0 et 23");
            }
        }

        // Exercice 2 : Horloge parlante
        //static void PyramidConstruction(int n, bool isSmooth)
        //{
        //    int nbrblocs = 0;

        //    for (int j = 0; j < n - 1; j++)
        //    {
        //        nbrblocs = nbrblocs * 2 + 1;
                
        //    }
        //}
    }
}
