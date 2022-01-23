﻿using System;

namespace Blazor_Server_assembly.Store
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        void Subscribe(Action<IAction> actionHandler);
        void Unsubscribe(Action<IAction> actionHandler);
    }
}