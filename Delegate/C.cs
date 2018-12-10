using System;

namespace Delegate
{
    public class C
    {
        private A a;

        public C(A a)
        {
            this.a = a;
            a.RaiseEvent += new RaiseEventHandler(A_RaiseEvent);
            a.FallEvent += new FallEventHandler(A_FallEvent);
        }

        void A_RaiseEvent(string hand)
        {
            if (hand.Equals("右"))
            {
                Attack();
            }
        }

        void A_FallEvent()
        {
            Attack();
        }

        public void Attack()
        {
            Console.WriteLine("部下C发起攻击");
        }
    }
}