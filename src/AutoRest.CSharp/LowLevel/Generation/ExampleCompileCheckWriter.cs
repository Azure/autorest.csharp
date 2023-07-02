// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Models;
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
        private MethodSignature ExampleMethodSignature(string name, bool isAsync) => new MethodSignature(
            $"Example_{name}",
            null,
            null,
            isAsync ? MethodSignatureModifiers.Public | MethodSignatureModifiers.Async : MethodSignatureModifiers.Public,
            isAsync ? typeof(Task) : (CSharpType?)null,
            null,
            Array.Empty<Parameter>(),
            Attributes: new CSharpAttribute[] { new(typeof(TestAttribute)), new(typeof(IgnoreAttribute), "Only validating compilation of examples") });

        private readonly LowLevelClient _client;
        private readonly CodeWriter _writer;
        private readonly LowLevelExampleComposer _exampleComposer;

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
            if (Configuration.ModelNamespace && _client.ClientMethods.Any(m => m.Convenience.Any()))
                _writer.UseNamespace($"{_client.Declaration.Namespace}.Models");

            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    foreach (var method in _client.ClientMethods)
                    {
                        //TODO: we should make this more obvious to determine if something is convenience only
                        if (method.Protocol.Any())
                        {
                            var signature = (MethodSignature)method.Protocol[0].Signature;

                            if (signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                                !signature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))) &&
                                (_client.IsSubClient || _client.GetEffectiveCtor() is not null) &&
                                _client.IsMethodSuppressed(signature))
                            {

                                if (ShouldGenerateShortVersion(method))
                                {
                                    WriteProtocolTestCompilation(method, signature.WithAsync(false), false, false);
                                }
                                WriteProtocolTestCompilation(method, signature.WithAsync(false), false, true);

                                if (ShouldGenerateShortVersion(method))
                                {
                                    WriteProtocolTestCompilation(method, signature.WithAsync(true), true, false);
                                }
                                WriteProtocolTestCompilation(method, signature.WithAsync(true), true, true);
                            }
                        }

                        if (method.Convenience.Any())
                        {
                            var convenience = method.Convenience[0];
                            if (convenience.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                                (_client.IsSubClient || _client.GetEffectiveCtor() is not null) &&
                                _client.IsMethodSuppressed(convenience.Signature))
                            {
                                WriteConvenienceTestCompilation(method, (MethodSignature)convenience.Signature, true, false);
                            }
                        }
                    }
                }
            }
        }

        private void WriteConvenienceTestCompilation(LowLevelClientMethod clientMethod, MethodSignature signature, bool isAsync, bool useAllParameters)
        {
            var builder = new StringBuilder();
            _exampleComposer.ComposeConvenienceMethodExample(clientMethod, signature, isAsync, false, builder);
            var testMethodName = signature.Name;
            if (useAllParameters)
            {
                testMethodName += "_AllParameters";
            }
            testMethodName += "_Convenience";
            if (isAsync)
            {
                testMethodName += "_Async";
            }
            using (_writer.WriteMethodDeclaration(ExampleMethodSignature(testMethodName, isAsync)))
            {
                _writer.AppendRaw(builder.ToString());
            }
            _writer.Line();

        }

        private bool ShouldGenerateShortVersion(LowLevelClientMethod method)
        {
            if (method.Convenience.Any())
            {
                if (method.Convenience[0].Signature.Parameters.Count == method.Protocol[0].Signature.Parameters.Count - 1 &&
                    !method.Convenience[0].Signature.Parameters.Last().Type.Equals(typeof(CancellationToken)))
                {
                    bool allEqual = true;
                    for (int i = 0; i < method.Convenience[0].Signature.Parameters.Count; i++)
                    {
                        if (!method.Convenience[0].Signature.Parameters[i].Type.Equals(method.Protocol[0].Signature.Parameters[i].Type))
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

            return true;
        }

        private void WriteProtocolTestCompilation(LowLevelClientMethod method, MethodSignature signature, bool isAsync, bool useAllParameters)
        {
            var builder = new StringBuilder();
            _exampleComposer.ComposeProtocolCodeSnippet(method, signature, isAsync, useAllParameters, builder);
            var methodName = signature.Name;
            if (useAllParameters)
            {
                methodName += "_AllParameters";
            }
            if (isAsync)
            {
                methodName += "_Async";
            }
            using (_writer.WriteMethodDeclaration(ExampleMethodSignature(methodName, isAsync)))
            {
                _writer.AppendRaw(builder.ToString());
            }
            _writer.Line();
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
