// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { BodyMediaType } from "./BodyMediaType.js";
import { HttpResponseHeader } from "./HttpResponseHeader.js";
import { InputType } from "./InputType.js";

export interface OperationResponse {
    StatusCodes: number[];
    BodyType?: InputType;
    BodyMediaType: BodyMediaType;
    Headers: HttpResponseHeader[];
    IsErrorResponse: boolean;
}
