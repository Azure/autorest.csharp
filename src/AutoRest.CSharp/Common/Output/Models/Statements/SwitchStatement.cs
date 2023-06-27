// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.Statements
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
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((System.Collections.IEnumerable)_cases).GetEnumerator();
    }
}
