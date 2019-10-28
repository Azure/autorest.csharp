using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System.Text;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class StringCSharpWriter : BaseCSharpWriter
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public override void Line(string str = "") => _builder.AppendLine(str);
        public override void Append(string str = "") => _builder.Append(str);
        public override void Replace(string oldValue = "", string newValue = "") => _builder.Replace(oldValue, newValue);
        public override string GetFormattedCode()
        {
            var ws = new AdhocWorkspace();
            var cu = SyntaxFactory.ParseCompilationUnit(_builder.ToString());
            return Formatter.Format(cu, ws).ToFullString();
        }
    }
}
