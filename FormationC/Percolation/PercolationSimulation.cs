using Percolation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            int opensquare = 0;
            int totalsquare = size * size;
            Percolation percolation = new Percolation(size);
            Random rand = new Random();

            while (!percolation.Percolate())
            {
                int i = rand.Next(size);
                int j = rand.Next(size);
                percolation.Open(i, j);
                opensquare++;
            }
            return opensquare/ totalsquare;
        }
    }
}