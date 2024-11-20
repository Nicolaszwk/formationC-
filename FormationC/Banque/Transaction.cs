using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    public class Transaction
    {
        public uint numTransaction { get; set; }
        public decimal montant { get; set; }
        public uint comptebancaire1 { get; set; }
        public uint comptebancaire2 { get; set; }

        public Transaction(uint numeroTransaction, decimal montantcompte, uint compte1, uint compte2)
        {
            numTransaction = numeroTransaction;
            montant = montantcompte;
            comptebancaire1 = compte1;
            comptebancaire2 = compte2;
        }

    }
}
