// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record PragmaWarningPreprocessorDirective(string action, string warningList) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Line($"#pragma warning {action} {warningList}");
        }
    }
}
