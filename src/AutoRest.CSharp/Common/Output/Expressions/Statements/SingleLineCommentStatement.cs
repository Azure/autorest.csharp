// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements;

internal record SingleLineCommentStatement(FormattableString Message) : MethodBodyStatement
{
    public SingleLineCommentStatement(string message) : this(FormattableStringHelpers.FromString(message))
    { }
}
