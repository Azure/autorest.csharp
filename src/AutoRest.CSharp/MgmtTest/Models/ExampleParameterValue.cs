// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.MgmtTest.Models
{
    /// <summary>
    /// A <see cref="ExampleParameterValue"/> represents a value for a parameter, which could either be a <see cref="ExampleValue"/>, or a <see cref="FormattableString"/> as a literal
    /// </summary>
    /// <param name="Parameter"></param>
    /// <param name="Value"></param>
    /// <param name="RawValue"></param>
    internal record ExampleParameterValue(Parameter Parameter)
    {
        public ExampleValue? Value { get; }

        public FormattableString? Expression { get; }

        public ExampleParameterValue(Parameter parameter, ExampleValue value) : this(parameter)
        {
            Value = value;
        }

        public ExampleParameterValue(Parameter parameter, FormattableString rawValue) : this(parameter)
        {
            Expression = rawValue;
        }
    }
}
