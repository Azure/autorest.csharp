// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputTypeKind } from "./InputTypeKind";
import { InputTypeSerializationFormat } from "./InputTypeSerializationFormat.js";
import { InputTypeValue } from "./InputTypeValue";

export interface IInputType {
    Name: string;
    Kind: string;
    IsNullable: boolean;
    SerializationFormat: InputTypeSerializationFormat;
    ValuesType?: InputType | undefined;
    AllowedValues?: InputTypeValue[] | undefined;
}
export class InputType implements IInputType {
    public constructor(
        name: string,
        kind: InputTypeKind,
        isNullable: boolean,
        format: InputTypeSerializationFormat = InputTypeSerializationFormat.Default,
        valuesType: InputType | undefined = undefined,
        allowValues: InputTypeValue[] | undefined = undefined
    ) {
        this.Name = name;
        this.Kind = kind;
        this.IsNullable = isNullable;
        this.SerializationFormat = format;
        this.ValuesType = valuesType;
        this.AllowedValues = allowValues;
    }
    Name: string;
    Kind: InputTypeKind;
    IsNullable: boolean;
    SerializationFormat: InputTypeSerializationFormat;
    ValuesType?: InputType | undefined;
    AllowedValues?: InputTypeValue[] | undefined;
}
