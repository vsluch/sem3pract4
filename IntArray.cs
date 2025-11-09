using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sem3pract4
{
    public class IntArray
    {
        private short count;    // количество элементво
        private int[] items;    // элементы
        public short Count
        {
            get { return count; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Некорректное значение размера массива");
                count = value;
            }
        }
        public int[] Items
        {
            get { return items; }
            private set { items = value; }
        }

        public IntArray(int[] _array)
        {
            if (_array == null)
                throw new ArgumentNullException(nameof(_array));
            if (_array.Length > short.MaxValue)
                throw new ArgumentException("Размер массива превышает максимально допустимый");

            Items = _array;
            Count = (short)_array.Length;
            
        }
        // конструктор - создает массив заданной размерности с нулевыми элементами
        public IntArray(short _count)
        {
            Count = _count;
            Items = new int[_count];
            for(int i = 0; i < Count; i++)
            {
                Items[i] = 0;
            }
        }


        public override string ToString()
        {
            return string.Join(", ", Items);
        }


        public int this[int index]
        {
            get
            {
                if(index < 0 || index >= Count)
                    throw new IndexOutOfRangeException($"Индекс {index} вне диапазона [0, {Count - 1}]");
                return Items[index];
            }
            set
            {
                if(index < 0 || index >= Count)
                    throw new IndexOutOfRangeException($"Индекс {index} вне диапазона [0, {Count - 1}]");
                Items[index] = value;
            }
        }

        public bool Contains(int value)
        {
            bool isValueInArray = false;
            foreach (int item in Items)
            {
                if (item == value)
                    isValueInArray = true;
            }
            return isValueInArray;
        }

    }
}
