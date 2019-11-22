// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class StringWriter : WriterBase
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public override void Line(string str = "") => _builder.AppendLine(str);
        public override void Append(string str = "") => _builder.Append(str);
        public override void Replace(string oldValue = "", string newValue = "") => _builder.Replace(oldValue, newValue);
        public override string ToFormattedCode()
        {
            var syntax = SyntaxFactory.ParseCompilationUnit(ToString());
            return Formatter.Format(syntax, new AdhocWorkspace()).ToFullString();
        }

        public override string? ToString() => _builder.ToString();
    }
}
