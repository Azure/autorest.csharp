// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { OperationFinalStateVia } from "./OperationFinalStateVia.js";
import { OperationResponse } from "./OperationResponse.js";

export interface OperationLongRunning {
    FinalStateVia: OperationFinalStateVia;
    FinalResponse: OperationResponse;
}
