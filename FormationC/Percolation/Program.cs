using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 3b
            //Le pire des cas est le cas dans lequel toutes les cases sont ouvertes sauf celles d'une ligne entière.
            //L'ouverture d'une case de cette derniere ligne restante permettra alors la percolation.

            //Question 3c
            //Il y a peu de chance que le pire cas se produise étant donné que les cases sont ouvertes de manières aléatoires.
            //La possibilité que le pire cas se produise est minime.


            PercolationSimulation percolationSimulation = new PercolationSimulation();
            percolationSimulation.PercolationValue(5);

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
