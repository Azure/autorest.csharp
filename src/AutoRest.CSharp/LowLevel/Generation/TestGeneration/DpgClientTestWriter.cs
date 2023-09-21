// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
                using (_writer.Scope($"public class {_testProvider.Declaration.Name}"))
                {
                    foreach (var sample in _testProvider.TestCases)
                    {
                        WriteTestMethod(sample, false);
                        WriteTestMethod(sample, true);
                    }
                }
            }
        }
    }
}
