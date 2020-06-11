using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.RemoveZeroSumSublists
{
    public class ListNode
    {
        public int val;
        public ListNode Next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.Next = next;
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
    }
}
