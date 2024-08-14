// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputClient(string Name, string Description, IReadOnlyList<InputOperation> Operations, IReadOnlyList<InputParameter> Parameters, string? Parent)
{
    private readonly string? _key;

    public string Key
    {
        get => _key ?? Name;
        init => _key = value;
    }

    public IReadOnlyList<InputOperation> Operations { get; internal set; } = Operations ?? Array.Empty<InputOperation>();
    public IReadOnlyList<InputDecoratorInfo> Decorators { get; internal set; } = new List<InputDecoratorInfo>();

    public InputClient() : this(string.Empty, string.Empty, Array.Empty<InputOperation>(), Array.Empty<InputParameter>(), null) { }
}
