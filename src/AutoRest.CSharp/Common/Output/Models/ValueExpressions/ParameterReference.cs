// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record ParameterReference(Parameter Parameter) : ValueExpression;
}
