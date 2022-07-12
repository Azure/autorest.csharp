// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace MgmtMockTest.Tests.Mock
{
    /// <summary> Test for VirtualMachineExtensionImageCollection. </summary>
    public partial class VirtualMachineExtensionImageCollectionMockTests : MockTestBase
    {
        public VirtualMachineExtensionImageCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Exists_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MaximumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaa");
            await collection.ExistsAsync("aaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaa");
        }

        [RecordedTest]
        public async Task Exists_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MinimumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa");
            await collection.ExistsAsync("aa", "aaa");
        }

        [RecordedTest]
        public async Task Get_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MaximumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaa");
            await collection.GetAsync("aaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaa");
        }

        [RecordedTest]
        public async Task Get_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MinimumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa");
            await collection.GetAsync("aa", "aaa");
        }

        [RecordedTest]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMaximumSetGen()
        {
            // Example: VirtualMachineExtensionImages_ListTypes_MaximumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMinimumSetGen()
        {
            // Example: VirtualMachineExtensionImages_ListTypes_MinimumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaa", "aa");
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMaximumSetGen()
        {
            // Example: VirtualMachineExtensionImages_ListVersions_MaximumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaa");
            await foreach (var _ in collection.GetAllAsync("aaaaaaaaaaaaaaaaaa", filter: "aaaaaaaaaaaaaaaaaaaaaaaaa", top: 22, orderby: "a"))
            {
            }
        }

        [RecordedTest]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMinimumSetGen()
        {
            // Example: VirtualMachineExtensionImages_ListVersions_MinimumSet_Gen

            var subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            await foreach (var _ in collection.GetAllAsync("aaaa"))
            {
            }
        }
    }
}
