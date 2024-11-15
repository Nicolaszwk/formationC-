using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.WebRequestMethods;

namespace Serie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serie 1");
            Console.WriteLine(" ");

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

            PyramidConstruction(10, true);
            Console.WriteLine(" ");
            PyramidConstruction(12, false);
            Console.WriteLine(" ");

            Console.WriteLine(Factorial(4));
            Console.WriteLine(FactorialRecursive(5));
            Console.WriteLine(" ");

            Console.WriteLine("Serie 2");
            Console.WriteLine(" ");

            int[] tableau = new int[] { 1, -5, 10, -3, 0, 4, 2, -7 };
            Console.WriteLine(LinearSearch(tableau, 4));
            Console.WriteLine(BinarySearch(tableau, 4));
            Console.WriteLine(" ");

            int[] leftVector = new int[] { 1, 2, 3 };
            int[] rightVector = new int[] { -1, -4, 0 };

            BuildingMatrix(leftVector, rightVector);
            Console.WriteLine(" ");

            int[][] matrix1 = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 4, 6 },
                new int[] { -1, 8 }
            };

            int[][] matrix2 = new int[][]
           {
                new int[] { -1, 5 },
                new int[] { -4, 0 },
                new int[] { 0, 2 }
           };

            Addition(matrix1, matrix2);
            Console.WriteLine(" ");

            Substraction(matrix1, matrix2);
            Console.WriteLine(" ");

            int[][] matrix3 = new int[][]
           {
                new int[] { 1, 2 },
                new int[] { 4, 6 },
                new int[] { -1, 8 }
           };

            int[][] matrix4 = new int[][]
           {
                new int[] { -1, 5, 0 },
                new int[] { -4, 0, 1 },
           };


            Multiplication(matrix3, matrix4);

            SchoolSubjectMean("../../../../../Matieres.txt", "../../../MatieresMean.txt");

            Console.ReadKey();
        }

        //Serie 1

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

        //Exercice 3 : Construction d'une pyramide
        static void PyramidConstruction(int n, bool isSmooth)
        {
            int nbrblocs = 0;

            for (int j = 0; j < n - 1; j++)
            {
                nbrblocs = j * 2 + 1;

                if (isSmooth)
                {

                    Console.Write(new string(' ', n - j - 1));
                    Console.Write(new string('+', nbrblocs));
                    Console.WriteLine();
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        Console.Write(new string(' ', n - j - 1));
                        Console.Write(new string('-', nbrblocs));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(new string(' ', n - j - 1));
                        Console.Write(new string('+', nbrblocs));
                        Console.WriteLine();
                    }
                }
            }
        }

        //Exercice 4 : Factorielle
        static int Factorial(int n)
        {
            int r = 1;

            if (n == 0)
            {
                return 1;
            }

            for (int i = 1; i <= n; i++)
            {
                r *= i;
            }
            return r;
        }

        static int FactorialRecursive(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * FactorialRecursive(n - 1);
        }

        // Serie 2

        //Exercice 1 : Recherche d'un élément
        static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length - 1; i++)
            {
                if (valeur == tableau[i])
                {
                    return i;
                }
            }
            return -1;
        }
        static int BinarySearch(int[] tableau, int valeur)
        { 

            int index = Array.BinarySearch(tableau, valeur);

            if (index >= 0)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        //Exercice 2 : Bases du calcul matriciel
        static int [,] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[,] matrix = new int[leftVector.Length, rightVector.Length];

            for (int i = 0; i < leftVector.Length; i++)
            {
                for (int j = 0; j < rightVector.Length; j++)
                {
                    matrix[i, j] = leftVector[i] * rightVector[j];

                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            return matrix;
        }
        static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {

            int[][] additionMatrix = new int[3][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                additionMatrix[i] = new int[leftMatrix[0].Length];
                {
                    for (int j = 0; j < leftMatrix[i].Length; j++)
                    {
                        additionMatrix[i][j] = leftMatrix[i][j] + rightMatrix[i][j];

                        Console.Write(additionMatrix[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            return additionMatrix;
        }

        static int[][] Substraction(int[][] leftMatrix, int[][] rightMatrix)
        {

            int[][] substractionMatrix = new int[3][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                substractionMatrix[i] = new int[leftMatrix[0].Length];
                {
                    for (int j = 0; j < leftMatrix[i].Length; j++)
                    {
                        substractionMatrix[i][j] = leftMatrix[i][j] - rightMatrix[i][j];

                        Console.Write(substractionMatrix[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            return substractionMatrix;
        }

        static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {

            int[][] multiplicationMatrix = new int[3][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                multiplicationMatrix[i] = new int[rightMatrix[0].Length];
                {
                    for (int j = 0; j < rightMatrix[0].Length; j++)
                    {
                       for (int k = 0; k < leftMatrix[i].Length; k++)
                        {
                            multiplicationMatrix[i][j] += leftMatrix[i][k] * rightMatrix[k][j];
                        }
                        Console.Write(multiplicationMatrix[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            return multiplicationMatrix;
        }

        // Serie 3

        //Exercice 1 : Recherche d'un élément
        //static void SchoolSubjectMean(string input, string output)
        //{
        //    using (FileStream file1 = File.OpenRead(input))

        //    using (StreamReader file2 = new StreamReader(file1))
        //    {
        //        string[] lines = File.ReadAllLines(input);

        //        Dictionary<string, int> dictionnary = new Dictionary<string, int>();

        //        while (!file2.EndOfStream)
        //        {
        //            foreach (string line in lines)
        //            {
        //                string[] words = line.Split(',');
        //                int subject = string.Parse(words[2]);
        //                dictionnary.Add(words[1], subject);
        //                Console.WriteLine(dictionnary);
        //            }
        //        }

        //    }
        //}

         
    }
}
