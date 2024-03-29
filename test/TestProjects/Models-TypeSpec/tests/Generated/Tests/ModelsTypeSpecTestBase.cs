// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace ModelsTypeSpec.Tests
{
    public partial class ModelsTypeSpecTestBase : RecordedTestBase<ModelsTypeSpecTestEnvironment>
    {
        public ModelsTypeSpecTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ModelsTypeSpecClient CreateModelsTypeSpecClient(Uri endpoint)
        {
            ModelsTypeSpecClientOptions options = InstrumentClientOptions(new ModelsTypeSpecClientOptions());
            ModelsTypeSpecClient client = new ModelsTypeSpecClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
