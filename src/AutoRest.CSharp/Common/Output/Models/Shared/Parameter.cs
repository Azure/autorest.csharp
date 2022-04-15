// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, bool Validate, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, bool UseDefaultValueInCtorParam = true)
    {
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsRequired => DefaultValue is null;
        public Constant? forceInitializeValue { get; init; }
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
