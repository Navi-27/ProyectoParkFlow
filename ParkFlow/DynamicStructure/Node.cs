using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.DynamicStructure
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Back { get; set; }
        public Node(T data)
        {
            Data = data;
        }
    }
}
