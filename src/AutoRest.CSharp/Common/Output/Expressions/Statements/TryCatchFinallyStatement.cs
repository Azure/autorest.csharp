﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record TryCatchFinallyStatement(MethodBodyStatement Try, IReadOnlyList<CatchStatement> Catches, MethodBodyStatement? Finally) : MethodBodyStatement
    {
        public override void Write(CodeWriter writer)
        {
            writer.WriteLineRaw("try");
            writer.WriteLineRaw("{");
            Try.Write(writer);
            writer.WriteLineRaw("}");

            foreach (var catchStatement in Catches)
            {
                catchStatement.Write(writer);
            }

            if (Finally != null)
            {
                writer.WriteLineRaw("finally");
                writer.WriteLineRaw("{");
                Finally.Write(writer);
                writer.WriteLineRaw("}");
            }
        }
    }
}
