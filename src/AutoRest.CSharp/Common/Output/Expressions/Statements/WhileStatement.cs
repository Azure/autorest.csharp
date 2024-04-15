// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record WhileStatement(BoolExpression Condition) : MethodBodyStatement, IEnumerable<MethodBodyStatement>
    {
        private readonly List<MethodBodyStatement> _body = new();
        public IReadOnlyList<MethodBodyStatement> Body => _body;

        public void Add(MethodBodyStatement statement) => _body.Add(statement);
        public IEnumerator<MethodBodyStatement> GetEnumerator() => _body.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_body).GetEnumerator();

        public sealed override void Write(CodeWriter writer)
        {
            using (writer.AmbientScope())
            {
                writer.AppendRaw("while (");
                Condition.Write(writer);
                writer.LineRaw(")");

                writer.LineRaw("{");
                foreach (var bodyStatement in Body)
                {
                    bodyStatement.Write(writer);
                }
                writer.LineRaw("}");
            }
        }
    }
}
