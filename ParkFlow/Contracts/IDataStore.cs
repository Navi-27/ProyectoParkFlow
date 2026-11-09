using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Contracts
{
    internal interface IDataStore<T>
    {
        IEnumerable<T> LoadAll();
        void SaveAll(IEnumerable<T> list, IEnumerable<T> removed);
    }
}
