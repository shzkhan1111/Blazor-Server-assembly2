using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Store
{
    //allow different store to sub to it
    //has to called by all lind of comp we need to do dependency injection 

    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> _registerActionHandlers;

        public void Subscribe(Action<IAction> actionHandler) => _registerActionHandlers += actionHandler;

        public void Unsubscribe(Action<IAction> actionHandler) => _registerActionHandlers -= actionHandler;

        public void Dispatch(IAction action) => _registerActionHandlers?.Invoke(action);
    }
}
