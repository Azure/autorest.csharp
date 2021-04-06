// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Type.Decorate;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class ProviderSegmentDetectionTests
    {
        [Test]
        public void ValidateTenantProvider()
        {
            string path = "/providers/Microsoft.Billing/billingAccounts/{billingAccountName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(1, segments.Count);
            Assert.AreEqual("Microsoft.Billing/billingAccounts", segments[0].TokenValue);
        }

        [Test]
        public void ValidateResourceGroupLevelProvider()
        {
            string path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(1, segments.Count);
            Assert.AreEqual("Microsoft.Compute/virtualMachines", segments[0].TokenValue);
        }

        [Test]
        public void ValidateMultiLevelProvider()
        {
            string path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(2, segments.Count);
            Assert.AreEqual("Microsoft.Network/virtualNetworks", segments[0].TokenValue);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/subnets", segments[1].TokenValue);
        }
    }
}
