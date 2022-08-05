// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputEnumTypeValue } from "./InputEnumTypeValue.js";
import { InputModelProperty } from "./InputModelProperty.js";
import { InputTypeKind } from "./InputTypeKind.js";

export interface InputType {
    Name: string;
    IsNullable: boolean;
}

export interface InputPrimitiveType extends InputType {
    Kind: InputTypeKind;
}

export interface InputModelType extends InputType {
    Namespace?: string;
    Accessibility?: string;
    Properties: InputModelProperty[];
    BaseModel?: InputModelType;
    DerivedModels?: InputModelType[];
    DiscriminatorValue?: string[];
}

export interface InputEnumType extends InputType {
    EnumValueType: InputPrimitiveType;
    AllowedValues: InputEnumTypeValue[];
    IsExtensible: boolean;
}

export interface InputListType extends InputType {
    ElementType: InputType;
}

export interface InputDictionaryType extends InputType {
    KeyType: InputType;
    ValueType: InputType;
}
