// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input.Examples;

namespace AutoRest.CSharp.Common.Input;

internal record InputClient(string Name, string Description, IReadOnlyList<InputOperation> Operations, bool Creatable, IReadOnlyList<InputParameter> Parameters, string? Parent)
{
    private readonly string? _key;

    public string Key
    {
        get => _key ?? Name;
        init => _key = value;
    }

    public InputClient() : this(string.Empty, string.Empty, Array.Empty<InputOperation>(), true, Array.Empty<InputParameter>(), null) { }

    private IReadOnlyDictionary<string, InputClientExample>? _examples;
    public IReadOnlyDictionary<string, InputClientExample> Examples => _examples ??= EnsureExamples();

    private IReadOnlyDictionary<string, InputClientExample> EnsureExamples()
    {
        return new Dictionary<string, InputClientExample>()
        {
            [ExampleMockValueBuilder.MockExampleKey] = ExampleMockValueBuilder.BuildClientExample(this)
        };
    }
}
