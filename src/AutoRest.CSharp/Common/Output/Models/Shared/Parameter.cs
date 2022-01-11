// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool ValidateNotNull, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None)
    {
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsRequired => DefaultValue is null;
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
