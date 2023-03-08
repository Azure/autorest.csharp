// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Linq;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class TenantOnlyTests : OutputLibraryTestBase
    {
        public TenantOnlyTests() : base("TenantOnly") { }

        [TestCase("BillingAccountResource")]
        public void TestTenant(string resourceName)
        {
            var resource = MgmtContext.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.IsNotNull(resource);
            Assert.IsTrue(resource.Parent().Any(parent => parent is MgmtExtension extension && extension.ArmCoreType == typeof(TenantResource)));
        }
    }
}
