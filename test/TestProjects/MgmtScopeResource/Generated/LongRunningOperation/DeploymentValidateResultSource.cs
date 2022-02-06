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
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    internal class DeploymentValidateResultSource : IOperationSource<DeploymentValidateResult>
    {
        private readonly ArmClient _client;

        internal DeploymentValidateResultSource(ArmClient client)
        {
            _client = client;
        }

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
