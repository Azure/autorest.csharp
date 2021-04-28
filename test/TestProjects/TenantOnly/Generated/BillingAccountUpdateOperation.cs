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
using Azure.ResourceManager.Core;

namespace TenantOnly
{
    public partial class BillingAccountUpdateOperation : ArmOperation<BillingAccountData>, IOperationSource<BillingAccountData>
    {
        private readonly OperationInternals<BillingAccountData> _operation;
        protected BillingAccountUpdateOperation()
        {
        }
        internal BillingAccountUpdateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<BillingAccountData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "BillingAccountUpdateOperation");
        }
        public override string Id => _operation.Id;
        public override BillingAccountData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<BillingAccountData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<BillingAccountData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        BillingAccountData IOperationSource<BillingAccountData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return BillingAccountData.DeserializeBillingAccountData(document.RootElement);
        }
        async ValueTask<BillingAccountData> IOperationSource<BillingAccountData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return BillingAccountData.DeserializeBillingAccountData(document.RootElement);
        }
    }
}
