// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using _Type.Model.Inheritance.NotDiscriminated;

namespace _Type.Model.Inheritance.NotDiscriminated.Tests
{
    public partial class _TypeModelInheritanceNotDiscriminatedTestBase : RecordedTestBase<_TypeModelInheritanceNotDiscriminatedTestEnvironment>
    {
        public _TypeModelInheritanceNotDiscriminatedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected NotDiscriminatedClient CreateNotDiscriminatedClient(Uri endpoint)
        {
            NotDiscriminatedClientOptions options = InstrumentClientOptions(new NotDiscriminatedClientOptions());
            NotDiscriminatedClient client = new NotDiscriminatedClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
