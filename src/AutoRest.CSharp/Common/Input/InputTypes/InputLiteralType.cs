// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputLiteralType(string Name, InputPrimitiveType ValueType, object Value) : InputType(Name) // TODO -- name?
{
    // Those two types are actually same, can we merge them?
    public static implicit operator InputConstant(InputLiteralType literal) => new(literal.Value, literal.ValueType);
};
