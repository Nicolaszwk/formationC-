using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banque.partie2
{
    internal class Banque
    {
        private Dictionary<uint, Gestionnaire> dictionnaireGestionnaires { get; set; }
        private Dictionary<uint, Compte> comptesDictionary { get; set; }
        //private Dictionary<int, Compte> dictionnaireComptes { get; set; }
        //private Dictionary<uint, Transaction> dictionnaireTransactions { get; set; }
        private List<object> listeComptes { get; set; }
        private List<object> listeTransactions { get; set; }

        private int compteurComptesCrees = 0;
        private int compteurNbTransactions = 0;
        private int compteurNbReussites = 0;
        private int compteurNbEchecs = 0;
        private decimal compteurMontantReussite = 0;

        List<object> listeGlobale = new List<object>();

        public Banque()
        {
            Lecture lecture = new Lecture();

            dictionnaireGestionnaires = lecture.LectureGestionnaires("../../../Gestionnaires.csv");
            listeComptes = lecture.LectureComptes("../../../Comptes.csv");
            listeTransactions = lecture.LectureTransactions("../../../Transactions.csv");
            //dictionnaireComptes = lecture.LectureComptes("../../../Comptes_2.csv");
            //dictionnaireTransactions = lecture.LectureTransactions("../../../Transactions_2.csv");

            //List<object> listeGlobale = new List<object>();

            comptesDictionary = new Dictionary<uint, Compte>();

            foreach (var compte in listeComptes)
            {
                // Transformer chaque compte en List<object>
                //listeGlobale.Add(new List<object> { compte });
                listeGlobale.Add(compte);
                compteurNbTransactions++;
            }

            // Ajouter les transactions à listeGlobale
            foreach (var transaction in listeTransactions)
            {
                // Transformer chaque transaction en List<object>
                //listeGlobale.Add(new List<object> { transaction });
                listeGlobale.Add(transaction);
                compteurNbTransactions++;
            }

            listeGlobale.Sort((a, b) =>
            {
                DateTime dateA;
                DateTime dateB;

                // Vérifiez d'abord si 'a' est une liste d'objets
                if (a is List<object> listA && listA[0] is MvtCompte compteA)
                {
                    dateA = compteA.DateCreation;
                }
                else if (a is List<object> listA2 && listA2[0] is Transaction transactionA)
                {
                    dateA = transactionA.DateEffet;
                }
                else
                {
                    throw new InvalidOperationException("a n'est ni un Compte ni une Transaction.");
                }

                // Vérifiez d'abord si 'b' est une liste d'objets
                if (b is List<object> listB && listB[0] is MvtCompte compteB)
                {
                    dateB = compteB.DateCreation;
                }
                else if (b is List<object> listB2 && listB2[0] is Transaction transactionB)
                {
                    dateB = transactionB.DateEffet;
                }
                else
                {
                    throw new InvalidOperationException("b n'est ni un Compte ni une Transaction.");
                }

                return dateA.CompareTo(dateB);

            });
        }

        public void CreerCompte(uint id, DateTime dateCreation, decimal soldeInitial, uint gestionnaireId)
        {
                Compte nouveauCompte = new Compte(id, dateCreation, soldeInitial, gestionnaireId);
                comptesDictionary.Add(id, nouveauCompte);
                Console.WriteLine("Compte créé avec succès !");
                compteurComptesCrees++;
                compteurNbReussites++;
        }

        public void Cloturercompte(uint id)
        {
                comptesDictionary.Remove(id);
                Console.WriteLine("compte clôturé avec succès !");
                compteurNbReussites++;
        }

        public void CederCompte(uint idCompte, DateTime dateTransactionCompte, uint idExpediteur, uint idDestinataire)
        {
            //if (listeComptes.ContainsKey(idExpediteur) && listeComptes.ContainsKey(idDestinataire) && idExpediteur  != idDestinataire)
            //if (dictionnaireGestionnaires.ContainsKey(idExpediteur) && dictionnaireGestionnaires.ContainsKey(idDestinataire) && comptesDictionary[idCompte].GestionnaireId == idExpediteur && idExpediteur != idDestinataire)
            
                comptesDictionary[idCompte].DateCreation = dateTransactionCompte;
                comptesDictionary[idCompte].GestionnaireId = idDestinataire;

                Console.WriteLine("Compte cédé avec succès !");
                compteurNbReussites++;
        }

        public Dictionary<uint, bool> Traitementtransactions()
        {
            //Dictionary<uint, bool> resultatTransactions = new Dictionary<uint, bool>();
            Dictionary<uint, bool> resultatTransactions = new Dictionary<uint, bool>();
            bool statut = false;

            foreach (var transaction in listeGlobale)
            {
                if (transaction is List<object> transactionA && transactionA[0] is MvtCompte transactionB)
                {
                    if (dictionnaireGestionnaires.ContainsKey(transactionB.GestionnaireId1) && transactionB.GestionnaireId2 == 0 && !comptesDictionary.ContainsKey(transactionB.Id))
                    {
                        if (transactionB.Solde > 0)
                        {
                            CreerCompte(transactionB.Id, transactionB.DateCreation, transactionB.Solde, transactionB.GestionnaireId1);
                            statut = true;
                        }
                        else
                        {
                            statut = false;
                        }
                    }
                    else if (comptesDictionary.ContainsKey(transactionB.Id) && comptesDictionary[transactionB.Id].GestionnaireId == transactionB.GestionnaireId2 && transactionB.GestionnaireId1 == 0)
                    {
                        Cloturercompte(transactionB.Id);
                        statut = true;
                    }
                    else if (comptesDictionary.ContainsKey(transactionB.Id) && dictionnaireGestionnaires.ContainsKey(transactionB.GestionnaireId1) && dictionnaireGestionnaires.ContainsKey(transactionB.GestionnaireId2) && comptesDictionary[transactionB.Id].GestionnaireId == transactionB.GestionnaireId1 && transactionB.GestionnaireId1 != transactionB.GestionnaireId2)
                    {
                        CederCompte(transactionB.Id, transactionB.DateCreation, transactionB.GestionnaireId1, transactionB.GestionnaireId2);
                        statut = true;
                    }
                    else
                    {
                        statut = false;
                    }

                    if (resultatTransactions.ContainsKey(transactionB.Id))
                    {
                        continue;
                    }
                    else
                    {
                        resultatTransactions.Add(transactionB.Id, statut);
                    }
                    
                }

                else if (transaction is List<object> transactionC && transactionC[0] is Transaction transactionD)
                {
                    //depôt
                    if (transactionD.CompteBancaire1 == 0 && comptesDictionary.ContainsKey(transactionD.CompteBancaire2))
                    {
                        comptesDictionary[transactionD.CompteBancaire2].Solde += transactionD.Montant;
                        statut = true;
                        compteurNbReussites++;
                        compteurMontantReussite += transactionD.Montant;
                    }
                    //retrait
                    else if (transactionD.CompteBancaire2 == 0 && comptesDictionary.ContainsKey(transactionD.CompteBancaire1))
                    {
                        comptesDictionary[transactionD.CompteBancaire1].Solde -= transactionD.Montant;
                        statut = true;
                        compteurNbReussites++;
                        compteurMontantReussite += transactionD.Montant;
                    }
                    //virement
                    else if (comptesDictionary.ContainsKey(transactionD.CompteBancaire1) && comptesDictionary.ContainsKey(transactionD.CompteBancaire2))
                    {
                        uint gestionnaireId = comptesDictionary[transactionD.CompteBancaire1].GestionnaireId;

                        if (dictionnaireGestionnaires[gestionnaireId].Type == "Particulier" && comptesDictionary[transactionD.CompteBancaire1].GestionnaireId != comptesDictionary[transactionD.CompteBancaire2].GestionnaireId)
                        {
                            comptesDictionary[transactionD.CompteBancaire1].Solde -= transactionD.Montant;
                            comptesDictionary[transactionD.CompteBancaire2].Solde += 0.99m * transactionD.Montant;
                            statut = true;
                            compteurNbReussites++;
                            compteurMontantReussite += transactionD.Montant;
                        }
                        else if (dictionnaireGestionnaires[gestionnaireId].Type == "Entreprise" && comptesDictionary[transactionD.CompteBancaire1].GestionnaireId != comptesDictionary[transactionD.CompteBancaire2].GestionnaireId)
                        { 
                            comptesDictionary[transactionD.CompteBancaire1].Solde -= transactionD.Montant;
                            comptesDictionary[transactionD.CompteBancaire2].Solde += transactionD.Montant - 10;
                            statut = true;
                            compteurNbReussites++;
                            compteurMontantReussite += transactionD.Montant;
                        }
                        else
                        {
                            comptesDictionary[transactionD.CompteBancaire1].Solde -= transactionD.Montant;
                            comptesDictionary[transactionD.CompteBancaire2].Solde += transactionD.Montant;
                            statut = true;
                            compteurNbReussites++;
                            compteurMontantReussite += transactionD.Montant;
                        }
                    }
                    else
                    {
                        statut = false;
                    }

                    if (resultatTransactions.ContainsKey(transactionD.Id))
                    {
                        continue;
                    }
                    else
                    {
                        resultatTransactions.Add(transactionD.Id, statut);
                    }
                }
                else
                {
                    statut = false;
                }                
            }
            return resultatTransactions;
        }

        public Dictionary<string, int> Compteurs()
        {
            compteurNbEchecs = compteurNbTransactions - compteurNbReussites;

            return new Dictionary<string, int>
            {
                { "Nombre de comptes : ", compteurComptesCrees },
                { "Nombre de transactions : ", compteurNbTransactions },
                { "Nombre de réussites : ", compteurNbReussites },
                { "Nombre d'échecs : ", compteurNbEchecs },
            };
        }

        //public Dictionary<string, decimal> CompteursReussites()
        //{
        //    compteurNbEchecs = compteurNbTransactions - compteurNbReussites;

        //    return new Dictionary<string, decimal>
        //    {
        //        { "Montant total des réussites: ", compteurMontantReussite }
        //    };
        //}
    }
}
