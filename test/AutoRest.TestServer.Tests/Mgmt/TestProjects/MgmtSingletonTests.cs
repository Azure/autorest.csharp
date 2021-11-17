// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtSingletonTests : TestProjectTests
    {
        public MgmtSingletonTests() : base("MgmtSingleton") { }

        [TestCase("ParentResource", true)]
        [TestCase("SingletonResource", true)]
        [TestCase("SingletonResource2", true)]
        [TestCase("SingletonResource3", false)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("SingletonResource", "Get", true)]
        [TestCase("SingletonResource", "GetAsync", true)]
        [TestCase("SingletonResource2", "Get", true)]
        [TestCase("SingletonResource2", "GetAsync", true)]
        [TestCase("TenantParentSingleton", "Get", true)]
        [TestCase("TenantParentSingleton", "GetAsync", true)]
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
        [TestCase("ParentResource", "GetSingletonResource2", true)]
        [TestCase("ParentResource", "GetSingletonResource2s", false)]
        [TestCase("ParentResource", "CreateOrUpdateSingletonResources3", true)]
        [TestCase("ParentResource", "GetSingletonResource3", false)]
        [TestCase("SubscriptionExtensions", "GetSubscriptionParentSingleton", true)]
        [TestCase("SubscriptionExtensions", "GetSubscriptionParentSingletons", false)]
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
