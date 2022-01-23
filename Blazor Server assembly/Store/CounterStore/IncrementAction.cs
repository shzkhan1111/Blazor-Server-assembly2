using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Store.CounterStore
{
    //use polymorphism as dispatcher need to dispatch 
    //many action 
    public class IncrementAction : IAction
    {
        public const string INCREMENT = "INCREMENT";
        public string Name => INCREMENT;
    }
}
