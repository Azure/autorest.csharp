// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Tests;

namespace AutoRest.CSharp.LowLevel.Generation.Tests
{
    internal class DpgTestBaseWriter
    {
        private readonly DpgTestBaseProvider _testBase;
        private readonly CodeWriter _writer;
        public DpgTestBaseWriter(DpgTestBaseProvider dpgTestBase)
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
            foreach (var (client, method) in _testBase.CreateClientMethods)
            {
                _writer.Line();
                using (_writer.WriteMethodDeclaration(method))
                {
                    // instrumenting the client options
                    var clientOptionType = client.ClientOptions.Type;
                    _writer.Line($"var options = InstrumentClientOptions(new {clientOptionType}());");
                    _writer.Append($"var client = new {client.Type}(");
                    foreach (var parameter in method.Parameters)
                    {
                        _writer.Append($"{parameter.Name:I},");
                    }
                    _writer.Line($"options: options);");

                    _writer.Line($"return InstrumentClient(client);");
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
