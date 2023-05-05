// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record SwitchCase(ValueExpression Case, MethodBodyStatement Statement, bool Inline = false, bool AddScope = false);
}
