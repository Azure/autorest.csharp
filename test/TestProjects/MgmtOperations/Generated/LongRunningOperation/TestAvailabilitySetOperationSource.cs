// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtOperations.Models;

namespace MgmtOperations
{
    internal class TestAvailabilitySetOperationSource : IOperationSource<TestAvailabilitySet>
    {
        TestAvailabilitySet IOperationSource<TestAvailabilitySet>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return TestAvailabilitySet.DeserializeTestAvailabilitySet(document.RootElement);
        }

        async ValueTask<TestAvailabilitySet> IOperationSource<TestAvailabilitySet>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return TestAvailabilitySet.DeserializeTestAvailabilitySet(document.RootElement);
        }
    }
}
