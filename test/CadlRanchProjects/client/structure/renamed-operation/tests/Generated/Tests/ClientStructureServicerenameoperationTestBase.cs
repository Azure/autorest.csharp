// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Client.Structure.Service.rename.operation.Models;

namespace Client.Structure.Service.rename.operation.Tests
{
    public partial class ClientStructureServicerenameoperationTestBase : RecordedTestBase<ClientStructureServicerenameoperationTestEnvironment>
    {
        public ClientStructureServicerenameoperationTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected RenamedOperationClient CreateRenamedOperationClient(Uri endpoint, ClientType client)
        {
            RenamedOperationClientOptions options = InstrumentClientOptions(new RenamedOperationClientOptions());
            RenamedOperationClient client0 = new RenamedOperationClient(endpoint, client, options);
            return InstrumentClient(client0);
        }
    }
}
