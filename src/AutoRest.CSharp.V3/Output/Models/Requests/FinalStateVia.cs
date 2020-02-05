// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal enum FinalStateVia
    {
        AzureAsyncOperation,
        Location,
        OriginalUri
    }

    internal static class FinalStateViaHelpers
    {
        public static FinalStateVia Create(string? rawValue) => rawValue switch
        {
            "azure-async-operation" => FinalStateVia.AzureAsyncOperation,
            "location" => FinalStateVia.Location,
            "original-uri" => FinalStateVia.OriginalUri,
            _ => FinalStateVia.AzureAsyncOperation
        };
    }
}
