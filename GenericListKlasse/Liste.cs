using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListKlasse
{
    public class Liste<T> 
    {
        private T[] _liste;
        public int Count { get; private set; }

        public Liste(int count = 0)
        {
            _liste = new T[count];
            Count = count;
        }

        public T this[int index] { get { return _liste[index]; } set { _liste[index] = value; } }


        public void Add(T item) //tested
        {
            if (item.GetType() == typeof(T))
            {
                try
                {
                    T[] newList = new T[this.Count + 1];
                    _liste.CopyTo(newList,0);
                    newList[this.Count] = item;
                    _liste = newList;
                    this.Count = _liste.Count();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        
        public void AddRange(IEnumerable<T> collection)  //getestet
        {
            try
            {
                T[] newList = new T[this.Count + collection.Count()];
                _liste.CopyTo(newList, 0);
                int i = this.Count;
                foreach (var item in collection)
                {
                    newList[i] = item;
                    i++;
                }
                _liste = newList;
                this.Count = _liste.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemoveRange(int index, int count)  //getestet
        {
            try
            {
                T[] newList = new T[this.Count - count];
                for (int i = 0; i < index; i++)
                {
                    newList[i] = _liste[i];
                }
                for (int i = index; i <= newList.Count() -1; i++)
                {
                    newList[i] = _liste[i+count];
                }
                _liste = newList;
                this.Count= _liste.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemoveAt(int index)  //getestet
        {
            try
            {
                T[] listWithoutItem = new T[this.Count - 1];
                int i = -1;
                int indexCleaner = 0;
                foreach (var item in _liste)
                {
                    i++;
                    if (i == index) 
                    {
                        indexCleaner++;
                        continue;
                    }
                    listWithoutItem[i-indexCleaner] = item;
                }
                _liste = listWithoutItem;
                this.Count = _liste.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Reverse()  //tested
        {
            try
            {
                T[] listReversed = new T[this.Count];
                int i = this.Count - 1;
                foreach (var item in _liste)
                {
                    listReversed[i] = item;
                    i--;
                }
                _liste = listReversed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Clear()  //tested
        {
            try
            {
                _liste = new T[0];
                this.Count = _liste.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public T FindLast(T match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match", "The \"match\" Parameter is null");
            }
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (_liste[i].Equals(match))
                {
                    return _liste[i];
                }
            }
            return (T)(Activator.CreateInstance(typeof(T)));

        }

        public int FindLastIndex(T match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match", "The \"match\" Parameter is null");
            }
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (_liste[i].Equals(match))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Find(T match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match", "The \"match\" Parameter is null");
            }
            for (int i = 0; i <= this.Count - 1; i++)
            {
                if (_liste[i].Equals(match))
                {
                    return _liste[i];
                }
            }
            return (T)(Activator.CreateInstance(typeof(T)));

        }

        public int FindIndex(T match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match", "The \"match\" Parameter is null");
            }
            for (int i = 0; i <= this.Count - 1; i++)
            {
                if (_liste[i].Equals(match))
                {
                    return i;
                }
            }
            return -1;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_liste);
        }

        public struct Enumerator : IDisposable
        {
            public Enumerator( T[] liste)
            {
                _liste = liste;
                index = -1;
                Count = _liste.Count();
            }
            private int index { get; set; }
            private int Count { get; set; }
            private T[] _liste { get; set; }
            public T Current => _liste[index];

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (index+1 < Count)
                {
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
