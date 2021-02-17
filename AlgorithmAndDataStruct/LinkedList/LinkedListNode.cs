namespace AlgorithmAndDataStruct.LinkedList
{
    public class LinkedListNode<T>
    {
        public T Value;
        public LinkedListNode<T> Next;
        public LinkedListNode<T> Prew { get; set; }
        public LinkedListNode(T val)
        {
            this.Value = val;
        }
    }
}
