// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Samples.Models
{
    /// <summary>
    /// A <see cref="ExampleParameterValue"/> represents a value for a parameter, which could either be a <see cref="InputExampleValue"/>, or a <see cref="ValueExpression"/> as an expression
    /// </summary>
    internal record ExampleParameterValue
    {
        public string Name { get; }

        public CSharpType Type { get; }

        public InputExampleValue? Value { get; }

        public ValueExpression? Expression { get; }

        private ExampleParameterValue(string name, CSharpType type)
        {
            Name = name;
            Type = type;
        }

        public ExampleParameterValue(Reference reference, InputExampleValue value) : this(reference.Name, reference.Type)
        {
            Value = value;
        }

        public ExampleParameterValue(Reference reference, ValueExpression expression) : this(reference.Name, reference.Type)
        {
            Expression = expression;
        }

        public ExampleParameterValue(Parameter parameter, InputExampleValue value) : this(parameter.Name, parameter.Type)
        {
            Value = value;
        }

        public ExampleParameterValue(Parameter parameter, ValueExpression expression) : this(parameter.Name, parameter.Type)
        {
            Expression = expression;
        }
    }
}
