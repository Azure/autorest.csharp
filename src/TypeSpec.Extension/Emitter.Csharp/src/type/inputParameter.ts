// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputConstant } from "./inputConstant";
import { InputOperationParameterKind } from "./inputOperationParameterKind";
import { InputType } from "./inputType";
import { RequestLocation } from "./requestLocation";

//TODO: Define VirtualParameter for HLC
export interface VirtualParameter {}
export interface InputParameter {
    Name: string;
    NameInRequest: string;
    Description?: string;
    Type: InputType;
    Location: RequestLocation;
    DefaultValue?: InputConstant;
    VirtualParameter?: VirtualParameter; //for HLC, set null for typespec
    GroupedBy?: InputParameter;
    Kind: InputOperationParameterKind;
    IsRequired: boolean;
    IsApiVersion: boolean;
    IsResourceParameter: boolean;
    IsContentType: boolean;
    IsEndpoint: boolean;
    SkipUrlEncoding: boolean;
    Explode: boolean;
    ArraySerializationDelimiter?: string;
    HeaderCollectionPrefix?: string;
}
