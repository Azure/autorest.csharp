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

namespace Pagination
{
    internal class PageSizeDoubleModelSource : IOperationSource<PageSizeDoubleModel>
    {
        private readonly ArmClient _client;

        internal PageSizeDoubleModelSource(ArmClient client)
        {
            _client = client;
        }

        PageSizeDoubleModel IOperationSource<PageSizeDoubleModel>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PageSizeDoubleModelData.DeserializePageSizeDoubleModelData(document.RootElement);
            return new PageSizeDoubleModel(_client, data);
        }

        async ValueTask<PageSizeDoubleModel> IOperationSource<PageSizeDoubleModel>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PageSizeDoubleModelData.DeserializePageSizeDoubleModelData(document.RootElement);
            return new PageSizeDoubleModel(_client, data);
        }
    }
}
