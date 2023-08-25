// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputLiteralType(InputConstant Value, bool IsNullable) : InputType(InputLiteralTypeName, IsNullable)
{
    public const string InputLiteralTypeName = "Literal";
}
