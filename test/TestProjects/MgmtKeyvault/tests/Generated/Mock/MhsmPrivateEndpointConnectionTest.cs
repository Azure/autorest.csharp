// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault.Models;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for MhsmPrivateEndpointConnection. </summary>
    public partial class MhsmPrivateEndpointConnectionMockTests : MockTestBase
    {
        public MhsmPrivateEndpointConnectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task GetAsync()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection
            var mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnection(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-group/providers/Microsoft.KeyVault/managedHSMs/sample-mhsm/privateEndpointConnections/sample-pec"));

            await mhsmPrivateEndpointConnection.GetAsync();
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            // Example: ManagedHsmDeletePrivateEndpointConnection
            var mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnection(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-group/providers/Microsoft.KeyVault/managedHSMs/sample-mhsm/privateEndpointConnections/sample-pec"));

            await mhsmPrivateEndpointConnection.DeleteAsync();
        }
    }
}
