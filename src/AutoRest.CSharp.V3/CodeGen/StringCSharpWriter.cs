using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System.Text;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class StringCSharpWriter : BaseCSharpWriter
    {
        private readonly StringBuilder _builder;

        public StringCSharpWriter()
        {
            _builder = new StringBuilder();
        }
       
        public override void Line(string str = "")
        {
            _builder.AppendLine(str);
        }

        public override void Append(string str = "")
        {
            _builder.Append(str);
        }

        public override string GetFormattedCode()
        {
            var ws = new AdhocWorkspace();
            var cu = SyntaxFactory.ParseCompilationUnit(_builder.ToString());
            var formattedCode = Formatter.Format(cu, ws);

            return formattedCode.ToFullString();
        }
    }
}
