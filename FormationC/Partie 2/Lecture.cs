using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Banque.partie2;

namespace Banque
{
    public class Lecture
    {
        // Déclarer une liste globale de sous-listes
        //private List<List<object>> globalList = new List<List<object>>();

        public Dictionary<uint, Gestionnaire> LectureGestionnaires(string input)
        {
            if (!File.Exists(input))
            {
                return null;
            }
            
            Dictionary<uint, Gestionnaire> gestionnaireDictionary = new Dictionary<uint, Gestionnaire>();

            // Ouvrir le fichier
            using (FileStream file1 = File.OpenRead(input))
            // Déclaration de l'outil qui sert à lire le fichier
            using (StreamReader file2 = new StreamReader(file1))
            {
                while (!file2.EndOfStream)
                {
                    string[] ligne = file2.ReadLine().Split(';');

                    if (!uint.TryParse(ligne[0], out uint identifiant))
                    {
                        continue;
                    }
       
                    if (ligne[1] != "Particulier" && ligne[1] != "Entreprise")
                    {
                        continue;
                    }
                    if (!int.TryParse(ligne[2], out int nbTransactions))
                    {
                        continue;
                    }
                    else
                    {
                        Gestionnaire gestionnaire = new Gestionnaire(identifiant, ligne[1], nbTransactions);
                        gestionnaireDictionary.Add(identifiant, gestionnaire);
                    }
                }
            }
            return gestionnaireDictionary;
        }

        public List<object> LectureComptes(string input)
        {
            if (!File.Exists(input))
            {
                return null;
            }

            // Déclaration de la liste des comptes
            List<object> comptesListe = new List<object>();

            // Ouvrir le fichier
            using (FileStream file1 = File.OpenRead(input))
            using (StreamReader file2 = new StreamReader(file1))
            {
                while (!file2.EndOfStream)
                {
                    string[] ligne = file2.ReadLine().Split(';');

                    if (!uint.TryParse(ligne[0], out uint identifiant))
                    {
                        continue;
                    }

                    if (!DateTime.TryParse(ligne[1], out DateTime dateOuv))
                    {
                        continue;
                    }

                    if (!decimal.TryParse(ligne[2], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.GetCultureInfo("en-US"), out decimal solde))
                    {
                        if (ligne[2] == String.Empty)
                        {
                            solde = 0;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (!uint.TryParse(ligne[3], out uint entree))
                    {
                        continue;
                    }

                    if (!uint.TryParse(ligne[4], out uint sortie))
                    {
                        if (ligne[4] == String.Empty)
                        {
                            sortie = 0;
                        }
                        else
                        {
                            continue;
                        }    
                    }

                    if (solde < 0)
                    {
                        continue;
                    }

                    // Vérifier si le compte existe déjà dans la liste
                    else 
                    {
                        MvtCompte compte = new MvtCompte("C", identifiant, dateOuv, solde, entree, sortie);
                        List<object> compteData = new List<object> { compte };

                        // Ajouter le compte à la liste des comptes
                        comptesListe.Add(compteData);

                        // Ajouter une sous-liste à la liste globale
                        //globalList.Add(new List<object> { "C", identifiant, dateOuv, solde, entree, sortie });
                    }
                }
            }

            return comptesListe;
        }



        public List<object> LectureTransactions(string input)
        {
            if (!File.Exists(input))
            {
                return null;
            }
            // Déclaration de la liste des transactions
            List<object> transactionsListe = new List<object>();

            // Ouvrir le fichier
            using (FileStream file1 = File.OpenRead(input))
            // Déclaration de l'outil qui sert à lire le fichier
            using (StreamReader file2 = new StreamReader(file1))
            {
                while (!file2.EndOfStream)
                {
                    string[] ligne = file2.ReadLine().Split(';');
                    if (!uint.TryParse(ligne[0], out uint numtransaction))
                    {
                        continue;
                    }
                    if (!DateTime.TryParse(ligne[1], out DateTime dateEffet))
                    {
                        continue;
                    }
                    if (!decimal.TryParse(ligne[2], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.GetCultureInfo("en-US"), out decimal montant))
                    {
                        continue;
                    } 
                    if (!uint.TryParse(ligne[3], out uint expediteur))
                    {
                        if (ligne[3] == String.Empty)
                        {
                            expediteur = 0;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (!uint.TryParse(ligne[4], out uint destinataire))
                    {
                        if (ligne[4] == String.Empty)
                        {
                            destinataire = 0;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Transaction transaction = new Transaction("T", numtransaction, dateEffet, montant, expediteur, destinataire);
                        List<object> transactionData = new List<object> { transaction };

                        // Ajouter le compte à la liste des comptes
                        transactionsListe.Add(transactionData);

                        // Ajouter une sous-liste à la liste globale
                        //globalList.Add(new List<object> { "C", identifiant, dateOuv, solde, entree, sortie });
                    }
                }
            }
            return transactionsListe;
        }
    }
}
