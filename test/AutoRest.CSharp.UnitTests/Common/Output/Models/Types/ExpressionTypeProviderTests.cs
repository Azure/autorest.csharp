using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;

namespace AutoRest.CSharp.Tests.Common.Output.Models.Types
{
    public class ExpressionTypeProviderTests
    {
        private const string ns = "Tests";
        private ExpressionTypeProvider _outerProvider;
        public ExpressionTypeProviderTests()
        {
            _outerProvider = new OuterType(ns);
        }

        [Test]
        public async Task TestNestedTypeDeclaration()
        {
            var writer = new CodeWriter();
            new ExpressionTypeProviderWriter(writer, _outerProvider).Write();
            var result = writer.ToString(false);

            var syntaxTree = CSharpSyntaxTree.ParseText(result);
            var compilation = GetCompilation(syntaxTree);
            var semanticModel = compilation.GetSemanticModel(syntaxTree);

            var root = await syntaxTree.GetRootAsync();
            var typeNodes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();

            var outerNode = typeNodes.FirstOrDefault();
            Assert.IsNotNull(outerNode);

            var outerType = semanticModel.GetDeclaredSymbol(outerNode);
            Assert.IsNotNull(outerType);

            Assert.AreEqual($"global::{ns}.OuterType", outerType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));

            var typeMembers = outerType.GetTypeMembers();
            Assert.AreEqual(1, typeMembers.Length);
            var innerType = typeMembers[0];
            Assert.AreEqual($"global::{ns}.OuterType.InnerType", innerType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
        }

        [Test]
        public void TestNestedTypeUsage()
        {
            var writer = new CodeWriter();
            var innerType = _outerProvider.NestedTypes.FirstOrDefault() as InnerType;
            Assert.IsNotNull(innerType);
            writer.Append($"{innerType.Type}");
            var result = writer.ToString(false).Trim();

            Assert.AreEqual($"global::{ns}.OuterType.InnerType", result);
        }

        private static Compilation GetCompilation(SyntaxTree root)
        {
            // load corlib
            var mscorlib = MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location);
            return CSharpCompilation.Create("ConsoleApplication",
                     new[] { root },
                     new[] { mscorlib });
        }

        private sealed class OuterType : ExpressionTypeProvider
        {
            public OuterType(string defaultNamespace) : base(defaultNamespace, null)
            {
            }

            protected override string DefaultName => "OuterType";
            protected override string DefaultAccessibility => "public";

            protected override IEnumerable<ExpressionTypeProvider> BuildNestedTypes()
            {
                yield return new InnerType(this, Declaration.Namespace);
            }
        }

        private sealed class InnerType : ExpressionTypeProvider
        {
            public InnerType(OuterType outerType, string defaultNamespace) : base(defaultNamespace, null)
            {
                DeclaringTypeProvider = outerType;
            }

            protected override string DefaultName => "InnerType";

            protected override string DefaultAccessibility => "public";
        }
    }
}
