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

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Heaps heaps = new Heaps();
            heaps.insert(10);
            heaps.insert(5);
            heaps.insert(17);
            heaps.insert(4);
            heaps.insert(22);
            heaps.insert(10);
        }
    }
}