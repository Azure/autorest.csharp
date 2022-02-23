// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class MgmtPlaneOperationHelpers
    {
        /// <summary>
        /// Store the property values that are shared by current management plane RP.
        /// </summary>
        private static ConcurrentDictionary<string, object> _mgmtProperties = new ConcurrentDictionary<string, object>();

        public static bool TryGetProperty(string name, out object? value)
        {
            value = null;
            return _mgmtProperties.TryGetValue(name, out value) == true;
        }

        private static void SetProperty(HttpMessage message)
        {
            if (message.TryGetProperty("SDKUserAgent", out Object? propertyValue))
            {
                if (propertyValue is string userAgent)
                {
                    _mgmtProperties.TryAdd("IsMgmtPlane", true);
                    _mgmtProperties.TryAdd("SDKUserAgent", userAgent);
                }
                else
                {
                    throw new ArgumentException($"SDKUserAgent http message property must be a string but was {propertyValue?.GetType()}");
                }
            }
        }

        public static OperationOrResponseInternals<T> CreateOperation<T>(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, HttpMessage message, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            SetProperty(message);
            return new OperationOrResponseInternals<T>(source, clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName);
        }

        public static OperationOrResponseInternals CreateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, HttpMessage message, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            SetProperty(message);
            return new OperationOrResponseInternals(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName);
        }
    }
}
