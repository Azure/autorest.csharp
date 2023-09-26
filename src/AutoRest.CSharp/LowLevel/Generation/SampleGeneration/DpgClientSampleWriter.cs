// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Samples;

namespace AutoRest.CSharp.LowLevel.Generation.SampleGeneration
{
    internal class DpgClientSampleWriter : DpgClientSampleBaseWriter
    {
        private readonly DpgClientSampleProvider _sampleProvider;

        public DpgClientSampleWriter(DpgClientSampleProvider sampleProvider) : base()
        {
            _sampleProvider = sampleProvider;
        }

        protected override bool ShouldWriteResponse => true;

        public override void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace(_sampleProvider.Declaration.Namespace))
            {
                using (_writer.Scope($"public class {_sampleProvider.Type:D}"))
                {
                    //foreach (var sample in _sampleProvider.Samples)
                    //{
                    //    WriteTestMethod(sample, false);
                    //    WriteTestMethod(sample, true);
                    //}
                    foreach (var method in _sampleProvider.SampleMethods)
                    {
                        _writer.WriteMethod(method);
                    }
                }
            }
        }
    }
}
