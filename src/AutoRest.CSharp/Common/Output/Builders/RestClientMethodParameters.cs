// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record RestClientMethodParameters
    (IReadOnlyList<RequestPartSource> RequestParts,
        IReadOnlyList<Parameter> CreateMessage,
        IReadOnlyList<Parameter> Protocol,
        IReadOnlyList<Parameter> Convenience,
        IReadOnlyDictionary<Parameter, ValueExpression> Arguments,
        IReadOnlyDictionary<Parameter, MethodBodyStatement> Conversions,
        bool ShouldGenerateConvenienceMethod,
        bool HasAmbiguityBetweenProtocolAndConvenience);
}
