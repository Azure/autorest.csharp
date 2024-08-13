// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputLiteralType(InputType ValueType, object Value, IReadOnlyList<InputDecoratorInfo>? Decorators = null) : InputType("Literal", Decorators) // TODO -- name?
{
    // Those two types are actually same, can we merge them?
    public static implicit operator InputConstant(InputLiteralType literal) => new(literal.Value, literal.ValueType);
};
