using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{
    public class Gestionnaire
    {
        public uint Id { get; set; }
        public string Type { get; set; }
        public int NbTransactions { get; set; }

        public Gestionnaire(uint idGestionnaire, string typeGestionnaire, int NbtransacGestionnaire)
        {
            Id = idGestionnaire;
            Type = typeGestionnaire;
            NbTransactions = NbtransacGestionnaire;
        }
    }
}
