// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputEnumTypeValue } from "./inputEnumTypeValue.js";
import { InputModelProperty } from "./inputModelProperty.js";
import { InputTypeKind } from "./inputTypeKind.js";

export interface InputType {
    Name: string;
    IsNullable: boolean;
    IsLowConfidence?: boolean;
}

export interface InputPrimitiveType extends InputType {
    Kind: InputTypeKind;
}

export interface InputLiteralType extends InputType {
    Name: "Literal";
    LiteralValueType: InputType;
    Value: any;
}

export function isInputLiteralType(type: InputType): type is InputLiteralType {
    return (
        type.Name === "Literal" &&
        (type as InputLiteralType).LiteralValueType !== undefined
    );
}

export interface InputUnionType extends InputType {
    Name: "Union";
    UnionItemTypes: InputType[];
}

export function isInputUnionType(type: InputType): type is InputUnionType {
    return (
        type.Name === "Union" &&
        (type as InputUnionType).UnionItemTypes !== undefined
    );
}

export interface InputModelType extends InputType {
    Namespace?: string;
    Accessibility?: string;
    Deprecated?: string;
    Description: string;
    Usage: string;
    Properties: InputModelProperty[];
    BaseModel?: InputModelType;
    DiscriminatorPropertyName?: string;
    DiscriminatorValue?: string;
}

export interface InputEnumType extends InputType {
    Namespace?: string;
    Accessibility?: string;
    Deprecated?: string;
    Description: string;
    EnumValueType: string;
    AllowedValues: InputEnumTypeValue[];
    IsExtensible: boolean;
    Usage: string;
}

export interface InputListType extends InputType {
    ElementType: InputType;
}

export interface InputDictionaryType extends InputType {
    KeyType: InputType;
    ValueType: InputType;
}

export interface InputIntrinsicType extends InputType {
    Name: "Intrinsic";
    IsNullable: false;
    Kind: "ErrorType" | "void" | "never" | "unknown" | "null";
}

export interface InputErrorType extends InputIntrinsicType {
    Kind: "ErrorType";
}

export interface InputVoidType extends InputIntrinsicType {
    Kind: "void";
}

export interface InputNeverType extends InputIntrinsicType {
    Kind: "never";
}

export interface InputUnknownType extends InputIntrinsicType {
    Kind: "unknown";
}

export interface InputNullType extends InputIntrinsicType {
    Kind: "null";
}
