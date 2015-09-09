using ModelingObjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class OracleDiceProvider : DiceProvider
    {
        Queue<int> results = new Queue<int>();
        public static DiceProvider previousDiceProvider;

        public OracleDiceProvider Add(int val, int count = 1)
        {
            for (int i = 0; i < count; i++)
                results.Enqueue(val);
            return this;
        }

        public void Build()
        {
            previousDiceProvider = DiceProvider.Instance;
            DiceProvider.instance = this;
        }

        public static void Reset()
        {
            //if (previousDiceProvider == null)
            //{
                DiceProvider.instance = null;
                previousDiceProvider = new DiceProvider();//.Instance;
           // }
           // DiceProvider.instance = previousDiceProvider;
        }

        public override int Throw(int n, int k)
        {
            var val = results.Dequeue();
            return val;
        }
    }
}
