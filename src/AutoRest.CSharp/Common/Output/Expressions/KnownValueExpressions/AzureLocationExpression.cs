// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;
using Microsoft.CodeAnalysis.Operations;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record AzureLocationExpression(ValueExpression Untyped) : TypedValueExpression<AzureLocation>(Untyped)
    {
    }
}
