// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using NUnit.Framework;

namespace AutoRest.CSharp.LowLevel.Generation
{
    internal class ExampleCompileCheckWriter
    {
        private MethodSignature ExampleMethodSignature(string name) => new MethodSignature(
            $"Example_{name}",
            null,
            null,
            MethodSignatureModifiers.Public,
            null,
            null,
            Array.Empty<Parameter>(),
            Attributes: new CSharpAttribute[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), "Only validating compilation of examples") });

        private LowLevelClient _client;
        private CodeWriter _writer;

        public ExampleCompileCheckWriter(LowLevelClient client)
        {
            _client = client;
            _writer = new CodeWriter();
        }

        public void Write()
        {
            //TODO: Once the code snippet composer uses CodeWriter these won't be needed
            _writer.UseNamespace("Azure");
            _writer.UseNamespace("Azure.Core");
            _writer.UseNamespace("Azure.Identity");
            _writer.UseNamespace("System");
            _writer.UseNamespace("System.IO");
            _writer.UseNamespace("System.Text.Json");

            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    foreach (var method in _client.ClientMethods)
                    {
                        LowLevelExampleComposer exampleComposer = new LowLevelExampleComposer(_client);
                        StringBuilder builder = new StringBuilder();
                        exampleComposer.ComposeCodeSnippet(method, method.RequestMethod.Name, false, false, builder);
                        using (_writer.WriteMethodDeclaration(ExampleMethodSignature(method.RequestMethod.Name)))
                        {
                            _writer.AppendRaw(builder.ToString());
                        }
                        _writer.Line();
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
