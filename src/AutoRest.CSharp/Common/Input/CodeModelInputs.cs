// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Input;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record CodeModelSecurity(IReadOnlyList<SecurityScheme> Schemes) : InputAuth();

    internal record CodeModelType(Schema Schema, InputTypeKind Kind, bool IsNullable = false, InputTypeSerializationFormat SerializationFormat = InputTypeSerializationFormat.Default)
        : InputType(Schema.Name, Kind, IsNullable, SerializationFormat);
}
