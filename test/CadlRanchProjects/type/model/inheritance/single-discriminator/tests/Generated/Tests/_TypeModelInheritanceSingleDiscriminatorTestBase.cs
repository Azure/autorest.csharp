// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace _Type.Model.Inheritance.SingleDiscriminator.Tests
{
    public partial class _TypeModelInheritanceSingleDiscriminatorTestBase : RecordedTestBase<_TypeModelInheritanceSingleDiscriminatorTestEnvironment>
    {
        public _TypeModelInheritanceSingleDiscriminatorTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected SingleDiscriminatorClient CreateSingleDiscriminatorClient(Uri endpoint)
        {
            SingleDiscriminatorClientOptions options = InstrumentClientOptions(new SingleDiscriminatorClientOptions());
            SingleDiscriminatorClient client = new SingleDiscriminatorClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
