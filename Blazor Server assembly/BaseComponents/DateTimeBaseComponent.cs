using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.BaseComponents
{

    //make it inherit form ComponentBase
    public class DateTimeBaseComponent : ComponentBase
    {
        public DateTime dateTime { get; set; }
    }
}
