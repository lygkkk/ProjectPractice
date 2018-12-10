using System;

namespace Delegate
{
    public delegate void RaiseEventHandler(string hand);

    public delegate void FallEventHandler();
    public class A
    {
        public event RaiseEventHandler RaiseEvent;
        public event FallEventHandler FallEvent;
        public void Raise(string hand)
        {
            Console.WriteLine($"首领举{hand}手");
            if (RaiseEvent != null)
            {
                RaiseEvent(hand);
            }
        }

        public void Fall()
        {
            Console.WriteLine("首领摔杯");
            FallEvent?.Invoke();
        }
    }
}