// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace SpecialWords.Tests
{
    public partial class SpecialWordsTestBase : RecordedTestBase<SpecialWordsTestEnvironment>
    {
        public SpecialWordsTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected SpecialWordsClient CreateSpecialWordsClient(Uri endpoint)
        {
            SpecialWordsClientOptions options = InstrumentClientOptions(new SpecialWordsClientOptions());
            SpecialWordsClient client = new SpecialWordsClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
