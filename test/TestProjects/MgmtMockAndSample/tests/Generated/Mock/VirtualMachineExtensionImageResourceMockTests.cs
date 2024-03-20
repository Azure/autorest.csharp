// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for VirtualMachineExtensionImageResource. </summary>
    public partial class VirtualMachineExtensionImageResourceMockTests : MockTestBase
    {
        public VirtualMachineExtensionImageResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Get_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MaximumSet_Gen

            ResourceIdentifier virtualMachineExtensionImageResourceId = VirtualMachineExtensionImageResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", new AzureLocation("aaaaaaaaaaaaa"), "aaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaa");
            VirtualMachineExtensionImageResource virtualMachineExtensionImage = GetArmClient().GetVirtualMachineExtensionImageResource(virtualMachineExtensionImageResourceId);
            await virtualMachineExtensionImage.GetAsync();
        }

        [RecordedTest]
        public async Task Get_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Example: VirtualMachineExtensionImages_Get_MinimumSet_Gen

            ResourceIdentifier virtualMachineExtensionImageResourceId = VirtualMachineExtensionImageResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", new AzureLocation("aaaaaaaaaaaaaa"), "aaaaaaaaaaaaaaaaaaaaaaaaaa", "aa", "aaa");
            VirtualMachineExtensionImageResource virtualMachineExtensionImage = GetArmClient().GetVirtualMachineExtensionImageResource(virtualMachineExtensionImageResourceId);
            await virtualMachineExtensionImage.GetAsync();
        }
    }
}
