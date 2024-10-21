using System;
namespace HeapsDsa
{
    public class Heaps
    {
        private int[] item = new int[10];
        private int size = 0;
        public void insert(int val)
        {
            if (isfull())
            {
                throw new Exception("item is full");
            }
            item[size++] = val;
            BubbleUp();
        }
        public bool isfull()
        {
            return size == item.Length;
        }
        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && item[index] > item[parent(index)])
            {
                swap(index, parent(index));
                index = parent(index);
            }

        }
        private int parent(int index)
        {
            return (index - 1) / 2;
        }
        private void swap(int fist, int second)
        {
            var temp = item[fist];
            item[fist] = item[second];
            item[second] = temp;
        }
        public int Remove()
        {
            if(ISEMPTY())
            {
                throw new Exception("empty heap");
            }
            var root = item[0];
            item[0] = item[--size];
            bubbledown();
            return root;
        }
        private void bubbledown()
        {
            var index = 0;
            while (index<=size&&isvalidparent(index))
            {
                var largerchild = largerchildindex(index);
                swap(index, largerchild);
                index = largerchild;
            }

        }
        private bool hasleftchild(int index)
        {
            return leftchild(index) <= size; 
        }
        private bool hasrightchild(int index)
        {
            return rightchild(index) <= size;
        }
        public bool ISEMPTY()
        {
            return size == 0;
        }
        private int largerchildindex(int index)
        {
            if(!hasleftchild(index))
            {
                return index;
            }
            if(!hasrightchild(index))
            {
                return rightchild(index);
            }
            return (left(index) > right(index)) ?
                               leftchild(index) : rightchild(index);
           
        }
        private bool isvalidparent(int index)
        {
            if (!hasleftchild(index))
            {
                return true;
            }
            var isvald = item[index]>=left(index);
            if(hasrightchild(index))
            {
                isvald&=item[index] >= right(index);
            }
            return isvald;
        }
        private int left(int index)
        {
            return item[leftchild(index)];
        } private int right(int index)
        {
            return item[rightchild(index)];
        }
        private int leftchild(int index)
        {
            return index * 2 + 1;
        }
        private int rightchild(int index)
        {
            return index * 2 + 2;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Heaps heaps = new Heaps();
            int[] array = { 5,10,3,1,4,2 };
            foreach(int i in array)
            {
                heaps.insert(i);
            }
            for(int count=0;count<array.Length;count++)
            {
                array[count] = heaps.Remove();
            }
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}
