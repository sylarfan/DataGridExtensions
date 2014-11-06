﻿namespace DataGridExtensions
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;

    internal static partial class ExtensionMethods
    {
        /// <summary>
        /// Restarts the specified timer.
        /// </summary>
        /// <param name="timer">The timer.</param>
        internal static void Restart(this DispatcherTimer timer)
        {
            timer.Stop();
            timer.Start();
        }

        /// <summary>
        /// Walks the elements tree and returns the first element that derives from T.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="item">The item to start search with.</param>
        /// <returns>The element if found; otherwise null.</returns>
        internal static T FindAncestorOrSelf<T>(this DependencyObject item) where T : class
        {
            while (item != null)
            {
                var target = item as T;
                if (target != null)
                    return target;

                item = LogicalTreeHelper.GetParent(item) ?? VisualTreeHelper.GetParent(item);
            }

            return null;
        }

        /// <summary>
        /// Shortcut to <see cref="System.Windows.Threading.Dispatcher.BeginInvoke(Delegate, Object[])"/>
        /// </summary>
        public static void BeginInvoke(this DispatcherObject self, Action action)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            if (action == null)
                throw new ArgumentNullException("action");

            self.Dispatcher.BeginInvoke(action);
        }

        /// <summary>
        /// Shortcut to <see cref="System.Windows.Threading.Dispatcher.BeginInvoke(DispatcherPriority, Delegate)"/>
        /// </summary>
        public static void BeginInvoke(this DispatcherObject self, DispatcherPriority priority, Action action)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            if (action == null)
                throw new ArgumentNullException("action");

            self.Dispatcher.BeginInvoke(priority, action);
        }
    }
}
