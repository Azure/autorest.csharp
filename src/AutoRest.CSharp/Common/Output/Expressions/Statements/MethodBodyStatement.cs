// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal record MethodBodyStatement
    {
        public virtual void Write(CodeWriter writer) { }

        public static implicit operator MethodBodyStatement(MethodBodyStatement[] statements) => new MethodBodyStatements(Statements: statements);
        public static implicit operator MethodBodyStatement(List<MethodBodyStatement> statements) => new MethodBodyStatements(Statements: statements);

        private string GetDebuggerDisplay()
        {
            using var writer = new DebuggerCodeWriter();
            Write(writer);
            return writer.ToString();
        }
    }
}
