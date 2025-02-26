// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtTypeSpec
{
    internal class FooOperationSource : IOperationSource<FooResource>
    {
        private readonly ArmClient _client;

        internal FooOperationSource(ArmClient client)
        {
            _client = client;
        }

        FooResource IOperationSource<FooResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<FooData>(new BinaryData(response.ContentStream));
            return new FooResource(_client, data);
        }

        async ValueTask<FooResource> IOperationSource<FooResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<FooData>(new BinaryData(response.ContentStream));
            return await Task.FromResult(new FooResource(_client, data)).ConfigureAwait(false);
        }
    }
}
