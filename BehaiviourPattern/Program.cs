using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaiviourPattern
{
    class Program
    {

        public interface List:IIterable
        {
            void add(int val);
            void remove();
            int get(int index);
            int GetSize();

            Boolean isEmpty();

        }

        public class ArrayList : List
        {
            private static readonly int DEFAULT_CAPACITY = 5;
            private int size;

            [NonSerialized]
            private int[] data;

            private class ListIterator : IIterator
            {
                ArrayList l;
                private int index=0;

                public ListIterator(ArrayList _l)
                {
                    l = _l;
                }
                public bool HasNext()
                {
                    return index < l.size;
                }

                public object Next()
                {
                    return l.data[index++];
                }
            }


            public ArrayList(int s)
            {
                if (s > 0)
                {
                    data = new int[s];
                }
            }
            public ArrayList()
            {
                data = new int[DEFAULT_CAPACITY];
                size = 0;
            }
            public void add(int val)
            {
                ensureCapacity(size + 1);
                data[size++] = val;
            }

            public int get(int index)
            {
                try
                {
                    return data[index];
                }
                catch (Exception)
                {
                    Console.WriteLine("out of range");
                    return -1;
                }
            }

            public bool isEmpty()
            {
                return size == 0;
            }

            public void remove()
            {
                size--;
            }

            public int GetSize()
            {
                return size;
            }

            public IIterator Iterator()
            {
                return new ListIterator(this);
            }


            private  void ensureCapacity(int minCapacity)
            {
                if (this.data.Length < minCapacity)
                {
                    int[] helper = new int[minCapacity * 2];
                    Array.Copy(data, helper, data.Length);
                    data = helper;
                }
            }
        }

        static void Main(string[] args)
        {
            List l = new ArrayList();
            l.add(5);
            l.add(7);
            l.add(6);
            l.add(7);
            l.add(8);
            l.add(9);
            l.add(2);
            l.add(1);

          
            IIterator iter = l.Iterator();


            while (iter.HasNext())
            {
                Console.WriteLine(iter.Next());
            }

            Console.ReadKey();
        }
    }
}
