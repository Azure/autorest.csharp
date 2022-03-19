// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources;
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

        [TestCase("ParentResourceCollection", true)]
        [TestCase("ParentCollection", false)]
        [TestCase("SingletonResourceCollection", false)]
        [TestCase("SingletonResource2Collection", false)]
        public void ValidateCollections(string collection, bool isExists)
        {
            var collectionTypeExists = FindAllCollections().Any(o => o.Name == collection);
            Assert.AreEqual(isExists, collectionTypeExists);
        }

        [TestCase("ParentResource", "GetSingletonResource", true)]
        [TestCase("ParentResource", "GetSingleton", false)]
        [TestCase("ParentResource", "GetSingletonResources", false)]
        [TestCase("CarResource", "GetIgnition", true)]
        [TestCase("CarResource", "GetIgnitions", false)]
        [TestCase("SingletonResourceExtensions", "GetCars", false, typeof(Subscription))]
        [TestCase("SingletonResourceExtensions", "GetCars", true, typeof(ResourceGroup))]
        [TestCase("SingletonResourceExtensions", "GetCar", false, typeof(Subscription))]
        [TestCase("SingletonResourceExtensions", "GetCar", true, typeof(ResourceGroup))]
        [TestCase("SingletonResourceExtensions", "GetParentResources", false, typeof(Subscription))]
        [TestCase("SingletonResourceExtensions", "GetParentResources", true, typeof(ResourceGroup))]
        [TestCase("SingletonResourceExtensions", "GetParentResource", false, typeof(Subscription))]
        [TestCase("SingletonResourceExtensions", "GetParentResource", true, typeof(ResourceGroup))]
        [TestCase("SingletonResourceExtensions", "GetParentResourc", false)]
        public void ValidateEntranceOfGettingSingleton(string parent, string methodName, bool exist, params Type[] parameterTypes)
        {
            var possibleTypesToFind = FindAllCollections().Concat(FindAllResources())
                .Append(FindExtensionClass());
            var type = possibleTypesToFind.FirstOrDefault(r => r.Name == parent);
            Assert.IsNotNull(type, $"Cannot find parent {parent}");
            var method = type.GetMethods().Where(m => m.Name == methodName).Where(m => ParameterMatch(m.GetParameters(), parameterTypes));
            Assert.AreEqual(exist, method.Any());
        }
    }
}
