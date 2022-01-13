using BasePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationArrays
{
    public class SummArray : IArrayBase
    {
        public string Name => "Summ elements of arrays" ;

        public int RunPlugin(int[] arr)
        {
           
            int sum = arr.Sum();
            
            return sum;
           
        }
    }
}
