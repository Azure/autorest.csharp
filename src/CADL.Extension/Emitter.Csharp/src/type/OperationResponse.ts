// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { BodyMediaType } from "./BodyMediaType";
import { InputType } from "./InputType";

export interface OperationResponse {
    StatusCodes: number[];
    BodyType?: InputType;
    BodyMediaType: BodyMediaType;
}
