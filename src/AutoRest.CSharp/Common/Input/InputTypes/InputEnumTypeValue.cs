// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeValue(string Name, object Value, string? Description, string? OriginalName = null)
{
    public virtual string GetJsonValueString() => GetValueString();
    public string GetValueString() => (Value.ToString() ?? string.Empty);

    public string Name { get; internal set;} = Name;
    public string? OriginalName { get; internal set; } = OriginalName;
}
