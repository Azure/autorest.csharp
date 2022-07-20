// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputType } from "./InputType";
import { InputTypeKind } from "./InputTypeKind";
import { InputTypeSerializationFormat } from "./InputTypeSerializationFormat";
import { InputTypeValue } from "./InputTypeValue";

// ToDO: need to refine
export interface Schema {
    Name: string;
}
export class CodeModelType implements InputType {
    public constructor(schema: Schema,
        kind: InputTypeKind,
        isNullable: boolean = false,
        format: InputTypeSerializationFormat = InputTypeSerializationFormat.Default) {
            this.Schema = schema;
            this.Kind = kind;
            this.Name = schema.Name;
            this.IsNullable = isNullable;
            this.AllowedValues = undefined;
            this.SerializationFormat = format;

        }
    Name: string;
    Kind: InputTypeKind;
    IsNullable: boolean;
    SerializationFormat: InputTypeSerializationFormat;
    ValuesType?: InputType | undefined;
    AllowedValues?: InputTypeValue[] | undefined;
    public Schema: Schema;

}