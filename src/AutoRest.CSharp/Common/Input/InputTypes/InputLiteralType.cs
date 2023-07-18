// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputLiteralType(string Name, InputType LiteralValueType, object Value, bool IsConfident, bool IsNullable = false) : InputType(Name, IsConfident, IsNullable);
