using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.V3.Utilities
{
    public static class EqualityComparerFactory
    {
        //https://stackoverflow.com/a/18984169/294804
        public static IEqualityComparer<T> Create<T>(Func<T, int> getHashCode, Func<T, T, bool> equals) =>
            new Comparer<T>(getHashCode, equals);

        private class Comparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, int> _getHashCode;
            private readonly Func<T, T, bool> _equals;

            public Comparer(Func<T, int> getHashCode, Func<T, T, bool> equals)
            {
                _getHashCode = getHashCode;
                _equals = equals;
            }

            public bool Equals(T x, T y) => _equals(x, y);
            public int GetHashCode(T obj) => _getHashCode(obj);
        }
    }
}
