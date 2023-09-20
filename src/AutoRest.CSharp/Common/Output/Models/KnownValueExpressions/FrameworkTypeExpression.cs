// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    /// <summary>
    /// Represents expression which has a return value of a framework type
    /// </summary>
    /// <param name="FrameworkType">Framework type</param>
    /// <param name="Untyped"></param>
    internal sealed record FrameworkTypeExpression(System.Type FrameworkType, ValueExpression Untyped) : TypedValueExpression(FrameworkType, Untyped);
}
