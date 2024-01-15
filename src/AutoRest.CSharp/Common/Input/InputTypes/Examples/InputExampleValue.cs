// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal abstract record InputExampleValue(IType Type)
    {
        public static InputExampleValue Null(IType type) => new InputExampleRawValue(type, null);
        public static InputExampleValue Value(IType type, object? rawValue) => new InputExampleRawValue(type, rawValue);
        public static InputExampleValue List(IType type, IReadOnlyList<InputExampleValue> values) => new InputExampleListValue(type, values);
        public static InputExampleValue Object(IType type, IReadOnlyDictionary<string, InputExampleValue> properties) => new InputExampleObjectValue(type, properties);
        public static InputExampleValue Stream(IType type, string filename) => new InputExampleStreamValue(type, filename);
    }

    internal record InputExampleRawValue(IType Type, object? RawValue) : InputExampleValue(Type);

    internal record InputExampleListValue(IType Type, IReadOnlyList<InputExampleValue> Values) : InputExampleValue(Type);

    internal record InputExampleObjectValue(IType Type, IReadOnlyDictionary<string, InputExampleValue> Values): InputExampleValue(Type);

    internal record InputExampleStreamValue(IType Type, string Filename): InputExampleValue(Type);
}
