using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    public class Dijkstra : BaseShortest
    {
        public override int[] GetShortestList(int[,] adjacentMatrix, int s)
        {
            int[] shortestList = new int[adjacentMatrix.GetLength(0)];
            //初始化最短路径集合
            for(int i=0;i<shortestList.Length;i++)
            {
                shortestList[i] = 9999;
            }
            //s->s最短为0
            shortestList[s] = 0;
            
            //待处理订单集合，值为1表示有效，0表示无效
            int[] vertexList = new int[adjacentMatrix.GetLength(0)];
            for (int i = 0; i < vertexList.Length; i++)
            {
                vertexList[i] = 1;
            }

            //取顶点集合中shortest[i]最小值，并从集合中删除
            //与其他订单执行放松步骤
            while (vertexList.Count(x=>x==1)!= 0)
            {
                int vertex = GetShortestIndex(vertexList, shortestList);
                vertexList[vertex] = 0;
                for(int i=0;i<shortestList.Length;i++)
                {
                    Releax(adjacentMatrix, shortestList, vertex, i);
                }
            }

            return shortestList;

        }

        /// <summary>
        /// 返回顶点集合中shortest最小的顶点
        /// </summary>
        /// <param name="vertexList">顶点集合</param>
        /// <param name="shortestList">最短路径集合</param>
        /// <returns></returns>
        private int GetShortestIndex(int[] vertexList,int[] shortestList)
        {
            int shortestVertex = -1;
            int shortestValue = 999;
            for(int i=0;i<vertexList.Length;i++)
            {
                if(vertexList[i]==0)
                {
                    continue;
                }
                if (shortestList[i] < shortestValue)
                {
                    shortestVertex = i;
                    shortestValue = shortestList[i];
                }
            }
            return shortestVertex;
        }
    }
}
