// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input
{
    internal record InputTypeSerialization(bool Json, InputTypeXmlSerialization? Xml)
    {
        public static InputTypeSerialization Default { get; } = new(true, null);
    }

    internal record InputTypeXmlSerialization(string Name, bool IsAttribute, bool IsContent);
}
