using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    internal class Transaction
    {
        public void ActionTransaction(decimal montant, uint compte1, uint compte2)
        {
            //dict1.Add(montant, compte1);

            //depôt
            if (compte1 == 0)
            {

            }

            //retrait
            else if (compte2 == 0)
            {

            }

            //virement/prelevement
            else if (compte1 > 0 && compte2 > 0 && compte1 != compte2)
            {

            }

            //anomalies
            else
            {
                Console.WriteLine("la transaction ne peut pas s'effectuer");
            }
        }
    }
}
