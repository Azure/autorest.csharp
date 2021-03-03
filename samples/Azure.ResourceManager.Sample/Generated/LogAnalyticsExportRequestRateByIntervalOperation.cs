// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Sample
{
    /// <summary> Export logs that show Api requests made by this subscription in the given time window to show throttling activities. </summary>
    public partial class LogAnalyticsExportRequestRateByIntervalOperation : Operation<LogAnalyticsOperationResultData>, IOperationSource<LogAnalyticsOperationResultData>
    {
        private readonly ArmOperationHelpers<LogAnalyticsOperationResultData> _operation;
        internal LogAnalyticsExportRequestRateByIntervalOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<LogAnalyticsOperationResultData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.AzureAsyncOperation, "LogAnalyticsExportRequestRateByIntervalOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override LogAnalyticsOperationResultData Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<LogAnalyticsOperationResultData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<LogAnalyticsOperationResultData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        LogAnalyticsOperationResultData IOperationSource<LogAnalyticsOperationResultData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return LogAnalyticsOperationResultData.DeserializeLogAnalyticsOperationResultData(document.RootElement);
        }

        async ValueTask<LogAnalyticsOperationResultData> IOperationSource<LogAnalyticsOperationResultData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return LogAnalyticsOperationResultData.DeserializeLogAnalyticsOperationResultData(document.RootElement);
        }
    }
}
