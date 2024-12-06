using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{
    public class MvtCompte
    {
        public string Indice { get; set; }
        public uint Id { get; set; }
        public DateTime DateCreation { get; set; }
        //public DateTime? DateResiliation { get; set; }
        public decimal Solde { get; set; }
        public uint GestionnaireId1 { get; set; }
        public uint GestionnaireId2 { get; set; }

        public MvtCompte(string ind, uint id, DateTime dateCreation, decimal solde, uint gestionnaireId1, uint gestionnaireId2)
        {
            Indice = ind;
            Id = id;
            DateCreation = dateCreation;
            Solde = solde;
            GestionnaireId1 = gestionnaireId1;
            GestionnaireId2 = gestionnaireId2;
            //DateResiliation = null;
        }
    }
}
