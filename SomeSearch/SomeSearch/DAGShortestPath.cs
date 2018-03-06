using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    /// <summary>
    /// 有向无环图最短路径
    /// </summary>
    public class DAGShortestPath : BaseShortest
    {
        public override int[] GetShortestList(int[,] adjacentMatrix, int s)
        {
            var topologicalList = TopologicalSort(adjacentMatrix);
            var node = topologicalList.First;

            int[] shortestList = new int[adjacentMatrix.GetLength(0)];
            for (int i = 0; i < shortestList.Length; i++)
            {
                shortestList[i] = 999999;//本来用int.max,但是比较的时候会导致溢出
            }
            shortestList[s] = 0;

            while (node.Next != null)
            {
                for(int i=0;i<adjacentMatrix.GetLength(0);i++)
                {
                    Releax(adjacentMatrix, shortestList, node.Value,i);
                }
                
                node = node.Next;
            }

            Console.WriteLine("Start vertex:{0}", s);
            for (int i = 0; i < shortestList.Length; i++)
            {
                Console.WriteLine("vertex:{0},shortest:{1}", i, shortestList[i]);
            }
            return shortestList;
        }

        /// <summary>
        /// 拓扑排序
        /// </summary>
        /// <param name="adjacentMatrix">邻接矩阵</param>
        /// <returns></returns>
        public LinkedList<int> TopologicalSort(int[,] adjacentMatrix)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            int[] inDegreeList = new int[adjacentMatrix.GetLength(0)];
            Stack<int> startVertex = new Stack<int>();

            //计算顶点入度
            for (int i = 0; i < adjacentMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacentMatrix.GetLength(1); j++)
                {
                    if (adjacentMatrix[i, j] != 0)
                    {
                        inDegreeList[j]++;
                    }
                }
            }

            //入度为0的顶点入起始节点栈
            for (int i = 0; i < inDegreeList.Length; i++)
            {
                if (inDegreeList[i] == 0)
                {
                    startVertex.Push(i);
                }
            }
            
            while(startVertex.Count!=0)
            {
                int vertex = startVertex.Pop();
                linkedList.AddLast(vertex);
                for (int i = 0; i < adjacentMatrix.GetLength(1); i++)
                {
                    //若(vertex,j)不为0（有边），则把j加入拓扑链表
                    if(adjacentMatrix[vertex,i]!=0)
                    {                                            
                        inDegreeList[i]--;
                        //若j的入度为0，则压如起始订顶点栈,最终生成拓扑序列
                        if(inDegreeList[i]==0)
                        {
                            startVertex.Push(i);
                        }
                    }
                    
                }
            }
            var node = linkedList.First;
            while(node!=null)
            {
                Console.Write("{0}--->", node.Value);
                node = node.Next;
            }
            Console.WriteLine();
            return linkedList;
        }


    
    }
}

