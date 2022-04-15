using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeList
{
    public class CustomeList<T> : IEnumerable<T>
    {
        T[] _list;

        //indexer umožní s objektem vytvořeným jako objekt pracovat přes indexy jako pole
        //public návratovýTyp this[datovýTyp indexu]
        public T this[int index]
        {
            get { return _list[index]; }
        }

        public int Capacity
        {
            get { return _list.Length; }
        }

        public int Count { get; private set; }

        public CustomeList()
        {
            Count = 0;
            _list = new T[2];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(_list[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            EnsureCapacity();

            if (index >= Count)
            {
                throw new Exception("You can insert item only at existing index, index [" + index +
                                    "] is out of list bounds");
            }

            Count++;
            Array.Copy(_list, index, _list, index + 1, Count - 1 - index);
            _list[index] = item;
        }

        private void EnsureCapacity()
        {
            if (Count >= Capacity)
            {
                ExpandArray();
            }
        }

        public void Clear()
        {
            _list = new T[2];
            Count = 0;
        }

        //přidání nového prvku do listu
        public void Add(T value)
        {
            //pokud je volné místo vložíme prvek na nové prázdné místo a metodu ukončíme
            EnsureCapacity();
            _list[Count++] = value;
        }

        private void ExpandArray()
        {
            //překročili jsme kapacitu pole
            //vytvoříme pomocné pole dvojnásobné kapacity
            T[] array = new T[Capacity * 2];
            //překopírujeme původní hodnoty do pomocného pole
            _list.CopyTo(array, 0);
            //přenastavíme původní pole pomocným
            _list = array;
        }

        //abychom mohli využít foreach musíme mít definovanou metodu GetEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                //yield return zajisti předání hodnoty a návrat do ní
                yield return _list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string content = string.Empty;
            foreach (var item in _list)
            {
                content += item;
            }

            return content;
        }
    }
}