using System;

namespace CoreEF
{
    public class TestClass
    {
        Entry top;
        private Entry top1;
        public void Push(object data)
        {
            if (top == null)
            {
                top = new Entry(top, data);
                top1 = top.next;
            }
            else
            {
                   
                    top1.next = new Entry(top, data);
                    top1 = top1.next;
            }

            
        }

        public object Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            object result = top.data;
            top = top.next;
            return result;
        }

        class Entry
        {
            public Entry next;
            public object data;
            public Entry(Entry next, object data)
            {
                //this.next = next;
                this.data = data;
            }
        }
    }
}