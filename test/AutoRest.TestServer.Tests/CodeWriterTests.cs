// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class CodeWriterTests
    {
        [Test]
        public void GeneratesNewNamesInChildScope()
        {
            var codeWriter = new CodeWriter();
            var cwd1 = new CodeWriterDeclaration("a");
            var cwd2 = new CodeWriterDeclaration("a");
            codeWriter.Line($"{cwd1:D}");
            using (codeWriter.Scope())
            {
                codeWriter.Line($"{cwd2:D}");
            }

            Assert.AreEqual(
                @"a
{
a0
}
", codeWriter.ToString(false));
        }

        [Test]
        public void ScopeLineIsInsideScope()
        {
            var codeWriter = new CodeWriter();
            var cwd1 = new CodeWriterDeclaration("a");
            var cwd2 = new CodeWriterDeclaration("a");
            using (codeWriter.Scope($"{cwd1:D}"))
            {
            }
            using (codeWriter.Scope($"{cwd2:D}"))
            {
            }

            Assert.AreEqual(
                @"a
{
}
a
{
}
", codeWriter.ToString(false));
        }

        [Test]
        public void VariableNameNotReusedWhenUsedInChiledScope()
        {
            var codeWriter = new CodeWriter();
            var cwd1 = new CodeWriterDeclaration("a");
            var cwd2 = new CodeWriterDeclaration("a");
            using (codeWriter.Scope())
            {
                codeWriter.Line($"{cwd1:D}");
            }

            codeWriter.Line($"{cwd2:D}");

            Assert.AreEqual(
                @"{
a
}
a0
", codeWriter.ToString(false));
        }
    }
}
