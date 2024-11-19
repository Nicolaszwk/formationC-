using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    internal class Transaction
    {
        public decimal montant { get; set; }
        public uint destinataire { get; set; }
        public uint expediteur { get; set; }

        public Transaction(decimal montantcompte, uint compte1, uint compte2)
        {
            montant = montantcompte;
            destinataire = compte1;
            expediteur = compte2;
        }

           

            //Lecture dict = new Lecture();

            //decimal identifiant = dict.LectureComptes("../../../../../Comptes.csv")[0];

            //if (Dictionary.ContainsKey(identifiant))
            //{

            //}

            ////depôt
            //if (compte1 == 0)
            //{

            //}

            ////retrait
            //else if (compte2 == 0)
            //{

            //}

            ////virement/prelevement
            //else if (compte1 > 0 && compte2 > 0 && compte1 != compte2)
            //{

            //}

            ////anomalies
            //else
            //{
            //    Console.WriteLine("la transaction ne peut pas s'effectuer");
            //}
        //}
    }
}
