using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSearch
{
    public abstract class BaseShortest
    {
        public int[] PredVertexs = new int[DataGenerator.LENGTH];
        private List<int>[] _pathList;
        public List<int>[] PathList
        {
            get {
                if (_pathList != null)
                {
                    return _pathList;
                }
                _pathList = new List<int>[PredVertexs.Length];
                for (int i = 0; i < PredVertexs.Length; i++)
                {
                    _pathList[i] = new List<int>();
                    int pred = PredVertexs[i];
                    while (pred >= 0)
                    {
                        _pathList[i].Add(pred);
                        pred = PredVertexs[pred];
                    }
                }
                return _pathList;
            }
        }
        public BaseShortest()
        {
            for(int i=0;i<PredVertexs.Length;i++)
            {
                PredVertexs[i] = -1;
            }
        }


        /// <summary>
        /// 松弛步骤relaxation steps
        /// </summary>
        /// <param name="adjacentMatrix"></param>
        /// <param name="shortestList"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Releax(int[,] adjacentMatrix, int[] shortestList, int start, int end)
        {
            //start的最短权重+（start,end)边的最短权重，小于目前end的最短权重，则更新end
            if (adjacentMatrix[start, end] != 0)
            {
                if (shortestList[start] + adjacentMatrix[start, end] < shortestList[end])
                {
                    shortestList[end] = shortestList[start] + adjacentMatrix[start, end];
                    PredVertexs[end] = start;
                }
            }
        }

        public abstract int[] GetShortestList(int[,] adjacentMatrix, int s);

    }
}
