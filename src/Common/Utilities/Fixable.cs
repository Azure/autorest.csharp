// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace AutoRest.Core.Utilities
{
    [DebuggerDisplay("{DebuggerValue,nq}")]
    public class Fixable<T>
    {
        [JsonProperty("fixed")]
        public bool IsFixed { get; protected set; }

        [JsonIgnore]
        private string DebuggerValue => IsFixed || (OnGet == null) ? $"\"{Value}\"" : $"\"{Value}\" (#:\"{RawValue}\")";

        public event Func<T, T> OnGet;
        public event Func<T, T> OnSet;

        public static implicit operator T(Fixable<T> d) => d.Value;
        public static implicit operator Fixable<T>(T d) => new Fixable<T> {RawValue = d};

        public override string ToString() => Value?.ToString();

        public static bool operator ==(T y, Fixable<T> x)
        {
            if (ReferenceEquals(null, y))
            {
                return ReferenceEquals(x, null) || (ReferenceEquals(null,x.Value));
            }
            return !ReferenceEquals(x, null) && Equals(y, x.Value);
        }

        public static bool operator !=(T y, Fixable<T> x) => !(y == x);


        public static bool operator ==(Fixable<T> x, Fixable<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null))
            {
                return ReferenceEquals(null,y.Value);
            }
            if (ReferenceEquals(y, null))
            {
                return ReferenceEquals(null,x.Value);
            }
            if (x.Value == null && y.Value == null)
            {
                return true;
            }
            if (x.Value == null )
            {
                return false;
            }
            return x.Value.Equals(y.Value);
        }

        public static bool operator !=(Fixable<T> x, Fixable<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj,null))
            {
                return ReferenceEquals(null,Value);
            }

            var fixable = obj as Fixable<T>;
            if (!ReferenceEquals(fixable,null))
            {
                return Equals(fixable.Value, Value);
            }
            if (obj is T)
            {
                return Equals(obj, RawValue);
            }
            return false;
        }

        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        public Fixable()
        {
        }

        public Fixable(T value)
        {
            RawValue = value;
        }

        public Fixable(Func<T, T> onGet)
        {
            OnGet += onGet;
        }

        public Fixable(Func<T, T> onGet, Func<T, T> onSet)
        {
            OnGet += onGet;
            OnSet += onSet;
        }

        private static T Invoke(MulticastDelegate dlg, T value)
        {
            foreach (Func<T, T> evnt in dlg?.GetInvocationList() ?? Enumerable.Empty<Delegate>())
            {
                value = evnt(value);
            }
            return value;
        }

        [JsonIgnore]
        private T Value
        {
            get
            {
                if (!IsFixed && (OnGet != null))
                {
                    return Invoke(OnGet, RawValue);
                }
                return RawValue;
            }
            set
            {
                IsFixed = false;
                RawValue = Invoke(OnSet, value);
            }
        }

        [JsonProperty("raw")]
        public T RawValue { get; set; }
    }
}