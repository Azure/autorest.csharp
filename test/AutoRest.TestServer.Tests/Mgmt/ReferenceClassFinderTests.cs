// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.Decorator;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class ReferenceClassFinderTests
    {
        private class A { }
        private class B : A { }
        private class C : B { }
        private class D { }
        private class E : D { }
        [ReferenceType(typeof(int))]
        private class F<T> { }
        private class G : F<int> { }

        private static IList<Type> TestReferenceTypes => new List<Type>()
        {
            typeof(A),
            typeof(B),
            typeof(C),
            typeof(E),
            typeof(D),
            typeof(G),
            typeof(F<>)
        };

        [Test]
        public void ValidateRootNodes()
        {
            var rootNodes = ReferenceClassFinder.GetRootNodes(ReferenceClassFinder.ConvertGenericType(TestReferenceTypes));
            HashSet<Type> rootTypes = new HashSet<Type>();
            foreach (var node in rootNodes)
            {
                rootTypes.Add(node.Type);
            }
            Assert.AreEqual(3, rootNodes.Count);
            Assert.IsTrue(rootTypes.Contains(typeof(A)), "Did not find type A in the root list");
            Assert.IsTrue(rootTypes.Contains(typeof(D)), "Did not find type D in the root list");
            Assert.IsTrue(rootTypes.Contains(typeof(F<int>)), "Did not find type F<int> in the root list");
        }

        [Test]
        public void ValidateGenericOrder()
        {
            var orderedList = ReferenceClassFinder.GetOrderedList(TestReferenceTypes);
            bool foundGeneric = false;
            bool foundNonGeneric = false;
            foreach (var type in orderedList)
            {
                if (type == typeof(F<int>))
                    foundGeneric = true;

                if (type == typeof(G))
                    foundNonGeneric = true;

                Assert.IsTrue(!foundNonGeneric || foundGeneric, "We found the non generic type G before the generic type F<int>");
            }
        }
    }
}
