// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using AutoRest.Core.Utilities.Collections;
using AutoRest.Core.Logging;

namespace AutoRest.Core.Utilities
{
    public static class DependencyInjection
    {
        internal class Activation : IDisposable
        {
            private static AsyncLocal<Guid?> LodisContext = new AsyncLocal<Guid?>();
            internal static Dictionary<Guid, Activation> Activations = new Dictionary<Guid, Activation>();

            internal readonly Guid Id = Guid.NewGuid();
            internal readonly Activation Parent;
            private bool _disposed;
            protected internal Context Context;
            protected internal Dictionary<Type, object> Singletons = new Dictionary<Type, object>();

            // upon activation, we start at count 1
            private int _refcount = 1;

            private void Increment()
            {
                Interlocked.Increment(ref _refcount);
            }

            private void Decrement()
            {
                if (Context != null)
                {
                    Interlocked.Decrement(ref _refcount);
                    if (_refcount == 0)
                    {
                        // ok, cleanup.
                        // unhook ourself
                        Current = Parent;

                        // remove ourselves from the Activations collection
                        lock (typeof(Activation))
                        {
                            Activations.Remove(Id);
                        }

                        // drop the reference to the DI factories.
                        Context = null;

                        // drop the singletons
                        Singletons = null;

                        // remove the reference to the parent. (which can cause them to disappear if they are done)
                        Parent?.Decrement();
                    }
                }
            }

            public Activation(Context contextToActivate)
            {
                Parent = Current;
                Parent?.Increment();
                Context = contextToActivate;
                lock (typeof(Activation))
                {
                    Activations.Add(Id, this);
                }
                Current = this;
                Context.PerformOnActivate();
#if DEBUG
                // Let's verify that the Context's factories have 
                // correctly implemented constructors of the base 
                // class.
                foreach (var factory in Context)
                {
                    // For each of the actual constructors for the actual target type,
                    // do each of the constructors of the target type have an 
                    // implementation in factory?
                    foreach( var missingConstructor in factory.TargetTypeConstructors.Where( each => factory.GetConstructorImplementation(each.ParameterTypes()) == null ) )
                    {
                        Logger.Instance.Log(Category.Warning, $"Factory for type {factory.TargetType.FullName} does not have a constructor for parameters ({missingConstructor.ParameterTypes().ToTypesString()})");
                    }

                }
#endif
            }

            protected internal static Activation Current
            {
                get
                {
                    var id = LodisContext.Value;
                    lock (typeof(Activation))
                    {
                        return id != null ? Activations[(Guid) id] : null;
                    }
                }
                set
                {
                    LodisContext.Value = value?.Id;
                }
            }

            protected internal static Activation Default
            {
                get
                {
                    var activation = Current;
                    if (activation == null)
                    {
                        new Context().Activate();
                    }
                    return Current;
                }
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _disposed = true;
                    Decrement();
                }
            }
        }

        public class IsSingleton<T>
        {
            public static T Instance => Singleton<T>.Instance;
        }

        public class Singleton<T>
        {
            public static bool HasInstanceInCurrentActivation => Activation.Current.Singletons.ContainsKey(typeof(T));

            public static bool HasInstance
            {
                get
                {
                    for (var c = Activation.Current; c != null; c = c.Parent)
                    {
                        if (c.Singletons.ContainsKey(typeof(T)))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public static T Instance
            {
                get
                {
                    // check for the exact match
                    for (var c = Activation.Current; c != null; c = c.Parent)
                    {
                        if (c.Singletons.ContainsKey(typeof(T)))
                        {
                            return (T)c.Singletons[typeof(T)];
                        }
                    }

                    // check for anything that is inherited
                    for (var c = Activation.Current; c != null; c = c.Parent)
                    {
                        foreach (var item in c.Singletons.Values)
                        {
                            if (item is T)
                            {
                                return (T)item;
                            }
                        }
                    }
                    return default(T);
                }
                set { Activation.Default.Singletons.AddOrSet(typeof(T), value); }
            }

            /// <summary>
            /// Retrieves the singleton of this but also the parent contexts, if existing.
            /// </summary>
            public static IEnumerable<T> RecursiveInstances
            {
                get
                {
                    Type key = typeof(T);
                    for (var c = Activation.Current; c != null; c = c.Parent)
                    {
                        if (c.Singletons.ContainsKey(key))
                        {
                            yield return (T)c.Singletons[key];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Convenience methods for singletons that are of type IEnumerable&lt;T&gt;
        /// </summary>
        public class SingletonList<T>
        {
            /// <summary>
            /// Adds given item to the current context.
            /// </summary>
            public static void Add(T item)
            {
                if (!Activation.Current.Singletons.ContainsKey(typeof(IEnumerable<T>)))
                {
                    Activation.Current.Singletons[typeof(IEnumerable<T>)] = Enumerable.Empty<T>();
                }
                Activation.Current.Singletons[typeof(IEnumerable<T>)] = (Activation.Current.Singletons[typeof(IEnumerable<T>)] as IEnumerable<T>).Concat(new[] { item });
            }

            /// <summary>
            /// For retrieving singletons that are lists while also considering the list items of parent contexts.
            /// </summary>
            public static IEnumerable<T> RecursiveInstances
            {
                get
                {
                    return Singleton<IEnumerable<T>>.RecursiveInstances.SelectMany(list => list);
                }
            }
        }

        public class Context : IEnumerable<Factory>
        {
            private readonly Dictionary<Type, Factory> _factories = new Dictionary<Type, Factory>();
            private event Action OnActivate;

            public IEnumerator<Factory> GetEnumerator() => _factories.Values.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IDisposable Activate() => new Activation(this);

            public static bool IsActive => Activation.Current != null;

            protected internal void PerformOnActivate()
            {
                OnActivate?.Invoke();
            }
        }

        public static IDisposable NewContext => new Context().Activate();
    }
}