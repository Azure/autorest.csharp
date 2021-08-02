// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class TenantOnlyTests : OutputLibraryTestBase
    {
        public TenantOnlyTests() : base("TenantOnly") { }

        [Test]
        public void TestTenant()
        {
            var result = Generate("TenantOnly").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("AvailableBalances") || operations.Key.Equals("Instructions"))
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("Microsoft.Billing/billingAccounts/billingProfiles"));
                else if (operations.Key.Equals("Agreements"))
                {
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("Microsoft.Billing/billingAccounts"));
                    Assert.IsTrue(operations.IsAncestorTenant(context));
                    Assert.IsFalse(operations.IsTenantResource(context.Configuration.MgmtConfiguration));
                }
                else
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("tenant"));
            }
        }
    }
}
