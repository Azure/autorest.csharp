// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Tests;

namespace AutoRest.CSharp.LowLevel.Generation.TestGeneration
{
    internal class DpgClientTestWriter : DpgClientSampleBaseWriter
    {
        private readonly DpgClientTestProvider _testProvider;

        public DpgClientTestWriter(DpgClientTestProvider testProvider) : base()
        {
            _testProvider = testProvider;
        }

        public override void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace(_testProvider.Declaration.Namespace))
            {
                using (_writer.Scope($"public class {_testProvider.Type:D} : {_testProvider.BaseType:D}"))
                {
                    WriteConstructors();

                    foreach (var sample in _testProvider.TestCases)
                    {
                        // we do not need to write the non-async test cases
                        WriteTestMethod(sample, true);
                    }
                }
            }
        }

        private void WriteConstructors()
        {
            foreach (var ctor in _testProvider.Constructors)
            {
                _writer.Line();
                using (_writer.WriteMethodDeclaration(ctor))
                { }
            }

            _writer.Line();
        }
    }
}
