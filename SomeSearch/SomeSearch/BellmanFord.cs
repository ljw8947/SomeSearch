using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    public class BellmanFord : BaseShortest
    {
        public override int[] GetShortestList(int[,] adjacentMatrix, int s)
        {
            int[] shortest = new int[adjacentMatrix.GetLength(0)];
            for (int i = 0; i < shortest.Length; i++)
            {
                shortest[i] = 999;
            }
            shortest[s] = 0;

            for (int n = 0; n < shortest.Length - 1; n++)
            {
                for (int i = 0; i < adjacentMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < adjacentMatrix.GetLength(1); j++)
                    {
                        Releax(adjacentMatrix, shortest, i, j);
                    }
                }
            }
            return shortest;
        }
    }
}
