// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { BodyMediaType } from "./BodyMediaType";
import { OperationLongRunning } from "./OperationLongRunning";
import { OperationPaging } from "./OperationPaging";
import { InputParameter } from "./InputParameter";
import { OperationResponse } from "./OperationResponse";
import { RequestMethod } from "./RequestMethod";

export interface Paging {
    NextLinkName?: string;
    ItemName: string;
    NextPageMethod?: string;
}

export interface InputOperation {
    Name: string;
    ResourceName?: string;
    Summary?: string;
    Description?: string;
    Accessibility?: string;
    Parameters: InputParameter[];
    Responses: OperationResponse[];
    HttpMethod: RequestMethod;
    RequestBodyMediaType: BodyMediaType;
    Uri: string;
    Path: string;
    ExternalDocsUrl?: string;
    RequestMediaTypes?: string[];
    BufferResponse: boolean;
    LongRunning?: OperationLongRunning;
    Paging?: OperationPaging;
    GenerateConvenienceMethod: boolean;
}
