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

        public OracleDiceProvider Add(int val)
        {
            results.Enqueue(val);
            return this;
        }

        public void Build()
        {
            DiceProvider.instance = this;
        }

        public override int Throw(int n, int k)
        {
            var val = results.Dequeue();
            return val;
        }
    }
}
