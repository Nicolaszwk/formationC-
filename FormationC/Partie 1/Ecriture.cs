using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    internal class Ecriture
    {
        public static void Write(Dictionary<uint, bool> dict1)
        {
            using (FileStream file3 = File.Create("../../../Resultats_transactions.csv"))
            using (StreamWriter file4 = new StreamWriter(file3))
            {
                foreach (KeyValuePair<uint, bool> item in dict1)
                {
                    if (item.Value == true)
                    {
                        file4.WriteLine(item.Key + ";OK");
                    }
                    else
                    {
                        file4.WriteLine(item.Key + ";KO");
                    }
                }
            }
        }
    }

    
}
