// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> where TEnvironment : TestEnvironment, new()
    {

        public ManagementRecordedTestBase(bool isAsync)
        {
        }

        public ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode)
        {
        }

        protected async Task<ResourceGroupCollection> GetResourceGroupCollection()
        {
            var client = GetArmClient();
            var sub = await client.GetSubscriptions().GetAsync("");
            return sub.Value.GetResourceGroups();
        }

        protected ArmClient GetArmClient()
        {
            return new ArmClient(default);
        }
    }
}
