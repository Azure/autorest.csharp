// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace {0}.Tests
{{
    public class {1}ManagementTestBase : ManagementRecordedTestBase<{1}ManagementTestEnvironment>
    {{
        protected ArmClient Client {{ get; private set; }}
        protected SubscriptionResource DefaultSubscription {{ get; private set; }}

        protected {1}ManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {{
        }}

        protected {1}ManagementTestBase(bool isAsync)
            : base(isAsync)
        {{
        }}

        [SetUp]
        public async Task CreateCommonClient()
        {{
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }}

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {{
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }}
    }}
}}
