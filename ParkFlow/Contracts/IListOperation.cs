using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Contracts
{
    internal interface IListOperation<T> where T : class
    {
        void Add(T data);
        void Set(int index, T data);
        void Delete(T data);
        void Clear();

        T? ElementAt(int position);
        T? FirstOrDefault(Predicate<T> check);
        int FindIndex(Predicate<T> check);
        bool Exists(Predicate<T> check);
    }

}

