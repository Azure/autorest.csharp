// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtExactMatchInheritance
{
#pragma warning disable SA1649 // File name should match first type name
    internal class MgmtExactMatchInheritanceArmOperation<T> : ArmOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;
        private readonly RehydrationToken? _completeRehydrationToken;
        private readonly NextLinkOperationImplementation _nextLinkOperation;
        private readonly string _operationId;

        /// <summary> Initializes a new instance of MgmtExactMatchInheritanceArmOperation for mocking. </summary>
        protected MgmtExactMatchInheritanceArmOperation()
        {
        }

        internal MgmtExactMatchInheritanceArmOperation(Response<T> response, RehydrationToken? rehydrationToken = null)
        {
            _operation = OperationInternal<T>.Succeeded(response.GetRawResponse(), response.Value);
            _completeRehydrationToken = rehydrationToken;
            _operationId = GetOperationId(rehydrationToken);
        }

        internal MgmtExactMatchInheritanceArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, bool skipApiVersionOverride = false, string apiVersionOverrideValue = null)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia, skipApiVersionOverride, apiVersionOverrideValue);
            if (nextLinkOperation is NextLinkOperationImplementation nextLinkOperationValue)
            {
                _nextLinkOperation = nextLinkOperationValue;
                _operationId = _nextLinkOperation.OperationId;
            }
            else
            {
                _completeRehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(request.Method, request.Uri.ToUri(), response, finalStateVia);
                _operationId = GetOperationId(_completeRehydrationToken);
            }
            _operation = new OperationInternal<T>(NextLinkOperationImplementation.Create(source, nextLinkOperation), clientDiagnostics, response, "MgmtExactMatchInheritanceArmOperation", fallbackStrategy: new SequentialDelayStrategy());
        }

        private string GetOperationId(RehydrationToken? rehydrationToken)
        {
            if (rehydrationToken is null)
            {
                return null;
            }
            var lroDetails = ModelReaderWriter.Write(rehydrationToken, ModelReaderWriterOptions.Json, MgmtExactMatchInheritanceContext.Default).ToObjectFromJson<Dictionary<string, string>>();
            return lroDetails["id"];
        }
        /// <inheritdoc />
        public override string Id => _operationId ?? NextLinkOperationImplementation.NotSet;

        /// <inheritdoc />
        public override RehydrationToken? GetRehydrationToken() => _nextLinkOperation?.GetRehydrationToken() ?? _completeRehydrationToken;

        /// <inheritdoc />
        public override T Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
