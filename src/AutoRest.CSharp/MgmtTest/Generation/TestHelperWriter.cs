// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using System.Collections.Generic;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal class TestHelperWriter
    {
        private CodeWriter _writer;
        private CodeWriter _tagsWriter = new CodeWriter();

        protected string TestNamespace => MgmtContext.Context.DefaultNamespace + ".Tests";
        protected string TypeNameOfThis => "TestHelper";

        public TestHelperWriter(CodeWriter writer)
        {
            _writer = writer;
        }

        public void WriteMockExtension()
        {
            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test Extension for {MgmtContext.Context.DefaultNamespace}");
                _writer.Append($"public static partial class {TypeNameOfThis:D}");
                using (_writer.Scope())
                {
                    WriteReplaceWith();
                }
            }
        }

        public void WriteReplaceWith()
        {
            using (_writer.Scope($"public static {typeof(IDictionary<string, string>)} ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)"))
            {
                _writer.Line($"dest.Clear();");
                using (_writer.Scope($"foreach (var kv in src)"))
                {
                    _writer.Line($"dest.Add(kv);");
                }
                _writer.Line($"return dest;");
            }
            _writer.Line();
        }
    }
}
