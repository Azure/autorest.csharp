// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using NUnit.Framework;

namespace AutoRest.CSharp.LowLevel.Generation
{
    internal class ExampleCompileCheckWriter
    {
        private MethodSignature GetExampleMethodSignature(string name, bool isAsync) => new MethodSignature(
            name,
            null,
            null,
            isAsync ? MethodSignatureModifiers.Public | MethodSignatureModifiers.Async : MethodSignatureModifiers.Public,
            isAsync ? typeof(Task) : (CSharpType?)null,
            null,
            Array.Empty<Parameter>(),
            Attributes: new CSharpAttribute[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), "Only validating compilation of examples") });

        private LowLevelClient _client;
        private CodeWriter _writer;
        private LowLevelExampleComposer _exampleComposer;

        public ExampleCompileCheckWriter(LowLevelClient client)
        {
            _client = client;
            _writer = new CodeWriter();
            _exampleComposer = new LowLevelExampleComposer(_client);
        }

        public void Write()
        {
            //TODO: Once the code snippet composer uses CodeWriter these won't be needed
            _writer.UseNamespace("Azure");
            _writer.UseNamespace("Azure.Core");
            _writer.UseNamespace("Azure.Identity");
            _writer.UseNamespace("System");
            _writer.UseNamespace("System.Collections.Generic");
            _writer.UseNamespace("System.IO");
            _writer.UseNamespace("System.Text.Json");
            if (Configuration.ModelNamespace && _client.HasConvenienceMethods)
                _writer.UseNamespace($"{_client.Declaration.Namespace}.Models");

            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    foreach (var method in _client.ClientMethods)
                    {
                        //TODO: we should make this more obvious to determine if something is convenience only
                        if (method.ProtocolMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                            !method.ProtocolMethodSignature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))) &&
                            !_client.IsMethodSuppressed(method.ProtocolMethodSignature) &&
                            (_client.IsSubClient ? true : _client.GetEffectiveCtor() is not null))
                        {
                            bool writeShortVersion = ShouldGenerateShortVersion(method);

                            if (writeShortVersion)
                                WriteTestCompilation(method, false, false);
                            WriteTestCompilation(method, false, true);

                            if (writeShortVersion)
                                WriteTestCompilation(method, true, false);
                            WriteTestCompilation(method, true, true);

                        }

                        if (method.ConvenienceMethod is not null &&
                            !method.ConvenienceMethod.IsDeprecatedForExamples() &&
                            method.ConvenienceMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                            (_client.IsSubClient ? true : _client.GetEffectiveCtor() is not null) &&
                            !_client.IsMethodSuppressed(method.ConvenienceMethod.Signature))
                            WriteConvenienceTestCompilation(method.ConvenienceMethod, method.ConvenienceMethod.Signature.Name, true, false);
                    }
                }
            }
        }

        private void WriteConvenienceTestCompilation(ConvenienceMethod method, string methodName, bool isAsync, bool useAllParameters)
        {
            StringBuilder builder = new StringBuilder();
            var asyncKeyword = isAsync ? "Async" : "";
            _exampleComposer.ComposeConvenienceMethodExample(method, isAsync, false, $"{methodName}{asyncKeyword}", builder);
            var testMethodName = _exampleComposer.GetTestMethodName(methodName, useAllParameters, isAsync, true);
            using (_writer.WriteMethodDeclaration(GetExampleMethodSignature(testMethodName, isAsync)))
            {
                _writer.AppendRaw(builder.ToString());
            }
            _writer.Line();

        }

        private bool ShouldGenerateShortVersion(LowLevelClientMethod method)
        {
            if (method.ConvenienceMethod is not null)
            {
                if (method.ConvenienceMethod.Signature.Parameters.Count == method.ProtocolMethodSignature.Parameters.Count - 1 &&
                    !method.ConvenienceMethod.Signature.Parameters.Last().Type.Equals(typeof(CancellationToken)))
                {
                    bool allEqual = true;
                    for (int i = 0; i < method.ConvenienceMethod.Signature.Parameters.Count; i++)
                    {
                        if (!method.ConvenienceMethod.Signature.Parameters[i].Type.Equals(method.ProtocolMethodSignature.Parameters[i].Type))
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (allEqual)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (_client.HasMatchingCustomMethod(method))
                    return false;
            }

            return true;
        }

        private void WriteTestCompilation(LowLevelClientMethod method, bool isAsync, bool useAllParameters)
        {
            var testMethodName = _exampleComposer.GetTestMethodName(method.RequestMethod.Name, useAllParameters, isAsync, false);
            using (_writer.WriteMethodDeclaration(GetExampleMethodSignature(testMethodName, isAsync)))
            {
                _exampleComposer.ComposeCodeSnippet(_writer, method, GetMethodName(method.RequestMethod.Name, isAsync), isAsync, useAllParameters);
            }
            _writer.Line();
        }

        private string GetMethodName(string methodName, bool isAsync) => isAsync ? $"{methodName}Async" : methodName;

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
