// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Parameters.CollectionFormat;

namespace Parameters.CollectionFormat.Tests
{
    public partial class ParametersCollectionFormatTestBase : RecordedTestBase<ParametersCollectionFormatTestEnvironment>
    {
        public ParametersCollectionFormatTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected CollectionFormatClient CreateCollectionFormatClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new CollectionFormatClientOptions());
            var client = new CollectionFormatClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
