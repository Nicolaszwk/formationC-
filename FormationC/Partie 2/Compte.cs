using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{
    public class Compte
    {
        public uint Id { get; set; }
        public DateTime DateCreation { get; set; }
        public decimal Solde { get; set; }
        public uint GestionnaireId { get; set; }

        public Compte(uint id, DateTime dateCreation, decimal soldeInitial, uint gestionnaireId)
        {
            Id = id;
            DateCreation = dateCreation;
            Solde = soldeInitial;
            GestionnaireId = gestionnaireId;
        }
    }
}
