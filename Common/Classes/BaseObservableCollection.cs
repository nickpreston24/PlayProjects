﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;

namespace Common.Classes
{
    public class BaseObservableCollection<T> : ObservableCollection<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        public BaseObservableCollection() : base() { }

        public BaseObservableCollection(IEnumerable<T> items) : base(items) { }

        public BaseObservableCollection(List<T> items) : base(items) { }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            //MSDN - use BlockReentrancy
            using (BlockReentrancy())
            {
                if (CollectionChanged != null)
                {
                    // Walk thru invocation list
                    foreach (NotifyCollectionChangedEventHandler handler in CollectionChanged.GetInvocationList())
                    {
                        DispatcherObject dispatcherObject = handler.Target as DispatcherObject;

                        // If the subscriber is a DispatcherObject and different thread
                        if (dispatcherObject != null && dispatcherObject.CheckAccess() == false)
                        {
                            // Invoke handler in the target dispatcher's thread
                            dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, handler, this, e);
                        }
                        else
                        {
                            // Execute handler as is
                            handler(this, e);
                        }
                    }
                }
            }
        }

    }
}
