using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Store.CounterStore
{

//    Why we use classed rather then strng const
//As action may noy only carry info abot the name      about the type
//But also functional info

    public class DecrementAction : IAction
    {
        public const string DECREMENT = "DECREMENT";
        public string Name => DECREMENT;
    }
}
