// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class TenantOnlyTests : OutputLibraryTestBase
    {
        public TenantOnlyTests() : base("TenantOnly") { }

        [TestCase("BillingAccount")]
        public void TestTenant(string resourceName)
        {
            (_, var context) = Generate("TenantOnly").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.IsNotNull(resource);
            Assert.IsTrue(resource.Parent(context).Contains(context.Library.TenantExtensions));
        }
    }
}
