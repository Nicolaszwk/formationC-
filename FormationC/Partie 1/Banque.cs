using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    internal class Banque
    {
        private Dictionary<uint, decimal> dictionnaireComptes { get; set; }
        private Dictionary<uint, Transaction> dictionnaireTransactions { get; set; }

        public Banque()
        {

            Lecture lecture = new Lecture();

            dictionnaireComptes = lecture.LectureComptes("../../../Comptes.csv");

            dictionnaireTransactions = lecture.LectureTransactions("../../../Transactions.csv");
        }

        public Dictionary<uint, bool> Traitementtransactions()

        {
            Dictionary<uint, bool> resultatTransactions = new Dictionary<uint, bool>();

            Queue<decimal> queue = new Queue<decimal>();  

            bool statut = false;

            foreach (var transaction in dictionnaireTransactions)
            {
                
                //depôt
                if (transaction.Value.comptebancaire1 == 0)
                {
                    dictionnaireComptes[transaction.Value.comptebancaire2] += transaction.Value.montant;

                    statut = true;
                }

                //retrait
                else if (transaction.Value.comptebancaire2 == 0)
                {
                    queue.Enqueue(transaction.Value.montant);

                    if (queue.Count > 10)
                    {
                        queue.Dequeue();
                    }

                    if (queue.Sum() < 1000)
                    {
                        if (transaction.Value.montant <= dictionnaireComptes[transaction.Value.comptebancaire1])
                        {
                            dictionnaireComptes[transaction.Value.comptebancaire1] -= transaction.Value.montant;

                            statut = true;
                        }
                        else
                        {
                            statut = false;
                        }
                    }
                    else
                    {
                        statut = false;
                    }
      
                }

                //virement/prelevement
                else if (transaction.Value.comptebancaire1 > 0 && transaction.Value.comptebancaire2 > 0 && transaction.Value.comptebancaire1 != transaction.Value.comptebancaire2)
                {
                    if (transaction.Value.montant <= dictionnaireComptes[transaction.Value.comptebancaire1])
                    {
                        if (dictionnaireComptes.ContainsKey(transaction.Value.comptebancaire1) && dictionnaireComptes.ContainsKey(transaction.Value.comptebancaire2))
                        {
                            dictionnaireComptes[transaction.Value.comptebancaire1] -= transaction.Value.montant;
                            dictionnaireComptes[transaction.Value.comptebancaire2] += transaction.Value.montant;

                        statut = true;
                        }
                        else
                        {
                            statut = false;
                        }
                        
                    }
                    else
                    {
                        statut = false;
                    }
                }

                //anomalies
                else
                {
                    statut = false;
                }
                resultatTransactions.Add(transaction.Key, statut);
            } 
            return resultatTransactions;
        }
    }
}
