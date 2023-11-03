// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectPropertyInitializer
    {
        public ObjectPropertyInitializer(ObjectTypeProperty property, TypedValueExpression value, TypedValueExpression? defaultValue = null)
        {
            Property = property;
            Value = value;
            DefaultValue = defaultValue;
        }

        public ObjectTypeProperty Property { get; }
        public TypedValueExpression Value { get; }
        public TypedValueExpression? DefaultValue { get; }
    }
}
