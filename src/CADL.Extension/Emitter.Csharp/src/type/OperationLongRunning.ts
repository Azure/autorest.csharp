// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CodeModelType } from "./CodeModelType";
import { OperationFinalStateVia } from "./OperationFinalStateVia";

export interface OperationLongRunning
{
    FinalStateVia: OperationFinalStateVia;
    FinalResponseType?: CodeModelType;
}