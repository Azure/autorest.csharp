// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal sealed class RealArmOperation : ArmOperation
    {
        private readonly OperationInternal _operation;

#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822
        public override bool HasCompleted => _operation.HasCompleted;

        internal RealArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            _operation = new OperationInternal(clientDiagnostics, NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia), response, scopeName);
        }

        public override Response GetRawResponse()
            => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => _operation.UpdateStatusAsync(cancellationToken);

        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
            => _operation.WaitForCompletionResponseAsync(cancellationToken);

        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            => _operation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
