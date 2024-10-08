// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

// TODO: Remove this class and consume Decorators information instead
internal record InputTypeSerialization(bool Json, InputTypeXmlSerialization? Xml)
{
    public static InputTypeSerialization Default { get; } = new(true, null);
}
