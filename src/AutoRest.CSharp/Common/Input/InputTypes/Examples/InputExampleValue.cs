// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.Examples
{
    /// <summary>
    /// For a case of null value, Elements, Properties and RawValue are all null
    /// For a case of array type, Elements is not null
    /// For a case of dictionary or complex object, Properties is not null
    /// For other cases, RawValue is not null
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="RawValue"></param>
    /// <param name="Elements"></param>
    /// <param name="Properties"></param>
    internal record InputExampleValue(InputType Type, object? RawValue, IReadOnlyList<InputExampleValue>? Elements, IReadOnlyDictionary<string, InputExampleValue>? Properties)
    {
        public static InputExampleValue Null(InputType type) => new(type, null, null, null);

        public static InputExampleValue FromRawValue(InputType type, object? rawValue) => new(type, rawValue, null, null);

        public static InputExampleValue FromList(InputType type, IReadOnlyList<InputExampleValue> values) => new(type, null, values, null);

        public static InputExampleValue FromDictionary(InputType type, IReadOnlyDictionary<string, InputExampleValue> properties) => new(type, null, null, properties);
    }
}
