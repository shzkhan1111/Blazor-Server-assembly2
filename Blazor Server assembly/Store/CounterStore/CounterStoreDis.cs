using Blazor_Server_assembly.Store.CounterStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//use this name space else CounterState will conflict
namespace Blazor_Server_assembly.Store.CounterStoreDis
{

    public class CounterStateDis
    {
        public int Count { get; }//immuaatble

        public CounterStateDis(int c)
        {
            Count = c;
        }
    }

    public class CounterStoreDis
    {
        public IActionDispatcher ActionDispatcher { get; }
        //Use it here 
        private CounterStateDis _counterState;
        public CounterStoreDis(IActionDispatcher actionDispatcher)
        {
            _counterState = new CounterStateDis(0);
            ActionDispatcher = actionDispatcher;
            //we need to register to the dispatcher 
            this.ActionDispatcher.Subscribe(HandleAction);//put here the action handler (3)
        }

        //~CounterStoreDis()
        //{
        //    //we dont need to because they are scoped to the 
        //    //same connection (have same lifespan)
        //    this.ActionDispatcher.Unsubscribe(HandleAction)
        //}

        //expose a Get state method
        public CounterStateDis GetState()
        {
            return _counterState;
        }
        //create the action Handler (3) 
        private void HandleAction(IAction action)
        {
            //choice to not handle all kind of action 
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    Increment();
                    break;
                case DecrementAction.DECREMENT:
                    Decrement();
                    break;

            }
        }

        //adding an increment counter method
        private void Increment()
        {
            var count = this._counterState.Count;
            count++;
            //create an other counter state as it is immutable
            this._counterState = new CounterStateDis(count);
            BroadCastChange();
        }
        //adding an increment counter method
        private void Decrement()
        {
            var count = this._counterState.Count;
            count-- ;
            //create an other counter state as it is immutable
            this._counterState = new CounterStateDis(count);
            BroadCastChange();
        }
        #region implement Observer Pattern 
        private Action _listeners;

       

        //register the lsteners
        public void AddStateChangedListener(Action listener)
        {
            _listeners += listener;
        }
        //remove listener
        public void RemoveStateChangedListener(Action listener)
        {
            _listeners -= listener;
        }
        //BroadCastChange
        private void BroadCastChange()
        {
            _listeners.Invoke();
        }
        #endregion
    }
}
