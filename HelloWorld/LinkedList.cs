
using System.Collections.Generic;

namespace HelloWorld
{
    class LinkedList
    {
        public LinkedList()
        {
            Nodes = new List<LinkedListNode>();
        }
        public List<LinkedListNode> Nodes;

        public void Add(LinkedListNode node)
        {
            Nodes.Add(node);
        }
    }
}

