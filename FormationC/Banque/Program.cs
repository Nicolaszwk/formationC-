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
            Dictionary<uint, decimal> dictionnaireComptes = lecture.LectureComptes("../../../../../Comptes.csv");
            //LectureTransactions("../../../../../Comptes.csv");

            Console.ReadKey();
        }
    }
}
