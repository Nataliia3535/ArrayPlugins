using BasePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPluginFind
{
    public class FindMax : IArrayBase
    {
        public string Name => "Find max element";

        public int RunPlugin(int[] arr)
        {
            int max = arr.Max();
            return max;
        }
    }
}
