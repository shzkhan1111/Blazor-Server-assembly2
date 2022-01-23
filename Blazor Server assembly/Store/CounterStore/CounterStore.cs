using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Store.CounterStore
{

    public class CounterState
    {
        public int Count { get; }//immuaatble
        public CounterState(int c)
        {
            Count = c;
        }
    }

    public class CounterStore
    {
        //Use it here 
        private CounterState _counterState;
        public CounterStore()
        {
            _counterState = new CounterState(0);
        }

        //expose a Get state method
        public CounterState GetState()
        {
            return _counterState;
        }

        //adding an increment counter method
        public void Increment()
        {
            var count = this._counterState.Count;
            count++;
            //create an other counter state as it is immutable
            this._counterState = new CounterState(count);
            BroadCastChange();
        }
        //adding an increment counter method
        public void Decrement()
        {
            var count = this._counterState.Count;
            count-- ;
            //create an other counter state as it is immutable
            this._counterState = new CounterState(count);
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
