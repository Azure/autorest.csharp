// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace AutoRest.Core.Utilities
{
    public static class DependencyInjection
    {
        private class Activation : IDisposable
        {
            private static readonly AsyncLocal<Guid?> LodisContext = new AsyncLocal<Guid?>();
            private static readonly Dictionary<Guid, Activation> Activations = new Dictionary<Guid, Activation>();

            private readonly Guid _id = Guid.NewGuid();
            private readonly Activation _parent;
            private bool _disposed;
            private Context _context;

            // upon activation, we start at count 1
            private int _refCount = 1;

            private void Increment()
            {
                Interlocked.Increment(ref _refCount);
            }

            private void Decrement()
            {
                if (_context == null) return;

                Interlocked.Decrement(ref _refCount);
                if (_refCount != 0) return;

                // ok, cleanup.
                // unhook ourself
                Current = _parent;

                // remove ourselves from the Activations collection
                lock (typeof(Activation))
                {
                    Activations.Remove(_id);
                }

                // drop the reference to the DI factories.
                _context = null;

                // remove the reference to the parent. (which can cause them to disappear if they are done)
                _parent?.Decrement();
            }

            public Activation(Context contextToActivate)
            {
                _parent = Current;
                _parent?.Increment();
                _context = contextToActivate;
                lock (typeof(Activation))
                {
                    Activations.Add(_id, this);
                }
                Current = this;
                _context.PerformOnActivate();
            }

            private static Activation Current
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
                    LodisContext.Value = value?._id;
                }
            }

            public void Dispose()
            {
                if (_disposed) return;
                _disposed = true;
                Decrement();
            }
        }

        private class Context : IEnumerable<Factory>
        {
            private readonly Dictionary<Type, Factory> _factories = new Dictionary<Type, Factory>();
            private event Action OnActivate;

            public IEnumerator<Factory> GetEnumerator() => _factories.Values.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IDisposable Activate() => new Activation(this);

            protected internal void PerformOnActivate()
            {
                OnActivate?.Invoke();
            }
        }

        public static IDisposable NewContext => new Context().Activate();
    }
}