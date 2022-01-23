using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Store
{
    public interface IAction
    {
        ///self identify what kind of action it is 
        public string Name { get;}
    }
}
