// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal static class KnownParameters
    {
        private static readonly CSharpType RequestContentType = new(typeof(RequestContent));
        private static readonly CSharpType RequestContentNullableType = new(typeof(RequestContent), true);
        private static readonly CSharpType RequestContextNullableType = new(typeof(RequestContext), true);

        public static readonly Parameter ClientDiagnostics = new("clientDiagnostics", "The ClientDiagnostics instance to use", new CSharpType(typeof(ClientDiagnostics)), null, true);
        public static readonly Parameter Pipeline = new("pipeline", "The pipeline instance to use", new CSharpType(typeof(HttpPipeline)), null, true);
        public static readonly Parameter KeyAuth = new("keyCredential", "The key credential to copy", new CSharpType(typeof(AzureKeyCredential)), null, false);
        public static readonly Parameter TokenAuth = new("tokenCredential", "The token credential to copy", new CSharpType(typeof(TokenCredential)), null, false);

        public static readonly Parameter RequestContent = new("content", "The content to send as the body of the request.", RequestContentType, null, true);
        public static readonly Parameter RequestContentNullable = new("content", "The content to send as the body of the request.", RequestContentNullableType, /*Constant.Default(RequestContentNullableType)*/null, false);

        public static readonly Parameter RequestContext = new("context", "The request context, which can override default behaviors on the request on a per-call basis.", RequestContextNullableType, Constant.Default(RequestContextNullableType), false);

        public static readonly Parameter WaitForCompletion = new("waitForCompletion", "true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md\"> Azure.Core Long-Running Operation samples</see>.", new CSharpType(typeof(bool)), null, false);
    }
}
