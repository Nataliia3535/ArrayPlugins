using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace BasePlugin
{
    public interface IArrayBase
    {
        int RunPlugin(int[] arr);
        string Name { get; }
    }
}
