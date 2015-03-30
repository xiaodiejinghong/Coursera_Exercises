using System;
using System.Linq;

namespace week1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //quick find
            var qf = new QucikFind(10);
            qf.Union(8, 1);
            qf.Union(9, 4);
            qf.Union(7, 8);
            qf.Union(8, 0);
            qf.Union(8, 9);
            qf.Union(7, 5);

            Console.WriteLine(string.Join(" ", qf.GetArr()));


            var qu = new QuickUnion(10);
            qu.Union(7, 3);
            qu.Union(0, 4);
            qu.Union(1, 6);
            qu.Union(0, 6);
            qu.Union(9, 7);
            qu.Union(3, 5);
            qu.Union(7, 8);
            qu.Union(2, 8);
            qu.Union(3, 4);

            Console.WriteLine(string.Join(" ", qu.GetArr()));



            Console.ReadKey();
        }
    }

    internal class QucikFind
    {
        private int[] arr;

        public QucikFind(int seed)
        {
            this.Init(seed);
        }

        private void Init(int seed)
        {
            arr = new int[seed];
            for (int i = 0; i < this.arr.Count(); i++)
            {
                arr[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            if (this.Connected(p, q)) return;
            int tmp = arr[p];
            for (int i = 0; i < this.arr.Count(); i++)
                if (arr[i] == tmp)
                    arr[i] = arr[q];
        }

        public bool Connected(int p, int q)
        {
            return arr[p] == arr[q];
        }

        public int[] GetArr()
        {
            return this.arr;
        }
    }

    internal class QuickUnion
    {
        private int[] arr;

        private int[] deep;

        private void Init(int seed)
        {
            this.arr = new int[seed];
            this.deep = new int[seed];
            for (int i = 0; i < seed; i++)
            {
                this.arr[i] = i;
                this.deep[i] = 1;
            }
            
        }

        public QuickUnion(int seed)
        {
            this.Init(seed);
        }

        private int Root(int i)
        {
            while (this.arr[i] != i)
            {
                i = arr[i];
            }
            return i;
        }

        public bool Connected(int p, int q)
        {
            return this.Root(p) == this.Root(q);
        }

        public void Union(int p, int q)
        {
            var rootP = this.Root(p);
            var rootQ = this.Root(q);
            if (rootQ == rootP) return;
            if (this.deep[rootP] >= this.deep[rootQ])
            {
                this.arr[rootQ] = rootP;
                this.deep[rootP] += this.deep[rootQ];
            }
            else
            {
                this.arr[rootP] = rootQ;
                this.deep[rootQ] += rootP;
            }
        }

        public int[] GetArr()
        {
            return this.arr;
        }

    }
}
