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

        [TestCase("CarResource", true)]
        [TestCase("IgnitionResource", true)]
        [TestCase("ParentResource", true)]
        [TestCase("SingletonResource", true)]
        [TestCase("SingletonResource2Resource", false)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("IgnitionResource", "Get", true)]
        [TestCase("IgnitionResource", "GetAsync", true)]
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

        [TestCase("ParentCollection", true)]
        [TestCase("ParentResourceCollection", false)]
        [TestCase("SingletonResourceCollection", false)]
        [TestCase("SingletonResource2Collection", false)]
        public void ValidateCollections(string collection, bool isExists)
        {
            var collectionTypeExists = FindAllCollections().Any(o => o.Name == collection);
            Assert.AreEqual(isExists, collectionTypeExists);
        }

        [TestCase("ParentResource", "GetSingletonResource", true)]
        [TestCase("ParentResource", "GetSingletonResources", false)]
        [TestCase("CarResource", "GetIgnition", false)]
        [TestCase("CarResource", "GetIgnitions", false)]
        [TestCase("CarResource", "GetIgnitionResource", true)]
        [TestCase("CarResource", "GetIgnitionResources", false)]
        [TestCase("ResourceGroupExtensions", "GetCarResource", true)]
        [TestCase("ResourceGroupExtensions", "GetCarResources", true)]
        [TestCase("ResourceGroupExtensions", "GetCar", false)]
        [TestCase("ResourceGroupExtensions", "GetCars", false)]
        [TestCase("ResourceGroupExtensions", "GetParentResources", true)]
        [TestCase("ResourceGroupExtensions", "GetParentResource", true)]
        [TestCase("ResourceGroupExtensions", "GetParentResourc", false)]
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
