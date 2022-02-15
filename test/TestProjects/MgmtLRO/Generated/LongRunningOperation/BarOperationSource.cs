// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtLRO
{
    internal class BarOperationSource : IOperationSource<Bar>
    {
        private readonly ArmClient _client;

        internal BarOperationSource(ArmClient client)
        {
            _client = client;
        }

        Bar IOperationSource<Bar>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var data = BarData.DeserializeBarData(document.RootElement);
                return new Bar(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }

        async ValueTask<Bar> IOperationSource<Bar>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = BarData.DeserializeBarData(document.RootElement);
                return new Bar(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }
    }
}
