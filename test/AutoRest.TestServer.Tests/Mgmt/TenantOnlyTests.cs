// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    internal class TenantOnlyTests : OutputLibraryTestBase
    {
        [Test]
        public void TestTenant()
        {
            CodeModel model = Generate("TenantOnly").Result;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent);
                if (operations.Key.Equals("AvailableBalances") || operations.Key.Equals("Instructions"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Billing/billingAccounts/billingProfiles"));
                else if (operations.Key.Equals("Agreements"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Billing/billingAccounts"));
                else
                    Assert.IsTrue(operations.Parent.Equals("tenant"));
            }
        }
    }
}
