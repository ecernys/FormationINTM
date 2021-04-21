using System;
using System.Collections.Generic;
using System.Linq;
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
            if (i < 0 || i >= _size)
            {
                return false;
            }
            if (j < 0 || j >= _size)
            {
                return false;
            }
            return _open[i, j];
        }

        public bool IsFull(int i, int j)
        {
            if (i < 0 || i >= _size)
            {
                return false;
            }
            if (j < 0 || j >= _size)
            {
                return false;
            }
            return _full[i, j];
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (IsFull(_size - 1, i))
                {
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors = new List<KeyValuePair<int, int>>();

            if (i - 1 >= 0)
                neighbors.Add(new KeyValuePair<int, int>(i - 1, j));
            if (i + 1 < _size)
                neighbors.Add(new KeyValuePair<int, int>(i + 1, j));
            if (j - 1 >= 0)
                neighbors.Add(new KeyValuePair<int, int>(i, j - 1));
            if (j + 1 < _size)
                neighbors.Add(new KeyValuePair<int, int>(i, j + 1));
            return neighbors;
        }

    public void Open(int i, int j)
    {
        _open[i, j] = true;
        if (i == 0)
        {
            _full[i, j] = true;
            checkNeighbours(i, j);
        }
        else
        {
            List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);
            foreach (var item in neighbors)
            {
                if (IsFull(item.Key, item.Value))
                {
                    _full[i, j] = true;
                    checkNeighbours(i, j);
                }

            }
        }
    }

    private void checkNeighbours(int i, int j)
    {
        List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);
        foreach (var item in neighbors)
        {
            if (IsOpen(item.Key, item.Value) && !IsFull(item.Key, item.Value))
            {
                _full[item.Key, item.Value] = true;
                checkNeighbours(item.Key, item.Value);
            }
        }
    }
}
}
