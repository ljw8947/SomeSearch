using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    public class DataGenerator
    {
        public const int LENGTH = 5;
        public static int[,] SpecialAdjacentMatrix;
        public static List<int>[] SpecialPredList;
        public static int[] SpecialShortest;

        static Random randomer = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// 返回邻接矩阵
        /// </summary>
        /// <returns>值为权重</returns>
        public static int[,] GetAdjacentMatrix(AdjacentMatrixType type)
        {
            int[,] matrix = new int[LENGTH, LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH;j++ )
                {
                    if (type == AdjacentMatrixType.DAG)
                    {
                        matrix[i, j] = j > i ? randomer.Next(0, 9) : 0;
                    }
                    else
                    {
                        matrix[i, j] = randomer.Next(0, 9);
                    }
                }
 
            }
            Print(matrix);
            return matrix;
        }

        public static int[,] GetSpecialAdjacentMatrix(AdjacentMatrixType type)
        {
            SpecialAdjacentMatrix = new int[LENGTH, LENGTH];
            

            SpecialShortest = new int[LENGTH];
            
            SpecialPredList = new List<int>[LENGTH];
            for (int i = 0; i < SpecialPredList.Length;i++ )
            {
                SpecialPredList[i] = new List<int>();
            }



            switch (type)
            {
                case AdjacentMatrixType.DG:

                    SpecialAdjacentMatrix[0, 3] = 1;
                    SpecialAdjacentMatrix[0, 4] = 2;
                    SpecialAdjacentMatrix[2, 0] = 3;
                    SpecialAdjacentMatrix[2, 1] = 8;
                    SpecialAdjacentMatrix[2, 3] = 5;
                    SpecialAdjacentMatrix[2, 0] = 3;
                    SpecialAdjacentMatrix[3, 1] = 2;
                    SpecialAdjacentMatrix[3, 4] = 1;

                    SpecialShortest[0] = 3;
                    SpecialShortest[1] = 6;
                    SpecialShortest[3] = 4;
                    SpecialShortest[4] = 5;

                    SpecialPredList[0].Add(2);
                    SpecialPredList[1].Add(3);
                    SpecialPredList[1].Add(0);
                    SpecialPredList[1].Add(2);

                    SpecialPredList[3].Add(0);
                    SpecialPredList[3].Add(2);

                    SpecialPredList[4].Add(0);
                    SpecialPredList[4].Add(2);
                    break;
                case AdjacentMatrixType.DAG:
                    SpecialAdjacentMatrix[0, 1] = 5;
                    SpecialAdjacentMatrix[1, 3] = 2;
                    SpecialAdjacentMatrix[1, 4] = 8;
                    SpecialAdjacentMatrix[2, 1] = 1;
                    SpecialAdjacentMatrix[2, 3] = 5;
                    SpecialAdjacentMatrix[2, 4] = 9;
                    SpecialAdjacentMatrix[3, 4] = 1;
                    
                    SpecialShortest[0] = 999999;
                    SpecialShortest[1] = 1;
                    SpecialShortest[3] = 3;
                    SpecialShortest[4] = 4;

                    SpecialPredList[1].Add(2);
                    SpecialPredList[3].Add(1);
                    SpecialPredList[3].Add(2);
                    SpecialPredList[4].Add(3);
                    SpecialPredList[4].Add(1);
                    SpecialPredList[4].Add(2);
                    break;
                default:
                    throw new Exception("invalid type");
            }

            Print(SpecialAdjacentMatrix);
            return SpecialAdjacentMatrix;
        }

        public static void Print(int[,] adjacentMMatrix)
        {
            Console.WriteLine("Generate Adjacent Matrix:");
            Console.Write("  ");
            for (int i = 0; i < LENGTH; i++)
            {
                Console.Write(string.Format("  {0}  ", i));
            }
            Console.WriteLine();
            for (int i = 0; i < adjacentMMatrix.GetLength(0); i++)
            {
                Console.Write("{0} ", i);
                for (int j = 0; j < adjacentMMatrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("  {0}  ", adjacentMMatrix[i, j]));
                }
                Console.WriteLine();
            }
        }


        public enum AdjacentMatrixType
        {
            /// <summary>
            /// 有向无环图
            /// </summary>
            DAG=1,
            DG=2
        }

    }
}

