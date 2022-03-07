// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class ArmOperationHelpers
    {
        /// <summary>
        /// Store the property values that are shared by current management plane RP.
        /// </summary>
        private static void SetProperty(this HttpMessage message, string userAgent) => message.SetProperty("ArmUserAgent", userAgent);

        public static OperationOrResponseInternals<T> CreateOperation<T>(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, HttpMessage message, Response response, OperationFinalStateVia finalStateVia, string scopeName, string userAgent)
        {
            return new OperationOrResponseInternals<T>(source, clientDiagnostics, pipeline, message, response, finalStateVia, scopeName);
        }

        public static OperationOrResponseInternals CreateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, HttpMessage message, Response response, OperationFinalStateVia finalStateVia, string scopeName, string userAgent)
        {
            return new OperationOrResponseInternals(clientDiagnostics, pipeline, message, response, finalStateVia, scopeName);
        }
    }
}
