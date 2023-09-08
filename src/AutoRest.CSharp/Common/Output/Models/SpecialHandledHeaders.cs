// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static class SpecialHandledHeaders
    {
        public const string ClientRequestId = "client-request-id";
        public const string ReturnClientRequestId = "return-client-request-id";
        public const string RepeatabilityRequestId = "Repeatability-Request-ID";
        public const string RepeatabilityFirstSent = "Repeatability-First-Sent";

        public static bool IsNonParameterizedHeader(string header)
            => header.Equals(ClientRequestId, StringComparison.OrdinalIgnoreCase) ||
               header.Equals(ReturnClientRequestId, StringComparison.OrdinalIgnoreCase) ||
               header.Equals(RepeatabilityRequestId, StringComparison.OrdinalIgnoreCase) ||
               header.Equals(RepeatabilityFirstSent, StringComparison.OrdinalIgnoreCase);
    }
}
