// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtSingletonTests : TestProjectTests
    {
        public MgmtSingletonTests() : base("MgmtSingleton") { }

        [TestCase("ParentResourceOperations", true)]
        [TestCase("SingletonResourceOperations", true)]
        public void ValidateOperations(string operation, bool isExists)
        {
            var operationTypeExists = FindAllOperations().Any(o => o.Name == operation);
            Assert.AreEqual(isExists, operationTypeExists);
        }

        [TestCase("ParentResource", true)]
        [TestCase("SingletonResource", true)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("ParentResourceContainer", true)]
        [TestCase("SingletonResourceContainer", false)]
        public void ValidateContainers(string container, bool isExists)
        {
            var containerTypeExists = FindAllContainers().Any(o => o.Name == container);
            Assert.AreEqual(isExists, containerTypeExists);
        }
    }
}
