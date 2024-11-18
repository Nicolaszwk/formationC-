using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
         
            // Dictionnaire pour les matières et le nombre des notes
            Dictionary<uint, decimal> dict1 = new Dictionary<uint, decimal>();
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

                    if (!decimal.TryParse(ligne[1], out decimal solde)){
                        dict1.Add(identifiant, 0);
                    }

                    if (dict1.ContainsKey(identifiant))
                    {
                        continue; 
                    }
                    else
                    {
                        dict1.Add(identifiant, solde);
                    }
                }
            }

            return dict1;
        }

        public void LectureTransactions(string input)
        {
            if (!File.Exists(input))
            {
                return;
            }

            // Ouvrir le fichier
            using (FileStream file1 = File.OpenRead(input))
            // Déclaration de l'outil qui sert à lire le fichier
            using (StreamReader file2 = new StreamReader(file1))
            {
                while (!file2.EndOfStream)
                {
                    string[] ligne = file2.ReadLine().Split(';');
                    if (!decimal.TryParse(ligne[1], out decimal soldecompte))
                    {
                        continue;
                    }
                    if (!uint.TryParse(ligne[2], out uint identifiant1))
                    {
                        continue;
                    }
                    if (!uint.TryParse(ligne[3], out uint identifiant2))
                    {
                        continue;
                    }
                    else
                    {
                        decimal solde = soldecompte;
                        uint compte1 = identifiant1;
                        uint compte2 = identifiant2;

                        Transaction transaction = new Transaction();

                        transaction.ActionTransaction(soldecompte, compte1, compte2);
                    }
                }
            }
        }
    }
}
