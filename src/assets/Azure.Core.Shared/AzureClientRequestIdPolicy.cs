// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class AzureClientRequestIdPolicy : HttpPipelineSynchronousPolicy
    {
        internal const string ClientRequestIdHeader = "client-request-id";
        internal const string EchoClientRequestId = "return-client-request-id";

        public AzureClientRequestIdPolicy()
        {
        }

        public static AzureClientRequestIdPolicy Shared { get; } = new AzureClientRequestIdPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.SetValue(ClientRequestIdHeader, message.Request.ClientRequestId);
            message.Request.Headers.SetValue(EchoClientRequestId, "true");
        }
    }
}
