// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectPropertyInitializer
    {
        internal static readonly ObjectPropertyInitializer RawData = new ObjectPropertyInitializer(ObjectTypeProperty.RawData, Parameter.RawData);

        public ObjectPropertyInitializer(ObjectTypeProperty property, ReferenceOrConstant value, ReferenceOrConstant? defaultValue = null)
        {
            Property = property;
            Value = value;
            DefaultValue = defaultValue;
        }

        public ObjectTypeProperty Property { get; }
        public ReferenceOrConstant Value { get; }
        public ReferenceOrConstant? DefaultValue { get; }
    }
}
