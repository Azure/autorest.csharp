// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType(string Name, bool IsNullable)
{
    public InputTypeSerialization Serialization { get; init; } = InputTypeSerialization.Default;
}
