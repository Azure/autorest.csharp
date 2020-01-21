// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceSchemaType
    {
        public object Name { get; }
        public Accessibility Accessibility { get; }

        public SourceSchemaType(object name, Accessibility accessibility)
        {
            Name = name;
            Accessibility = accessibility;
        }
    }
}
