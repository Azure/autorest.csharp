// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class SingletonResourceTests : TestProjectTests
    {
        public SingletonResourceTests() : base("SingletonResource") { }

        [TestCase("Car", true)]
        [TestCase("Ignition", true)]
        [TestCase("ParentResource", true)]
        [TestCase("SingletonResource", true)]
        [TestCase("SingletonResource2", false)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("Ignition", "Get", true)]
        [TestCase("Ignition", "GetAsync", true)]
        [TestCase("SingletonResource", "Get", true)]
        [TestCase("SingletonResource", "GetAsync", true)]
        [TestCase("SingletonResource", "Delete", false)]
        [TestCase("SingletonResource", "DeleteAsync", false)]
        public void ValidateResourceMethods(string resourceName, string methodName, bool isExists)
        {
            var resource = FindAllResources().FirstOrDefault(r => r.Name == resourceName);
            Assert.IsNotNull(resource, $"Cannot find resource {resourceName}");
            var method = resource.GetMethod(methodName);
            Assert.AreEqual(isExists, method != null);
        }

        [TestCase("ParentResourceCollection", true)]
        [TestCase("SingletonResourceCollection", false)]
        [TestCase("SingletonResource2Collection", false)]
        public void ValidateCollections(string collection, bool isExists)
        {
            var collectionTypeExists = FindAllCollections().Any(o => o.Name == collection);
            Assert.AreEqual(isExists, collectionTypeExists);
        }

        [TestCase("ParentResource", "GetSingletonResource", true)]
        [TestCase("ParentResource", "GetSingletonResources", false)]
        [TestCase("Car", "GetIgnition", true)]
        [TestCase("Car", "GetIgnitions", false)]
        [TestCase("ResourceGroupExtensions", "GetCars", true)]
        [TestCase("ResourceGroupExtensions", "GetCar", false)]
        [TestCase("ResourceGroupExtensions", "GetParentResources", true)]
        [TestCase("ResourceGroupExtensions", "GetParentResource", false)]
        public void ValidateEntranceOfGettingSingleton(string parent, string methodName, bool isExist)
        {
            var possibleTypesToFind = FindAllCollections().Concat(FindAllResources())
                .Append(FindResourceGroupExtensions()).Append(FindSubscriptionExtensions());
            var type = possibleTypesToFind.FirstOrDefault(r => r.Name == parent);
            Assert.IsNotNull(type, $"Cannot find parent {parent}");
            var method = type.GetMethod(methodName);
            Assert.AreEqual(isExist, method != null);
        }
    }
}
