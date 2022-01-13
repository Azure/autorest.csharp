// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool ValidateNotNull, bool IsRequired, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, bool UseDefaultValueInCtorParam = true)
    {
        public Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool ValidateNotNull, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None)
            :this(Name, Description, Type, DefaultValue, ValidateNotNull, DefaultValue is null, IsApiVersionParameter, IsResourceIdentifier, SkipUrlEncoding, RequestLocation)
        {
        }

        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
    }

    internal enum RequestLocation
    {
        None,
        Uri,
        Path,
        Query,
        Header,
        Body,
    }
}
