// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;

namespace CollapseRequestCondition_LowLevel.Tests
{
    public partial class CollapseRequestCondition_LowLevelTestBase : RecordedTestBase<CollapseRequestCondition_LowLevelTestEnvironment>
    {
        public CollapseRequestCondition_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected RequestConditionCollapseClient CreateRequestConditionCollapseClient(Uri endpoint, AzureKeyCredential credential)
        {
            CollapseRequestConditionsClientOptions options = InstrumentClientOptions(new CollapseRequestConditionsClientOptions());
            RequestConditionCollapseClient client = new RequestConditionCollapseClient(endpoint, credential, options);
            return InstrumentClient(client);
        }

        protected MatchConditionCollapseClient CreateMatchConditionCollapseClient(Uri endpoint, AzureKeyCredential credential)
        {
            CollapseRequestConditionsClientOptions options = InstrumentClientOptions(new CollapseRequestConditionsClientOptions());
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(endpoint, credential, options);
            return InstrumentClient(client);
        }

        protected NonCollapseClient CreateNonCollapseClient(Uri endpoint, AzureKeyCredential credential)
        {
            CollapseRequestConditionsClientOptions options = InstrumentClientOptions(new CollapseRequestConditionsClientOptions());
            NonCollapseClient client = new NonCollapseClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
