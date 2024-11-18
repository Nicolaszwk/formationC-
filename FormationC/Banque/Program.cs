using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lecture lecture = new Lecture();

            // Appel la methode ReadComptes de la classe Lecture
            lecture.LectureComptes("../../../../../Comptes.csv");

            Console.ReadKey();
        }
    }
}
