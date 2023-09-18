// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
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

        public ExampleCompileCheckWriter(LowLevelClient client, LowLevelExampleComposer exampleComposer)
        {
            _client = client;
            _writer = new CodeWriter();
            _exampleComposer = exampleComposer;
        }

        public void Write()
        {
            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                    {
                        return;
                    }

                    foreach (var method in _client.OperationMethods.OrderBy(o => o.Order))
                    {
                        if (ShouldGenerateShortVersion(method))
                        {
                            WriteProtocolTestCompilation(method, false);
                            WriteConvenienceTestCompilation(method, false);
                        }

                        WriteProtocolTestCompilation(method, true);
                        WriteConvenienceTestCompilation(method, true);
                    }
                }
            }
        }

        private void WriteProtocolTestCompilation(RestClientOperationMethods method, bool useAllParameters)
        {
            if (method.Protocol is {Signature: MethodSignature signature} protocol && ShouldGenerateProtocol(protocol))
            {
                WriteProtocolTestCompilation(method, signature, false, useAllParameters);
            }

            if (method.ProtocolAsync is {Signature: MethodSignature signatureAsync} protocolAsync && ShouldGenerateProtocol(protocolAsync))
            {
                WriteProtocolTestCompilation(method, signatureAsync, true, useAllParameters);
            }
        }

        private void WriteConvenienceTestCompilation(RestClientOperationMethods method, bool useAllParameters)
        {
            if (method.Convenience is { Signature: MethodSignature signature } convenience && ShouldGenerateSample(convenience))
            {
                WriteConvenienceTestCompilation(signature, false, useAllParameters);
            }

            if (method.ConvenienceAsync is { Signature: MethodSignature signatureAsync } convenienceAsync && ShouldGenerateSample(convenienceAsync))
            {
                WriteConvenienceTestCompilation(signatureAsync, true, useAllParameters);
            }
        }

        private bool ShouldGenerateProtocol(Method protocolMethod)
            => ShouldGenerateSample(protocolMethod) && !protocolMethod.Signature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute)));

        private bool ShouldGenerateSample(Method method)
            => method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !_client.IsMethodSuppressed(method.Signature);

        private void WriteConvenienceTestCompilation(MethodSignature signature, bool isAsync, bool useAllParameters)
        {
            var methodBody = _exampleComposer.ComposeConvenienceMethodExample(signature, isAsync);
            var testMethodName = signature.WithAsync(false).Name;
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
                _writer.WriteMethodBodyStatement(methodBody);
            }
            _writer.Line();

        }

        private static bool ShouldGenerateShortVersion(RestClientOperationMethods method)
        {
            if (method is not { Convenience: { } convenience, Protocol: { } protocol })
            {
                return true;
            }

            if (convenience.Signature.Parameters.Count == protocol.Signature.Parameters.Count - 1 &&
                !convenience.Signature.Parameters.Last().Type.Equals(typeof(CancellationToken)))
            {
                bool allEqual = true;
                for (int i = 0; i < method.Convenience.Signature.Parameters.Count; i++)
                {
                    if (!method.Convenience.Signature.Parameters[i].Type.Equals(protocol.Signature.Parameters[i].Type))
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

            return true;
        }

        private void WriteProtocolTestCompilation(RestClientOperationMethods method, MethodSignature signature, bool isAsync, bool useAllParameters)
        {
            var methodBody =_exampleComposer.ComposeProtocolCodeSnippet(method, signature, useAllParameters, isAsync).AsStatement();
            var methodName = signature.WithAsync(false).Name;
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
                _writer.WriteMethodBodyStatement(methodBody);
            }
            _writer.Line();
        }

        public override string ToString()
        {
            return SamplesFormattingSyntaxRewriter.FormatFile(_writer.ToString());
        }
    }
}
