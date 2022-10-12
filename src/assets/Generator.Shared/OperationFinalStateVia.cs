// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal enum OperationFinalStateVia
    {
        LocationOverride,
        AzureAsyncOperation,
        Location,
        OriginalUri,
        OperationLocation
    }
}
