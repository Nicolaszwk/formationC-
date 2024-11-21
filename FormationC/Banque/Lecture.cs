using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Banque
{
    public class Lecture
    {
        public Dictionary<uint, decimal> LectureComptes(string input)
        {
            if (!File.Exists(input))
            {
                return null;
            }
            
            Dictionary<uint, decimal> comptesDictionary = new Dictionary<uint, decimal>();

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

                    
                    if (!decimal.TryParse(ligne[1],NumberStyles.AllowDecimalPoint,CultureInfo.GetCultureInfo("en-US"), out decimal solde))
                    {
                        comptesDictionary.Add(identifiant, 0);
                    }

                    //if (comptesDictionary.ContainsKey(identifiant))
                    //{
                    //    continue; 
                    //}
                    else
                    {
                        if (!comptesDictionary.ContainsKey(identifiant))
                        {
                             comptesDictionary.Add(identifiant, solde);
                        }
                       
                    }
                }
            }
            return comptesDictionary;
        }

        public Dictionary <uint, Transaction> LectureTransactions(string input)
        {
            if (!File.Exists(input))
            {
                return null;
            }

            Dictionary<uint, Transaction> transactionsDictionary = new Dictionary<uint, Transaction>();

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
                    
                    if (!decimal.TryParse(ligne[1],NumberStyles.AllowDecimalPoint,CultureInfo.GetCultureInfo("en-US"), out decimal montant))
                    {
                        continue;
                    }
                    if (!uint.TryParse(ligne[2], out uint compte1))
                    {
                        continue;
                    }
                    if (!uint.TryParse(ligne[3], out uint compte2))
                    {
                        continue;
                    }
                     if (transactionsDictionary.ContainsKey(numtransaction))
                    {
                        break; 
                    }
                    else
                    {
                        Transaction transaction = new Transaction(numtransaction, montant, compte1, compte2);

                        transactionsDictionary.Add(numtransaction, transaction);
                    }
                }
            }
            return transactionsDictionary;
        }
    }
}
