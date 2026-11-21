using ParkFlow.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.DynamicStructure
{
    internal class Lista<T> : IEnumerable<T>, IListOperation<T> where T : class
    {
        private Node<T>? Head { get; set; }
        private Node<T>? Last { get; set; }
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsEmpty
        {
            get
            {
              return Head == null;
            }
        }

        public Lista()
        {
            _count = 0;
        }

        public Lista(IEnumerable<T> datos) : this()
        {
            foreach (T dato in datos)
            {
                Add(dato);
            }
        }

        public void Add(T data)
        {
            Node<T> n = new Node<T>(data);
            if (IsEmpty)
            {
                Head = n;
                Last = n;
            }
            else
            {
                n.Back = Last;
                Last!.Next = n;
                Last = n;
            }
            _count++;
        }

        public void Delete(T data)
        {
            Node<T>? temp = Head;
            while (temp != null && temp.Data != data)
            {
                temp = temp.Next;
            }

            if (temp == null) return;

            if (temp.Back == null)
            {
                Head = temp.Next;
            }
            else
            {
                temp.Back.Next = temp.Next;
            }
            if (temp.Next == null)
            {
                Last = temp.Back;
            }
            else
            {
                temp.Next.Back = temp.Back;
            }

            _count--;
        }

        public T? ElementAt(int position)
        {
            if (position < 0 || position >= Count)
            {
                return null;
            }

            Node<T>? temp = Head;
            for (int i = 0; i < position; i++)
            {
                temp = temp!.Next;
            }
            return temp!.Data;
        }

        public void Set(int index, T data)
        {
            if (index < 0 || index >= Count) return;

            Node<T>? temp = Head;
            for (int i = 0; i < index; i++)
            {
                temp = temp!.Next;
            }
            temp!.Data = data;
        }

        public void Clear()
        {
            Head = null;
            Last = null;
            _count = 0;
        }

        public T? FirstOrDefault(Predicate<T> check)
        {
            Node<T>? temp = Head;
            while (temp != null)
            {
                if (check(temp.Data))
                {
                    return temp.Data;
                }
                temp = temp.Next;
            }
            return null;
        }

        public int FindIndex(Predicate<T> check)
        {
            Node<T>? temp = Head;
            int index = 0;
            while (temp != null)
            {
                if (check(temp.Data)) return index;
                temp = temp.Next;
                index++;
            }
            return -1;
        }

        public bool Exists(Predicate<T> check)
        {
            return FindIndex(check) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? temp = Head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
