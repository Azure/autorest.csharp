// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal abstract record InputTypeExample(InputType Type)
    {
        public static InputTypeExample Null(InputType type) => new InputExampleRawValue(type, null);
        public static InputTypeExample Value(InputType type, object? rawValue) => new InputExampleRawValue(type, rawValue);
        public static InputTypeExample List(InputType type, IReadOnlyList<InputTypeExample> values) => new InputExampleListValue(type, values);
        public static InputTypeExample Object(InputType type, IReadOnlyDictionary<string, InputTypeExample> properties) => new InputExampleObjectValue(type, properties);
        public static InputTypeExample Stream(InputType type, string filename) => new InputExampleStreamValue(type, filename);
    }

    internal record InputExampleRawValue(InputType Type, object? RawValue) : InputTypeExample(Type);

    internal record InputExampleListValue(InputType Type, IReadOnlyList<InputTypeExample> Values) : InputTypeExample(Type);

    internal record InputExampleObjectValue(InputType Type, IReadOnlyDictionary<string, InputTypeExample> Values): InputTypeExample(Type); // TODO -- split this into model and dict

    internal record InputExampleStreamValue(InputType Type, string Filename): InputTypeExample(Type);
}
