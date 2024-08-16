// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeValue(string Name, object Value, string? Description)
{
    public virtual string GetJsonValueString() => GetValueString();
    public string GetValueString() => (Value.ToString() ?? string.Empty);

    public string Name { get; internal set; } = Name;
    public IReadOnlyList<InputDecoratorInfo> Decorators { get; internal set; } = new List<InputDecoratorInfo>();
}
