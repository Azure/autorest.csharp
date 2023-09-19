// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Tests;

namespace AutoRest.CSharp.LowLevel.Generation.Tests
{
    internal class DpgTestBaseWriter
    {
        private readonly DpgTestBase _testBase;
        private readonly CodeWriter _writer;
        public DpgTestBaseWriter(DpgTestBase dpgTestBase)
        {
            _testBase = dpgTestBase;
            _writer = new CodeWriter();
        }

        public void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace(_testBase.Declaration.Namespace))
            {
                using (_writer.Scope($"{_testBase.Declaration.Accessibility} partial class {_testBase.Type:D} : {_testBase.BaseType:D}"))
                {
                    WriteConstructors();

                    WriteClientFactoryMethods();
                }
            }
        }

        private void WriteConstructors()
        {
            foreach (var ctor in _testBase.Constructors)
            {
                using (_writer.WriteMethodDeclaration(ctor))
                { }
            }
        }

        private void WriteClientFactoryMethods()
        {
            foreach (var method in _testBase.CreateClientMethods)
            {
                _writer.Line();
                using (_writer.WriteMethodDeclaration(method))
                {
                    _writer.Line($"return null;");
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
