using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class CodeWriterScopeDeclarationsTests
    {
        [Test]
        public void UniqueRequestedNames()
        {
            var declarations = new CodeWriterScopeDeclarations(new CodeWriterDeclaration[]
            {
                new CodeWriterDeclaration("foo"),
                new CodeWriterDeclaration("bar")
            });

            Assert.AreEqual(declarations.Names, new string[] { "foo", "bar" });
        }

        [Test]
        public void DuplicatedRequestedNames()
        {
            var declarations = new CodeWriterScopeDeclarations(new CodeWriterDeclaration[]
            {
                new CodeWriterDeclaration("foo"),
                new CodeWriterDeclaration("foo"),
                new CodeWriterDeclaration("foo")
            });

            Assert.AreEqual(declarations.Names, new string[] { "foo", "foo0", "foo1" });
        }
    }
}
