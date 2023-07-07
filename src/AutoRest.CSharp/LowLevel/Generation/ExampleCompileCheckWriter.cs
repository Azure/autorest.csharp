﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Generation.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace AutoRest.CSharp.LowLevel.Generation
{
    internal class ExampleCompileCheckWriter
    {
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;

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
        private readonly IEnumerable<DpgOperationSample> _operationSamples;

        public ExampleCompileCheckWriter(LowLevelClient client, IEnumerable<DpgOperationSample> operationSamples)
        {
            _client = client;
            _writer = new CodeWriter();
            _exampleComposer = new LowLevelExampleComposer(_client);
            _operationSamples = operationSamples;
        }

        public void Write()
        {
            ////TODO: Once the code snippet composer uses CodeWriter these won't be needed
            //_writer.UseNamespace("Azure");
            //_writer.UseNamespace("Azure.Core");
            //_writer.UseNamespace("Azure.Identity");
            //_writer.UseNamespace("System");
            //_writer.UseNamespace("System.Collections.Generic");
            //_writer.UseNamespace("System.IO");
            //_writer.UseNamespace("System.Text.Json");
            //if (Configuration.ModelNamespace && _client.HasConvenienceMethods)
            //    _writer.UseNamespace($"{_client.Declaration.Namespace}.Models");

            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    foreach (var sample in _operationSamples)
                    {
                        var method = sample.Method;
                        if (method.ProtocolMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                            !method.ProtocolMethodSignature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))) &&
                            !_client.IsMethodSuppressed(method.ProtocolMethodSignature) &&
                            (_client.IsSubClient ? true : _client.GetEffectiveCtor() is not null))
                        {
                            bool writeShortVersion = ShouldGenerateShortVersion(method);

                            WriteTestMethod(sample, writeShortVersion, false);
                            WriteTestMethod(sample, writeShortVersion, true);
                        }
                    }
#if false
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

                        //if (method.ConvenienceMethod is not null &&
                        //    !method.ConvenienceMethod.IsDeprecatedForExamples() &&
                        //    method.ConvenienceMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        //    (_client.IsSubClient ? true : _client.GetEffectiveCtor() is not null) &&
                        //    !_client.IsMethodSuppressed(method.ConvenienceMethod.Signature))
                        //    WriteConvenienceTestCompilation(method.ConvenienceMethod, method.ConvenienceMethod.Signature.Name, true, false);
                    }
#endif
                }
            }
        }

        // TODO -- maybe change this DpgOperationSample to DpgProtocolMethodSample
        private void WriteTestMethod(DpgOperationSample sample, bool useAllParameters, bool isAsync)
        {
            using (_writer.WriteMethodDeclaration(sample.GetExampleMethodSignature(true, isAsync)))
            {
                var clientVar = WriteGetClient(sample);

                var response = WriteSampleOperation(sample, sample.Method.ProtocolMethodSignature.WithAsync(isAsync), clientVar, useAllParameters, isAsync);
            }

            _writer.Line();
        }

        private CodeWriterDeclaration WriteGetClient(DpgOperationSample sample)
        {
            var clientConstructor = sample.ClientInvocationChain.First();
            // handle authentication related parameters
            var parameterDeclarations = WriteOperationInvocationParameters(sample, clientConstructor.Parameters);

            var clientVar = new CodeWriterDeclaration("client");
            _writer.Append($"{sample.Client.Type} {clientVar:D} = ");
            foreach (var method in sample.ClientInvocationChain)
            {
                WriteOperationInvocation(parameterDeclarations, sample, method);
                _writer.AppendRaw(".");
            }
            _writer.RemoveTrailingCharacter();
            _writer.LineRaw(";");

            _writer.Line();

            return clientVar;
        }

        private CodeWriterDeclaration? WriteSampleOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool useAllParameters, bool isAsync) => (sample.Method.LongRunning, sample.Method.PagingInfo) switch
        {
            (not null, not null) => WriteSampleLongRunningPageableOperation(sample, methodSignature, clientVar, useAllParameters, isAsync),
            (not null, null) => WriteSampleLongRunningOperation(sample, methodSignature, clientVar, useAllParameters, isAsync),
            (null, not null) => WriteSamplePageableOperation(sample, methodSignature, clientVar, useAllParameters, isAsync),
            (null, null) => WriteSampleNormalOperation(sample, methodSignature, clientVar, useAllParameters, isAsync),
        };

        private CodeWriterDeclaration? WriteSampleLongRunningPageableOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool useAllParameters, bool isAsync)
        {
            // write the lro invocation
            var operation = WriteSampleLongRunningOperation(sample, methodSignature, clientVar, useAllParameters, isAsync);

            // write the paging invocation
            // TODO -- this might be incorrect, to be verified
            var itemType = GetItemType(methodSignature.ReturnType);
            var item = new CodeWriterDeclaration("item");
            _writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} {item:D} in {operation}.Value)");
            using (_writer.Scope())
            {
                // TODO -- handle response
            }

            return null;
        }

        private CodeWriterDeclaration? WriteSampleLongRunningOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool useAllParameters, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var returnType = GetReturnType(methodSignature.ReturnType);
            var operation = new CodeWriterDeclaration("operation");

            _writer.Append($"{returnType} {operation:D} = ")
                .AppendRawIf("await ", isAsync)
                .Append($"{clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(";");

            // TODO -- handle response

            return operation;
        }

        private CodeWriterDeclaration? WriteSamplePageableOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool useAllParameters, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var itemType = GetItemType(methodSignature.ReturnType);
            var item = new CodeWriterDeclaration("item");
            _writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} {item:D} in {clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(")");

            using (_writer.Scope())
            {
                // TODO -- handle response
            }

            return null;
        }

        private CodeWriterDeclaration? WriteSampleNormalOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool useAllParameters, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var returnType = GetReturnType(methodSignature.ReturnType);
            var response = new CodeWriterDeclaration("response");

            _writer.Append($"{returnType} {response:D} = ")
                .AppendRawIf("await ", isAsync)
                .Append($"{clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(";");

            // TODO -- handle response

            return response;
        }

        private Dictionary<Parameter, CodeWriterDeclaration> WriteOperationInvocationParameters(DpgOperationSample sample, IEnumerable<Parameter> parameters)
        {
            var result = new Dictionary<Parameter, CodeWriterDeclaration>();
            foreach (var parameter in parameters)
            {
                // some parameters are always inline
                if (sample.IsInlineParameter(parameter))
                    continue;

                if (sample.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    var declaration = new CodeWriterDeclaration(parameter.Name);
                    _writer.Append($"{parameter.Type} {declaration:D} = ")
                        .AppendExampleParameterValue(parameterValue).LineRaw(";");
                    result.Add(parameter, declaration);
                }
            }

            return result;
        }

        private void WriteOperationInvocation(Dictionary<Parameter, CodeWriterDeclaration> parameters, DpgOperationSample sample, MethodSignatureBase methodSignature)
        {
            _writer.AppendRawIf("new ", methodSignature is ConstructorSignature)
                .Append($"{methodSignature.Name}(");
            // write parameters
            foreach (var parameter in methodSignature.Parameters)
            {
                if (sample.IsInlineParameter(parameter))
                {
                    // this is inline parameter, we just append its value here
                    if (sample.ParameterValueMapping.TryGetValue(parameter.Name, out var exampleValue))
                    {
                        _writer.AppendExampleParameterValue(parameter, exampleValue).AppendRaw(",");
                    }
                    continue;
                }
                else if (parameters.TryGetValue(parameter, out var declaration))
                {
                    _writer.AppendIf($"{parameter.Name}: ", parameter.DefaultValue != null)
                        .Append($"{declaration:I}")
                        .AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")");
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

        private static CSharpType GetReturnType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            if (returnType.IsFrameworkType && returnType.FrameworkType.Equals(typeof(Task<>)))
            {
                return returnType.Arguments.Single();
            }

            return returnType;
        }

        private static CSharpType GetOperationValueType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            Debug.Assert(TypeFactory.IsOperationOfT(returnType));

            return returnType.Arguments.Single();
        }

        private static CSharpType GetItemType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            Debug.Assert(TypeFactory.IsPageable(returnType) || TypeFactory.IsAsyncPageable(returnType));

            return returnType.Arguments.Single();
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
