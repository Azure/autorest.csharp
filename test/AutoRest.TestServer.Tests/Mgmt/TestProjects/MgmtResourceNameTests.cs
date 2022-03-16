// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtResourceNameTests : TestProjectTests
    {
        public MgmtResourceNameTests() : base("MgmtResourceName") { }

        [TestCase("MachineResource", true)]
        [TestCase("DiskResource", true)]
        [TestCase("MemoryResource", true)]
        [TestCase("NetworkResource", true)]
        [TestCase("Machine", false)]
        [TestCase("Disk", false)]
        [TestCase("Memory", false)]
        [TestCase("Network", false)]
        [TestCase("MachineResourceResource", false)]
        [TestCase("DiskResourceResource", false)]
        [TestCase("MemoryResourceResource", false)]
        [TestCase("NetworkResourceResource", false)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [Test]
        public void ValidateResourceMethods([Values("MachineResource", "DiskResource", "MemoryResource", "NetworkResource")]string resourceName,
            [Values("Get", "GetAsync")]string methodName)
        {
            var resource = FindAllResources().FirstOrDefault(r => r.Name == resourceName);
            Assert.IsNotNull(resource, $"Cannot find resource {resourceName}");
            var method = resource.GetMethod(methodName);
            Assert.IsNotNull(method);
        }

        [TestCase("MachineData", true)]
        [TestCase("DiskResourceData", true)]
        [TestCase("MemoryResourceData", true)]
        [TestCase("NetworkData", true)]
        [TestCase("Machine", false)]
        [TestCase("Disk", false)]
        [TestCase("Memory", false)]
        [TestCase("Network", false)]
        [TestCase("MachineResourceData", false)]
        [TestCase("DiskData", false)]
        [TestCase("MemoryData", false)]
        [TestCase("NetworkResourceData", false)]
        public void ValidateResourceData(string resourceData, bool isExists)
        {
            var resourceTypeExists = FindAllResourceData().Any(o => o.Name == resourceData);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("MachineCollection", true)]
        [TestCase("DiskResourceCollection", true)]
        [TestCase("MemoryResourceCollection", true)]
        [TestCase("NetworkCollection", true)]
        [TestCase("MachineResourceCollection", false)]
        [TestCase("DiskCollection", false)]
        [TestCase("MemoryCollection", false)]
        [TestCase("NetworkResourceCollection", false)]
        public void ValidateCollections(string collectionName, bool isExists)
        {
            var collectionTypeExists = FindAllCollections().Any(o => o.Name == collectionName);
            Assert.AreEqual(isExists, collectionTypeExists);
        }

        public void ValidateCollectionMethods([Values("MachineCollection", "DiskResourceCollection", "MemoryResourceCollection", "NetworkCollection")]string collectionName,
            [Values("Get", "GetAsync", "CreateOrUpdate", "CreateOrUpdateAsync", "GetAll", "GetAllAsync", "Exists", "ExistsAsync", "GetIfExists", "GetIfExistsAsync")]string methodName)
        {
            var resourceCollection = FindAllCollections().FirstOrDefault(o => o.Name == collectionName);
            Assert.IsNotNull(resourceCollection, $"Cannot find resource collection {collectionName}");
            var method = resourceCollection.GetMethod(methodName);
            Assert.IsNotNull(method);
        }
    }
}
