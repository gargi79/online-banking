

namespace HelloWorld
{
    class LinkedListNode
    {
        private int number;

        public int Value
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0) number = value;
            }
        }

        public LinkedListNode(int n)
        {
            Value = n;
        }
    }
}