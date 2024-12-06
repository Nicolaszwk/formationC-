using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{ 
    public class Transaction
    {
        public string Indice { get; set; }
        public uint Id { get; set; }
        public decimal Montant { get; set; }
        public uint CompteBancaire1 { get; set; }
        public uint CompteBancaire2 { get; set; }
        public DateTime DateEffet { get; set; }

        public Transaction(string ind, uint id, DateTime dateEffet, decimal montant, uint compteBancaire1, uint compteBancaire2)
        {
            Indice = ind;
            Id = id;
            Montant = montant;
            CompteBancaire1 = compteBancaire1;
            CompteBancaire2 = compteBancaire2;
            DateEffet = dateEffet;
        }
    }
}
