// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal record ParameterInvocation : Parameter
    {
        public ParameterInvocation(Parameter parameter, FormattableString? Invocation = null) : this(parameter.Name, parameter.Description, parameter.Type, parameter.DefaultValue, parameter.ValidateNotNull, parameter.IsApiVersionParameter, parameter.SkipUrlEncoding, parameter.RequestLocation, Invocation) { }

        public ParameterInvocation(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool ValidateNotNull, bool IsApiVersionParameter = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, FormattableString? Invocation = null) : base(Name, Description, Type, DefaultValue, ValidateNotNull, IsApiVersionParameter, SkipUrlEncoding, RequestLocation)
        {
            this.Invocation = Invocation;
        }

        public FormattableString? Invocation { get; init; }
    }
}
