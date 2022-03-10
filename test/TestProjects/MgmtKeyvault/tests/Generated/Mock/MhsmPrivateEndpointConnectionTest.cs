// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;

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
        public async Task Get()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection
            var mhsmPrivateEndpointConnectionId = MgmtKeyvault.MhsmPrivateEndpointConnection.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            var mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnection(mhsmPrivateEndpointConnectionId);

            await mhsmPrivateEndpointConnection.GetAsync();
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: ManagedHsmDeletePrivateEndpointConnection
            var mhsmPrivateEndpointConnectionId = MgmtKeyvault.MhsmPrivateEndpointConnection.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            var mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnection(mhsmPrivateEndpointConnectionId);

            await mhsmPrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
        }
    }
}
