// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Samples;

namespace AutoRest.CSharp.LowLevel.Generation.SampleGeneration
{
    internal class DpgClientSampleWriter
    {
        private readonly CodeWriter _writer;
        private readonly DpgClientSampleProvider _sampleProvider;

        public DpgClientSampleWriter(DpgClientSampleProvider sampleProvider)
        {
            _sampleProvider = sampleProvider;
            _writer = new CodeWriter();
        }

        public void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace(_sampleProvider.Declaration.Namespace))
            {
                using (_writer.Scope($"{_sampleProvider.Declaration.Accessibility} partial class {_sampleProvider.Type:D}"))
                {
                    foreach (var method in _sampleProvider.Methods)
                    {
                        _writer.WriteMethod(method);
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
