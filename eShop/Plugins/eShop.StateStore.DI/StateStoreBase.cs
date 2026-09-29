using eShop.UseCases.PluginInterfaces.StateStore;
using System;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action listener) => listeners += listener;

        public void BroadcastStateChange()
        {
            if (listeners != null)
                listeners.Invoke();
        }

        public void RemoveStateChangeListeners(Action listener) => listeners -= listener;
    }
}
