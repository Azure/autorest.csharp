// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace AutoRest.CSharp.Common.Input;

internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse)
{
    public OperationLongRunning() : this(FinalStateVia: OperationFinalStateVia.Location, FinalResponse: new OperationResponse()) { }
}
