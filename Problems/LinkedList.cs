namespace Problems.RemoveZeroSumSublists
{
    public class ListNode
    {
        public int val;
        public ListNode Next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            Next = next;
        }
    }
    public class LinkedList
    {
        public ListNode _head;
        public ListNode _tail;
        public int Count;
        public void Add(int value)
        {

            ListNode node = new ListNode(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
            Count++;
        }
        public static ListNode Merge(ListNode mainList, ListNode newNode)
        {
            ListNode head = null;//result
            ListNode current = null;//result
            bool newNodeInserted = false;
            ListNode currentMain = mainList;

            while(currentMain != null)
            {
                int newValue = newNode.val;
                int currValue = currentMain.val;
                if (!newNodeInserted && newValue <= currValue)
                {
                    //вставка первого
                    if (current is null)
                    {
                        head = newNode;
                        current = newNode;
                        current.Next = new ListNode(currValue);
                        current = current.Next;
                    }
                    else
                    {
                        current.Next = newNode;
                        current = current.Next;
                        current.Next = new ListNode(currValue);
                        current = current.Next;
                    }
                    newNodeInserted = true;
                }
                else
                {
                    //вставка первого
                    if(current is null)
                    {
                        head = new ListNode(currValue);
                        current = head;
                    }
                    else
                    {
                        current.Next = new ListNode(currValue);
                        current = current.Next;
                    }
                }
                currentMain = currentMain.Next;
            }
            return head;
        }
    }

}
