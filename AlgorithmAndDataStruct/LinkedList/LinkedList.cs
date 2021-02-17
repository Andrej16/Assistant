namespace AlgorithmAndDataStruct.LinkedList
{
    public class LinkedList<T>
    {
        public LinkedListNode<char> Head;
        public LinkedListNode<char> Tail;
        public int Count;
        public string Fill(string text)
        {
            foreach (char c in text)
            {
                var node = new LinkedListNode<char>(c);
                if (Head is null)
                {
                    Head = node;
                }
                else
                {
                    Tail.Next = node;
                    node.Prew = Tail;
                }
                Tail = node;
                Count++;
            }
            return ToString();
        }
        public override string ToString()
        {
            char[] current = new char[Count];
            LinkedListNode<char> node = Head;
            int index = 0;
            while (node != null)
            {
                current[index] = node.Value;
                node = node.Next;
                index++;
            }
            return new string(current);
        }
        private LinkedListNode<char> WholeWordPosition(string text, string pattern, int start)
        {
            LinkedList<char> textList = new LinkedList<char>();
            textList.Fill(text);
            LinkedList<char> patternList = new LinkedList<char>();
            patternList.Fill(pattern);
            LinkedListNode<char> tCurr = textList.Head;
            LinkedListNode<char> pCurr = patternList.Head;
            LinkedListNode<char> startNode = null;
            int coinCount = 0;

            while (tCurr != null)
            {
                if(coinCount == 0)
                {
                    if(tCurr.Value == '\u0020' //пробел
                        || tCurr.Value == '\u000A' //новая строка 
                        || tCurr.Value == '\u0028' //левая скобка - (
                        || tCurr.Value == '\u0025' //%
                        || tCurr.Value == '\u002E')
                        coinCount++;
                    tCurr = tCurr.Next;
                    continue;
                }
                if (tCurr.Value == pCurr.Value)
                {
                    if (coinCount == 1) //с учетом пустого символа
                    {
                        startNode = tCurr.Prew;
                    }
                    pCurr = pCurr.Next;
                    coinCount++;
                }
                else if (coinCount > 0)//reset
                {
                    pCurr = patternList.Head;
                    coinCount = 0;
                    startNode = null;
                }
                if (coinCount == patternList.Count + 1)     //с учетом пустого символа
                {
                    LinkedListNode<char> temp = tCurr.Next;
                    if (temp.Value == '\u0020' //пробел
                        || temp.Value == '\u000A' //новая строка 
                        || temp.Value == '\u0028' //левая скобка - (
                        || temp.Value == '\u0025' //%
                        || temp.Value == '\u002E')
                        break;
                    else
                    {
                        pCurr = patternList.Head;
                        coinCount = 0;
                        startNode = null;
                    }
                }
                tCurr = tCurr.Next;
            }
            return startNode;
        }
    }
}
