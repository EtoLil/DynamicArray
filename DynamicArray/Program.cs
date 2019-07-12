using System;

namespace DynamicArray
{
    public class DynamicArray<T>
    {
        private T[] data;
        private int count;

        public DynamicArray() : this(4) {}

        public DynamicArray(int size)
        {
            data = new T[size];
            count = 0;
        }

        private void resize()
        {
            int capacity = data.Length == 0 ? 4 : data.Length * 2;
            T[] newArr = new T[capacity];

            data.CopyTo(newArr,0);

            data = newArr;
        }

        public bool isFull()
        {
            return count == data.Length;
        }

        public void Add(T item)
        {
            if (this.isFull())
                this.resize();

            data[count++] = item;
        }

        public void Insert(T item, int index)
        {
            if (index>count)
                return;
            if (this.isFull())
                this.resize();

            Array.Copy(data, index, data, index + 1, count - index);
            data[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            int shiftStart = index + 1;

            if (shiftStart<count)//if item not last
            {
                Array.Copy(data, shiftStart, data, index, count - shiftStart);
            }

            count--;
            data[count] = default(T);
        }

        public bool Remove(T item)
        {
            for (int i=0;i<count;++i)
            {
                if (data[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i=0; i<count;++i)
            {
                if (data[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            for (int i=0;i<count;++i)
            {
                if (data[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void Display()
        {
            for (int i=0; i<count;++i)
            {
                Console.Write(data[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }




    class Program
    {
        
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>(5);

            #region Add

            Console.WriteLine("Add");
            dynamicArray.Add(1);
            dynamicArray.Add(4);
            dynamicArray.Add(16);
            dynamicArray.Display();

            #endregion

            #region Insert

            Console.WriteLine("Insert item '45' to the position 2");
            dynamicArray.Insert(45,2);
            dynamicArray.Display();

            #endregion

            #region Add

            Console.WriteLine("Add");
            dynamicArray.Add(3);
            dynamicArray.Add(49);
            dynamicArray.Display();

            #endregion

            #region Remove

            int item1 = 3;
            string nameMethod = "Remove";
            if (dynamicArray.Contains(item1))
                nameMethod += " " + item1;
            Console.WriteLine(nameMethod);
            dynamicArray.Remove(3);
            dynamicArray.Display();

            #endregion

            #region RemoveAt

            Console.WriteLine("RemoveAt (position 3)");
            dynamicArray.RemoveAt(3);
            dynamicArray.Display();

            #endregion

            #region IndexOf

            Console.WriteLine("IndexOf (item 49)");
            Console.WriteLine("position - "+dynamicArray.IndexOf(49));

            #endregion

            Console.ReadKey();

        }
    }
}
