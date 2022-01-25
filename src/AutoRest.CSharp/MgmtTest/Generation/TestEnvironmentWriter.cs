// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal class TestEnvironmentWriter
    {
        private CodeWriter _writer;
        private CodeWriter _tagsWriter = new CodeWriter();

        protected string TestNamespace => MgmtContext.Context.DefaultNamespace + ".Tests";
        public string TypeName => $"{MgmtContext.Context.DefaultLibraryName}TestEnvironment";

        public TestEnvironmentWriter(CodeWriter writer)
        {
            _writer = writer;
        }

        public void WriteTestEnvironment()
        {
            _writer.UseNamespace($"Azure.Core.TestFramework");
            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test Environment for {MgmtContext.Context.DefaultNamespace}");
                _writer.Append($"public partial class {TypeName:D}:TestEnvironment");
                using (_writer.Scope())
                {
                }
            }
        }
    }
}
