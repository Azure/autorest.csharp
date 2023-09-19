// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract record MethodSignatureBase(string Name, FormattableString? Summary, FormattableString? Description, MethodSignatureModifiers Modifiers, IReadOnlyList<Parameter> Parameters, IReadOnlyList<CSharpAttribute> Attributes)
    {
        private bool IsSummaryNullOrEmpty => string.IsNullOrEmpty(Summary?.ToString());
        public FormattableString? SummaryText => IsSummaryNullOrEmpty ? Description : Summary;
        public FormattableString? DescriptionText => IsSummaryNullOrEmpty || Description == Summary ? $"" : Description;
    }

    [Flags]
    internal enum MethodSignatureModifiers
    {
        None = 0,
        Public = 1,
        Internal = 2,
        Protected = 4,
        Private = 8,
        Static = 16,
        Extension = 32,
        Virtual = 64,
        Async = 128,
        New = 256,
        Override = 512
    }
}
