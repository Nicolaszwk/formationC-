using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();

            var resultat = banque.Traitementtransactions();
            var metrologie = banque.Compteurs();

            Ecriture.Write(resultat);
            Ecriture.WriteCompteurs(metrologie);

            Console.ReadKey();
        }
    }
}



