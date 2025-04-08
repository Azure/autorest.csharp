// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputClient(string Name, string? Summary, string? Doc, IReadOnlyList<InputServiceMethod>? Methods, IReadOnlyList<InputOperation> Operations, IReadOnlyList<InputParameter> Parameters, InputClient? Parent, IReadOnlyList<InputClient> Children)
{
    private readonly string? _key;
    private readonly IReadOnlyList<InputOperation> _inputOperations = Operations;
    private IReadOnlyList<InputOperation>? _constructedOperations;

    public string Key
    {
        get => _key ?? Name;
        init => _key = value;
    }

    // Methods only exist in typespec code model. If present, they are used to construct the input operations.
    public IReadOnlyList<InputOperation> Operations
    {
        get => _constructedOperations ??= Methods != null
            ? BuildOperationsFromMethods(Methods)
            : _inputOperations ?? [];
        internal set => _constructedOperations = value;
    }

    public IReadOnlyList<InputDecoratorInfo> Decorators { get; internal set; } = new List<InputDecoratorInfo>();

    public InputClient() : this(string.Empty, string.Empty, string.Empty, Array.Empty<InputServiceMethod>(), Array.Empty<InputOperation>(), Array.Empty<InputParameter>(), null, []) { }

    private static List<InputOperation> BuildOperationsFromMethods(IReadOnlyList<InputServiceMethod> methods)
    {
        var operations = new List<InputOperation>();
        foreach (var method in methods)
        {
            operations.Add(method.Operation);
        }
        return operations;
    }
}
