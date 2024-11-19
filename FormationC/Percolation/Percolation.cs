using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i, j];
        }

        private void Fill(int i, int j)
        {
            //si la case est ouverte et pas encore remplie, alors elle se remplie
            if (IsOpen(i, j) && !IsFull(i, j))
            {
                _full[i, j] = true;

                //pour chaque voisin dans la liste des voisins, on remplit la case comme elle est ouverte mais pas encore remplie
                foreach (var neighbor in CloseNeighbors(i, j))
                {
                    Fill(neighbor.Key, neighbor.Value);
                }
            }
        }

        public bool Percolate()
        {
            for (int j = 0; j < _size - 1; j++)
            {
                //percolation ok si une case de la derniere ligne est remplie
                if (IsFull(_size - 1,j))
                { 
                    _percolate = true;
                    break;
                }
            }
            return _percolate;
        }


        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors = new List<KeyValuePair<int, int>>();

            //si 1er ligne: cases en haut ko mais cases en dessous ok
            if (i > 0) neighbors.Add(new KeyValuePair<int, int>(i - 1, j));

            //si derniere ligne: cases en bas ko mais cases au dessus ok
            if (i < _size - 1) neighbors.Add(new KeyValuePair<int, int>(i + 1, j));

            //si ligne tout à gauche: cases à gauche ko mais cases à droite ok
            if (j > 0) neighbors.Add(new KeyValuePair<int, int>(i, j - 1));

            //si ligne tout à droite: cases à droite ko mais cases à gauche ok
            if (j < _size - 1) neighbors.Add(new KeyValuePair<int, int>(i, j + 1));

            return neighbors;

        }

        public void Open(int i, int j)
        {
            
            if (!IsOpen(i, j))
            {
                //ouverture de la case
                _open[i, j] = true;

                //si case ouverte 1ere ligne ou case voisine pleine, alors nouvelle case sera pleine
                //verifie si un des elements de la liste (case) CloseNeighbors(i, j) est plein
                if (i == 0 || CloseNeighbors(i, j).Any(x => IsFull(x.Key, x.Value)))
                {
                    //si une des conditions est remplie, remplissage de la case
                    Fill(i, j);
                }
                ShowGrid();

            }
        }

        public void ShowGrid()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (IsOpen(i, j))
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

