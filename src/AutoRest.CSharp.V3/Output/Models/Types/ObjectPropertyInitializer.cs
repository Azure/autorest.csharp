// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.Requests;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectPropertyInitializer
    {
        public ObjectPropertyInitializer(ObjectTypeProperty property, ReferenceOrConstant value)
        {
            Property = property;
            Value = value;
        }

        public ObjectTypeProperty Property { get; }
        public ReferenceOrConstant Value { get; }
    }
}