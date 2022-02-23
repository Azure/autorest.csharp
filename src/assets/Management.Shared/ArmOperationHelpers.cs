// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.ResourceManager.Core
{
    internal static class ArmOperationHelpers
    {
        public static async ValueTask<ArmOperation<T>> ProcessMessageAsync<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, bool waitForCompletion, IOperationSource<T> source, string scopeName, OperationFinalStateVia finalStateVia, CancellationToken cancellationToken = default)
        {
            await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var operation = new RealArmOperation<T>(source, clientDiagnostics, pipeline, message.Request, message.Response, finalStateVia, scopeName);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            return operation;
        }

        public static ArmOperation<T> ProcessMessage<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, bool waitForCompletion, IOperationSource<T> source, string scopeName, OperationFinalStateVia finalStateVia, CancellationToken cancellationToken = default)
        {
            pipeline.Send(message, cancellationToken);
            var operation = new RealArmOperation<T>(source, clientDiagnostics, pipeline, message.Request, message.Response, finalStateVia, scopeName);
            if (waitForCompletion)
            {
                operation.WaitForCompletion(cancellationToken);
            }
            return operation;
        }

        public static async ValueTask<ArmOperation> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, bool waitForCompletion, string scopeName, OperationFinalStateVia finalStateVia, CancellationToken cancellationToken = default)
        {
            await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var operation = new RealArmOperation(clientDiagnostics, pipeline, message.Request, message.Response, finalStateVia, scopeName);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            return operation;
        }

        public static ArmOperation ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, bool waitForCompletion, string scopeName, OperationFinalStateVia finalStateVia, CancellationToken cancellationToken = default)
        {
            pipeline.Send(message, cancellationToken);
            var operation = new RealArmOperation(clientDiagnostics, pipeline, message.Request, message.Response, finalStateVia, scopeName);
            if (waitForCompletion)
            {
                operation.WaitForCompletionResponse(cancellationToken);
            }
            return operation;
        }

        public static ArmOperation<T> FromResponse<T>(T value, Response response) => new FakeArmOperation<T>(value, response);

        public static ArmOperation FromResponse(Response response) => new FakeArmOperation(response);

        private class FakeArmOperation<T> : ArmOperation<T>
        {
            private readonly Response _response;

#pragma warning disable CA1822
            public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

            public override bool HasCompleted => true;
            public override T Value { get; }
            public override bool HasValue => true;

            public FakeArmOperation(T value, Response response)
            {
                _response = response;
                Value = value;
            }

            public override Response GetRawResponse() => _response;

            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => new(_response);

            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _response;
        }

        private class FakeArmOperation : ArmOperation
        {
            private readonly Response _response;

#pragma warning disable CA1822
            public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

            public override bool HasCompleted => true;

            public FakeArmOperation(Response response)
            {
                _response = response;
            }

            public override Response GetRawResponse() => _response;

            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => new(_response);

            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _response;
        }
    }
}
