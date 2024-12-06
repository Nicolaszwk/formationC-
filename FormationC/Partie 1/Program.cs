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
            Banque banque = new Banque();

            var resultat = banque.Traitementtransactions();

            Ecriture.Write(resultat);

            Console.ReadKey();
        }
    }
}
