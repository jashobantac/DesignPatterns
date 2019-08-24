using System;
using System.Diagnostics.Tracing;
using System.Windows;

namespace CSharpAndWPF.Common
{
    internal class EventManagerBase<T> : WeakEventManager
    {

        private EventManagerBase()
        {
        }

        /// <summary>
        /// Add a handler for the given source's event.
        /// </summary>
        public static void AddHandler(EventSource source, EventHandler<T> handler)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            CurrentManager.ProtectedAddHandler(source, handler);
        }

        /// <summary>
        /// Remove a handler for the given source's event.
        /// </summary>
        public static void RemoveHandler(EventSource source, EventHandler<T> handler)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            CurrentManager.ProtectedRemoveHandler(source, handler);
        }

        /// <summary>
        /// Get the event manager for the current thread.
        /// </summary>
        private static EventManagerBase<T> CurrentManager
        {
            get
            {
                Type managerType = typeof(EventManagerBase<T>);
                EventManagerBase<T> manager =
                    (EventManagerBase<T>)GetCurrentManager(managerType);

                // at first use, create and register a new manager
                if (manager == null)
                {
                    manager = new EventManagerBase<T>();
                    SetCurrentManager(managerType, manager);
                }

                return manager;
            }
        }

        /// <summary>
        /// Return a new list to hold listeners to the event.
        /// </summary>
        protected override ListenerList NewListenerList()
        {
            return new ListenerList();
        }


        /// <summary>
        /// Listen to the given source for the event.
        /// </summary>
        protected override void StartListening(object source)
        {
            EventSource typedSource = (EventSource)source;
            //typedSource.SomeEvent += new EventHandler<SomeEventEventArgs>(OnSomeEvent);
        }

        /// <summary>
        /// Stop listening to the given source for the event.
        /// </summary>
        protected override void StopListening(object source)
        {
            EventSource typedSource = (EventSource)source;
            //typedSource.SomeEvent -= new EventHandler<SomeEventEventArgs>(OnSomeEvent);
        }

        /// <summary>
        /// Event handler for the SomeEvent event.
        /// </summary>
        //void OnSomeEvent(object sender, SomeEventEventArgs e)
        //{
        //    DeliverEvent(sender, e);
        //}
    }
}
