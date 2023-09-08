// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    /// <summary>
    /// A wrapper around ValueExpression that also specifies return type of the expression
    /// Return type doesn't affect how expression is written, but help creating strong-typed helpers to create value expressions
    /// </summary>
    /// <param name="ReturnType">Type expected to be returned by value expression</param>
    /// <param name="Untyped"></param>
    internal abstract record TypedValueExpression(CSharpType ReturnType, ValueExpression Untyped) : ValueExpression
    {
    }
}
