// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal interface IEnumTypeValue
{
    string Name { get; }
    object Value { get; }
    string? Description { get; }
    string GetValueString();
}
