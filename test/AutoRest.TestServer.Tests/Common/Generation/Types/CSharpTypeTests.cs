// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class CSharpTypeTests
    {
        [TestCase(typeof(int))]
        [TestCase(typeof(IList<>))]
        [TestCase(typeof(IList<int>))]
        [TestCase(typeof(IDictionary<,>))]
        [TestCase(typeof(IDictionary<int, int>))]
        [TestCase(typeof(IDictionary<string, int>))]
        public void TypesAreEqual(Type type)
        {
            var cst1 = new CSharpType(type);
            var cst2 = new CSharpType(type);
            Assert.IsTrue(cst1.Equals(cst2));
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(IList<>))]
        [TestCase(typeof(IList<int>))]
        [TestCase(typeof(IDictionary<,>))]
        [TestCase(typeof(IDictionary<int, int>))]
        [TestCase(typeof(IDictionary<string, int>))]
        public void EqualToFrameworkType(Type type)
        {
            var cst = new CSharpType(type);
            Assert.IsTrue(cst.Equals(type));
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(IList<>))]
        [TestCase(typeof(IList<int>))]
        [TestCase(typeof(IDictionary<,>))]
        [TestCase(typeof(IDictionary<int, int>))]
        [TestCase(typeof(IDictionary<string, int>))]
        public void HashCodesAreEqual(Type type)
        {
            var cst1 = new CSharpType(type);
            var cst2 = new CSharpType(type);
            Assert.AreEqual(cst1.GetHashCode(), cst2.GetHashCode());
        }

        [TestCase(typeof(int), typeof(string))]
        [TestCase(typeof(IList<int>), typeof(IList<>))]
        [TestCase(typeof(IList<int>), typeof(IList<string>))]
        [TestCase(typeof(IList<int>), typeof(ICollection<int>))]
        [TestCase(typeof(Tuple<>), typeof(Tuple<,>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(Dictionary<,>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(Dictionary<int, int>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(Dictionary<int, string>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(IDictionary<string, int>))]
        public void TypesAreNotEqual(Type type1, Type type2)
        {
            var cst1 = new CSharpType(type1);
            var cst2 = new CSharpType(type2);
            Assert.IsFalse(cst1.Equals(cst2));
        }

        [TestCase(typeof(int), typeof(string))]
        [TestCase(typeof(IList<int>), typeof(IList<>))]
        [TestCase(typeof(IList<int>), typeof(IList<string>))]
        [TestCase(typeof(IList<int>), typeof(ICollection<int>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(Dictionary<int, string>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(IDictionary<string, int>))]
        public void NotEqualToFrameworkType(Type type1, Type type2)
        {
            var cst = new CSharpType(type1);
            Assert.IsFalse(cst.Equals(type2));
        }

        [TestCase(typeof(int), typeof(string))]
        [TestCase(typeof(IList<int>), typeof(IList<>))]
        [TestCase(typeof(IList<int>), typeof(IList<string>))]
        [TestCase(typeof(IList<int>), typeof(ICollection<int>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(Dictionary<int, string>))]
        [TestCase(typeof(IDictionary<int, string>), typeof(IDictionary<string, int>))]
        public void HashCodesAreNotEqual(Type type1, Type type2)
        {
            var cst1 = new CSharpType(type1);
            var cst2 = new CSharpType(type2);
            Assert.AreNotEqual(cst1.GetHashCode(), cst2.GetHashCode());
        }
    }
}
