// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Tests;

namespace AutoRest.CSharp.LowLevel.Generation.Tests
{
    internal class DpgTestEnvironmentWriter
    {
        private readonly DpgTestEnvironment _dpgTestEnvironment;
        private readonly CodeWriter _writer;
        public DpgTestEnvironmentWriter(DpgTestEnvironment dpgTestEnvironment)
        {
            _dpgTestEnvironment = dpgTestEnvironment;
            _writer = new CodeWriter();
        }

        public void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace(_dpgTestEnvironment.Declaration.Namespace))
            {
                using (_writer.Scope($"{_dpgTestEnvironment.Declaration.Accessibility} partial class {_dpgTestEnvironment.Type:D} : {_dpgTestEnvironment.BaseType:D}"))
                {
                    WriteConstructors();

                    // TODO -- write the client factory methods
                }
            }
        }

        private void WriteConstructors()
        {
            //foreach (var ctor in _testBase.Constructors)
            //{
            //    using (_writer.WriteMethodDeclaration(ctor))
            //    { }
            //}
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
