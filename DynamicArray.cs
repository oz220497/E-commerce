using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class DynamicArray<T>
    {
        private List<T> items;

        public DynamicArray()
        {
            items = new List<T>();
        }

        public int GetSize()
        {
            return items.Count;
        }

        public List<T> GetItems()
        {
            return items;
        }

        public void AddLast(T item)
        {
            items.Add(item);
        }

        public void AddFirst(T item)
        {
            items.Insert(0, item);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void Delete(T item)
        {
            items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }
    }

}
