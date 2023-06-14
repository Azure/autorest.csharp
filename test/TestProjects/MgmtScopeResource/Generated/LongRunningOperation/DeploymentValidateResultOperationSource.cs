// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    internal class DeploymentValidateResultOperationSource : IOperationSource<DeploymentValidateResult>
    {
        DeploymentValidateResult IOperationSource<DeploymentValidateResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return DeploymentValidateResult.DeserializeDeploymentValidateResult(document.RootElement);
        }

        async ValueTask<DeploymentValidateResult> IOperationSource<DeploymentValidateResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return DeploymentValidateResult.DeserializeDeploymentValidateResult(document.RootElement);
        }
    }
}
