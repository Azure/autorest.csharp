// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class TenantOnlyTests : OutputLibraryTestBase
    {
        [Test]
        public void TestTenant()
        {
            var result = Generate("TenantOnly").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("AvailableBalances") || operations.Key.Equals("Instructions"))
                    Assert.IsTrue(operations.Parent(context.Configuration.MgmtConfiguration).Equals("Microsoft.Billing/billingAccounts/billingProfiles"));
                else if (operations.Key.Equals("Agreements"))
                    Assert.IsTrue(operations.Parent(context.Configuration.MgmtConfiguration).Equals("Microsoft.Billing/billingAccounts"));
                else
                    Assert.IsTrue(operations.Parent(context.Configuration.MgmtConfiguration).Equals("tenant"));
            }
        }
    }
}
