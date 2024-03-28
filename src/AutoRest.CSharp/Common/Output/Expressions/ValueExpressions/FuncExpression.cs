// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record FuncExpression(IReadOnlyList<CodeWriterDeclaration?> Parameters, ValueExpression Inner) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            using (writer.AmbientScope())
            {
                if (Parameters.Count == 1)
                {
                    var parameter = Parameters[0];
                    if (parameter is not null)
                    {
                        writer.Declaration(parameter);
                    }
                    else
                    {
                        writer.AppendRaw("_");
                    }
                }
                else
                {
                    writer.AppendRaw("(");
                    foreach (var parameter in Parameters)
                    {
                        if (parameter is not null)
                        {
                            writer.Declaration(parameter);
                        }
                        else
                        {
                            writer.AppendRaw("_");
                        }
                        writer.AppendRaw(", ");
                    }

                    writer.RemoveTrailingComma();
                    writer.AppendRaw(")");
                }

                writer.AppendRaw(" => ");
                Inner.Write(writer);
            }
        }
    }
}
