// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
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
            Assert.AreEqual("Microsoft.Billing/billingAccounts/", segments[0].TokenValue);
        }

        [Test]
        public void ValidateResourceGroupLevelProvider()
        {
            string path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(1, segments.Count);
            Assert.AreEqual("Microsoft.Compute/virtualMachines/", segments[0].TokenValue);
        }

        [Test]
        public void ValidateExtensionProvider()
        {
            string path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Toasters/toaster/{toasterName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(2, segments.Count);
            Assert.AreEqual("Microsoft.Compute/virtualMachines/", segments[0].TokenValue);
            Assert.AreEqual("Microsoft.Toasters/toaster/", segments[1].TokenValue);
        }

        [Test]
        public void ValidateMultiLevelProvider()
        {
            string path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(1, segments.Count);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/", segments[0].TokenValue);
        }

        [Test]
        public void ValidateExtensionProviderReferenceFirst()
        {
            string path = "/providers/{reference}/providers/Microsoft.Toasters/toaster/{toasterName}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(2, segments.Count);
            Assert.AreEqual(string.Empty, segments[0].TokenValue);
            Assert.IsFalse(segments[0].IsFullProvider);
            Assert.AreEqual("Microsoft.Toasters/toaster/", segments[1].TokenValue);
            Assert.IsTrue(segments[1].IsFullProvider);
        }

        [Test]
        public void ValidateExtensionProviderReferenceLast()
        {
            string path = "/providers/Microsoft.Alerts/something/{somethingName}/providers/{reference}";
            var segments = ProviderSegmentDetection.GetProviderSegments(path);
            Assert.AreEqual(2, segments.Count);
            Assert.AreEqual("Microsoft.Alerts/something/", segments[0].TokenValue);
            Assert.IsTrue(segments[0].IsFullProvider);
            Assert.AreEqual(string.Empty, segments[1].TokenValue);
            Assert.IsFalse(segments[1].IsFullProvider);
        }
    }
}
