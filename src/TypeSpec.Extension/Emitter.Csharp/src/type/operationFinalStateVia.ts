// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
import { FinalStateValue } from "@azure-tools/typespec-azure-core";

export enum OperationFinalStateVia {
    AzureAsyncOperation,
    Location,
    OriginalUri,
    OperationLocation
}

export function convertLroFinalStateVia(
    finalStateValue: FinalStateValue
): OperationFinalStateVia {
    switch (finalStateValue) {
        case FinalStateValue.azureAsyncOperation:
            return OperationFinalStateVia.AzureAsyncOperation;
        case FinalStateValue.location:
            return OperationFinalStateVia.Location;
        case FinalStateValue.originalUri:
            return OperationFinalStateVia.OriginalUri;
        case FinalStateValue.operationLocation:
            return OperationFinalStateVia.OperationLocation;
        default:
            throw `Unsupported LRO final state value: ${finalStateValue}`;
    }
}
