using System;

namespace Delegate
{
    public class B
    {
        private A a;

        public B(A a)
        {
            this.a = a;
            a.RaiseEvent += new RaiseEventHandler(A_RaiseEvent);
            a.FallEvent += new FallEventHandler(A_FallEvent);
        }

        void A_RaiseEvent(string hand)
        {
            if (hand.Equals("左"))
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
            Console.WriteLine("部下B发起攻击");
        }
    }
}