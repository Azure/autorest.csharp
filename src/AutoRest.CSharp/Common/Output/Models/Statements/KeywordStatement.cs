﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record KeywordStatement(string Keyword, ValueExpression? Expression) : MethodBodyStatement;
}
