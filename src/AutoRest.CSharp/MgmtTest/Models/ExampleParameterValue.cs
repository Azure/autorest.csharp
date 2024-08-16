// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.MgmtTest.Models
{
    /// <summary>
    /// A <see cref="ExampleParameterValue"/> represents a value for a parameter, which could either be a <see cref="ExampleValue"/>, or a <see cref="FormattableString"/> as a literal
    /// </summary>
    /// <param name="Parameter"></param>
    /// <param name="Value"></param>
    /// <param name="RawValue"></param>
    internal record ExampleParameterValue
    {
        public string Name { get; }

        public CSharpType Type { get; }

        public InputExampleValue? Value { get; }

        public FormattableString? Expression { get; }

        private ExampleParameterValue(string name, CSharpType type)
        {
            Name = name;
            Type = type;
        }

        public ExampleParameterValue(Reference reference, InputExampleValue value) : this(reference.Name, reference.Type)
        {
            Value = value;
        }

        public ExampleParameterValue(Reference reference, FormattableString rawValue) : this(reference.Name, reference.Type)
        {
            Expression = rawValue;
        }

        public ExampleParameterValue(Parameter parameter, InputExampleValue value) : this(parameter.Name, parameter.Type)
        {
            Value = value;
        }

        public ExampleParameterValue(Parameter parameter, FormattableString rawValue) : this(parameter.Name, parameter.Type)
        {
            Expression = rawValue;
        }
    }
}
