// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Samples.Models
{
    /// <summary>
    /// A <see cref="InputExampleParameterValue"/> represents a value for a parameter, which could either be a <see cref="InputTypeExample"/>, or a <see cref="FormattableString"/> as a literal
    /// </summary>
    internal record InputExampleParameterValue
    {
        public string Name { get; }

        public CSharpType Type { get; }

        public InputTypeExample? Value { get; }

        public ValueExpression? Expression { get; }

        private InputExampleParameterValue(string name, CSharpType type)
        {
            Name = name;
            Type = type;
        }

        public InputExampleParameterValue(Reference reference, InputTypeExample value) : this(reference.Name, reference.Type)
        {
            Value = value;
        }

        public InputExampleParameterValue(Reference reference, ValueExpression expression) : this(reference.Name, reference.Type)
        {
            Expression = expression;
        }

        public InputExampleParameterValue(Parameter parameter, InputTypeExample value) : this(parameter.Name, parameter.Type)
        {
            Value = value;
        }

        public InputExampleParameterValue(Parameter parameter, ValueExpression expression) : this(parameter.Name, parameter.Type)
        {
            Expression = expression;
        }
    }
}
