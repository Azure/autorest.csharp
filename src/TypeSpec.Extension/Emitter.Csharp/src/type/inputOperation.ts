// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { BodyMediaType } from "./bodyMediaType";
import { OperationLongRunning } from "./operationLongRunning";
import { OperationPaging } from "./operationPaging";
import { InputParameter } from "./inputParameter";
import { OperationResponse } from "./operationResponse";
import { RequestMethod } from "./requestMethod";

export interface Paging {
    NextLinkName?: string;
    ItemName: string;
    NextPageMethod?: string;
}

export interface InputOperation {
    Name: string;
    ResourceName?: string;
    Summary?: string;
    Deprecated?: string;
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
    GenerateProtocolMethod: boolean;
    GenerateConvenienceMethod: boolean;
    IsConfident?: boolean;
}
