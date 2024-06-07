// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { SdkBuiltInKinds } from "@azure-tools/typespec-client-generator-core";
import {
    DateTimeKnownEncoding,
    DurationKnownEncoding
} from "@typespec/compiler";

interface InputTypeBase {
    kind: string;
    isNullable: boolean;
    description?: string;
}

export enum InputTypeKind {
    Model = "Model",
    Array = "Array",
    Dictionary = "Dictionary",
    Intrinsic = "Intrinsic"
}

export type InputType =
    | InputPrimitiveType
    | InputDateTimeType
    | InputDurationType
    | InputLiteralType
    | InputUnionType
    | InputModelType
    | InputEnumType
    | InputListType
    | InputDictionaryType;

export interface InputPrimitiveType extends InputTypeBase {
    kind: SdkBuiltInKinds;
    encode?: string; // In TCGC this is required, and when there is no encoding, it just has the same value as kind
}

export interface InputLiteralType extends InputTypeBase {
    kind: "constant";
    valueType: InputPrimitiveType | InputEnumType; // this has to be inconsistent because currently we have possibility of having an enum underlying the literal type
    value: string | number | boolean | null;
}

export function isInputLiteralType(type: InputType): type is InputLiteralType {
    return type.kind === "constant";
}

export type InputDateTimeType = InputUtcDateTimeType | InputOffsetDateTimeType;

interface InputDateTimeTypeBase extends InputTypeBase {
    encode: DateTimeKnownEncoding;
    wireType: InputPrimitiveType;
}

export interface InputUtcDateTimeType extends InputDateTimeTypeBase {
    kind: "utcDateTime";
}

export interface InputOffsetDateTimeType extends InputDateTimeTypeBase {
    kind: "offsetDateTime";
}

export interface InputDurationType extends InputTypeBase {
    kind: "duration";
    encode: DurationKnownEncoding;
    wireType: InputPrimitiveType;
}

export interface InputUnionType extends InputTypeBase {
    kind: "union";
    name: string;
    variantTypes: InputType[];
}

export function isInputUnionType(type: InputType): type is InputUnionType {
    return type.kind === "union";
}

export interface InputModelType extends InputTypeBase {
    kind: InputTypeKind.Model; // TODO -- will change to TCGC value in future refactor
    name: string;
    namespace?: string;
    accessibility?: string;
    deprecated?: string;
    usage: string;
    properties: InputModelProperty[];
    baseModel?: InputModelType;
    discriminatorPropertyName?: string;
    discriminatorValue?: string;
    inheritedDictionaryType?: InputDictionaryType;
}

export function isInputModelType(type: InputType): type is InputModelType {
    return type.kind === InputTypeKind.Model;
}

export interface InputModelProperty {
    name: string;
    serializedName: string;
    description: string;
    type: InputType;
    isRequired: boolean;
    isReadOnly: boolean;
    isDiscriminator?: boolean;
    flattenedNames?: string[];
}

export interface InputEnumType extends InputTypeBase {
    kind: "enum";
    name: string;
    valueType: InputPrimitiveType;
    values: InputEnumTypeValue[];
    namespace?: string;
    accessibility?: string;
    deprecated?: string;
    isExtensible: boolean;
    usage: string;
}

export interface InputEnumTypeValue {
    name: string;
    value: any;
    description?: string;
}

export function isInputEnumType(type: InputType): type is InputEnumType {
    return type.kind === "enum";
}

export interface InputListType extends InputTypeBase {
    kind: InputTypeKind.Array; // TODO -- will change to TCGC value in future refactor
    name: InputTypeKind.Array; // array type does not really have a name right now, we just use its kind
    elementType: InputType;
}

export function isInputListType(type: InputType): type is InputListType {
    return type.kind === InputTypeKind.Array;
}

export interface InputDictionaryType extends InputTypeBase {
    kind: InputTypeKind.Dictionary; // TODO -- will change to TCGC value in future refactor
    name: InputTypeKind.Dictionary; // dictionary type does not really have a name right now, we just use its kind
    keyType: InputType;
    valueType: InputType;
}

export function isInputDictionaryType(
    type: InputType
): type is InputDictionaryType {
    return type.kind === InputTypeKind.Dictionary;
}
