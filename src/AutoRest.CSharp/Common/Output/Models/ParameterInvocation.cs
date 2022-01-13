// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal record ParameterInvocation : Parameter
    {
        public ParameterInvocation(Parameter parameter, CodeWriterDelegate? Invocation = default) : this(parameter.Name, parameter.Description, parameter.Type, parameter.DefaultValue, parameter.ValidateNotNull, IsApiVersionParameter: parameter.IsApiVersionParameter, IsResourceIdentifier: parameter.IsResourceIdentifier, SkipUrlEncoding: parameter.SkipUrlEncoding, RequestLocation: parameter.RequestLocation, Invocation: Invocation) { }

        public ParameterInvocation(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool ValidateNotNull, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, CodeWriterDelegate? Invocation = default) : base(Name, Description, Type, DefaultValue, ValidateNotNull, IsApiVersionParameter: IsApiVersionParameter, IsResourceIdentifier: IsResourceIdentifier, SkipUrlEncoding: SkipUrlEncoding, RequestLocation: RequestLocation)
        {
            this.Invocation = Invocation;
        }

        public CodeWriterDelegate? Invocation { get; init; }
    }
}
