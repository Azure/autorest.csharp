﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record SwitchStatement(ValueExpression MatchExpression) : MethodBodyStatement, IEnumerable<SwitchCase>
    {
        public SwitchStatement(ValueExpression matchExpression, IEnumerable<SwitchCase> cases) : this(matchExpression)
        {
            _cases.AddRange(cases);
        }

        private readonly List<SwitchCase> _cases = new();
        public IReadOnlyList<SwitchCase> Cases => _cases;

        public void Add(SwitchCase statement) => _cases.Add(statement);
        public IEnumerator<SwitchCase> GetEnumerator() => _cases.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_cases).GetEnumerator();

        public sealed override void Write(CodeWriter writer)
        {
            using (writer.AmbientScope())
            {
                writer.Append($"switch (");
                MatchExpression.Write(writer);
                writer.LineRaw(")");
                writer.LineRaw("{");
                foreach (var switchCase in Cases)
                {
                    if (switchCase.Match.Any())
                    {
                        for (var i = 0; i < switchCase.Match.Count; i++)
                        {
                            ValueExpression? match = switchCase.Match[i];
                            writer.AppendRaw("case ");
                            match.Write(writer);
                            if (i < switchCase.Match.Count - 1)
                            {
                                writer.LineRaw(":");
                            }
                        }
                    }
                    else
                    {
                        writer.AppendRaw("default");
                    }

                    writer.AppendRaw(": ");
                    if (!switchCase.Inline)
                    {
                        writer.Line();
                    }

                    if (switchCase.AddScope)
                    {
                        using (writer.Scope())
                        {
                            switchCase.Statement.Write(writer);
                        }
                    }
                    else
                    {
                        switchCase.Statement.Write(writer);
                    }
                }
                writer.LineRaw("}");
            }
        }
    }
}
