using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 2;
            var sourceDate = DataGenerator.GetSpecialAdjacentMatrix(DataGenerator.AdjacentMatrixType.DAG);
            BaseShortest shortest = new DAGShortestPath();
            var shortestList = shortest.GetShortestList(sourceDate, s);



            for (int i = 0; i < shortest.PathList.Length; i++)
            {
                Console.WriteLine("{0}->{1},shortest={2}", s, i, shortestList[i]);
                var path = shortest.PathList[i];
                path.ForEach(x => Console.Write("{0}->", x));
                Console.WriteLine("{0}", i);

            }

            Check(shortestList, shortest.PathList);
            Console.ReadKey();
        }

        public static void Check(int[] shortest, List<int>[] pathList)
        {
            for (int i = 0; i < shortest.Length; i++)
            {
                if (shortest[i] != DataGenerator.SpecialShortest[i])
                {
                    Console.WriteLine("{0} shortest wrong,actual:{1},expected:{2}", i, shortest[i], DataGenerator.SpecialShortest[i]);
                }
            }

            for (int i = 0; i < pathList.Length; i++)
            {
                if (pathList[i].Count != DataGenerator.SpecialPredList[i].Count)
                {
                    Console.WriteLine("{0} path wrong,actual:{1},expected:{2}",
                            i,
                            string.Join(",", pathList[i].ToArray()),
                            string.Join(",", DataGenerator.SpecialPredList[i].ToArray()));
                }

                for (int j = 0; j < pathList[i].Count && j < DataGenerator.SpecialPredList[i].Count; j++)
                {
                    if (pathList[i][j] != DataGenerator.SpecialPredList[i][j])
                    {
                        Console.WriteLine("{0} path wrong,actual:{1},expected:{2}",
                            i,
                            string.Join(",", pathList[i].ToArray()),
                            string.Join(",", DataGenerator.SpecialPredList[i].ToArray()));
                    }
                }

            }
        }
    }
}
