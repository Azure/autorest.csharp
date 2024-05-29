// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputGenericType(Type Type, IReadOnlyList<InputType> Arguments, bool IsNullable) : InputType(Type.Name, IsNullable)
{
    public InputGenericType(Type type, bool IsNullable, params InputType[] arguments) : this(type, arguments, IsNullable) { }
}
