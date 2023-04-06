// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal record MethodBodyStatement
    {
        public static implicit operator MethodBodyStatement(MethodBodyStatement[] statements) => new MethodBodyStatements(Statements: statements);

        private string GetDebuggerDisplay()
        {
            using var writer = new DebuggerCodeWriter();
            writer.WriteMethodBodyStatement(this);
            return writer.ToString();
        }
    }
}
