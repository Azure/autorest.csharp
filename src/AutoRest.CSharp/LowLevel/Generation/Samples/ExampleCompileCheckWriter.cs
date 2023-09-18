// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Generation.Extensions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;

namespace AutoRest.CSharp.LowLevel.Generation.Samples
{
    internal class ExampleCompileCheckWriter
    {
        private readonly LowLevelClient _client;
        private readonly CodeWriter _writer;

        public ExampleCompileCheckWriter(LowLevelClient client)
        {
            _client = client;
            _writer = new CodeWriter();
        }

        public void Write()
        {
            // since our generator source code does not have the Azure.Identity dependency, we have to add this dependency separately
            _writer.UseNamespace("Azure.Identity");

            using (_writer.Namespace($"{_client.Declaration.Namespace}.Samples"))
            {
                using (_writer.Scope($"public class Samples_{_client.Declaration.Name}"))
                {
                    foreach (var method in _client.ClientMethods)
                    {
                        foreach (var sample in method.Samples)
                        {
                            WriteTestMethod(sample, false);
                            WriteTestMethod(sample, true);
                        }
                    }
                }
            }
        }

        private void WriteTestMethod(DpgOperationSample sample, bool isAsync)
        {
            using (_writer.WriteMethodDeclaration(sample.GetExampleMethodSignature(isAsync)))
            {
                var clientVar = WriteGetClient(sample);

                WriteSampleOperation(sample, sample.OperationMethodSignature.WithAsync(isAsync), clientVar, isAsync);
            }
            _writer.Line();
        }

        private CodeWriterDeclaration WriteGetClient(DpgOperationSample sample)
        {
            var clientCtor = sample.ClientInvocationChain.First();
            // handle authentication related parameters
            var parameterDeclarations = WriteOperationInvocationParameters(sample, clientCtor.Parameters);

            var clientVar = new CodeWriterDeclaration("client");
            _writer.Append($"{sample.Client.Type} {clientVar:D} = ");
            foreach (var method in sample.ClientInvocationChain)
            {
                WriteOperationInvocation(parameterDeclarations, sample, method);
                _writer.AppendRaw(".");
            }
            _writer.RemoveTrailingCharacter(); // this removes the last dot `.`
            _writer.LineRaw(";");

            _writer.Line();

            return clientVar;
        }

        private void WriteSampleOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            switch (sample.IsLongRunning, sample.IsPageable)
            {
                case (true, true):
                    WriteSampleLongRunningPageableOperationWithResponse(sample, methodSignature, clientVar, isAsync);
                    break;
                case (true, false):
                    WriteSampleLongRunningOperationWithResponse(sample, methodSignature, clientVar, isAsync);
                    break;
                case (false, true):
                    WriteSamplePageableOperationWithResponse(sample, methodSignature, clientVar, isAsync);
                    break;
                case (false, false):
                    WriteSampleNormalOperationWithResponse(sample, methodSignature, clientVar, isAsync);
                    break;
            };
        }

        private void WriteSampleLongRunningPageableOperationWithResponse(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            // write the lro invocation
            var operation = WriteSampleLongRunningOperation(sample, methodSignature, clientVar, isAsync);

            // write the paging invocation
            var itemType = GetLongRunningPageableItemType(methodSignature.ReturnType);
            var item = new CodeWriterDeclaration("item");
            _writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} {item:D} in {operation}.Value)");
            using (_writer.Scope())
            {
                WriteNormalOperationResponse(sample, $"{item}", $"{item}.ToStream()");
            }
        }

        private CodeWriterDeclaration WriteSampleLongRunningOperation(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var returnType = GetReturnType(methodSignature.ReturnType);
            var operation = new CodeWriterDeclaration("operation");

            _writer.Append($"{returnType} {operation:D} = ")
                .AppendRawIf("await ", isAsync)
                .Append($"{clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(";");

            return operation;
        }

        private void WriteSampleLongRunningOperationWithResponse(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            var operation = WriteSampleLongRunningOperation(sample, methodSignature, clientVar, isAsync);

            if (sample.HasResponseBody)
            {
                var responseData = new CodeWriterDeclaration("responseData");
                var typeOfResult = GetReturnType(methodSignature.ReturnType).Arguments.Single();
                _writer.Line($"{typeOfResult} {responseData:D} = {operation}.Value;");
                WriteNormalOperationResponse(sample, $"{responseData}", $"{responseData}.ToStream()");
            }
        }

        private void WriteSamplePageableOperationWithResponse(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var itemType = GetPageableItemType(methodSignature.ReturnType);
            var item = new CodeWriterDeclaration("item");
            _writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} {item:D} in {clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(")");

            using (_writer.Scope())
            {
                WriteNormalOperationResponse(sample, $"{item}", $"{item}.ToStream()");
            }
        }

        private void WriteSampleNormalOperationWithResponse(DpgOperationSample sample, MethodSignature methodSignature, CodeWriterDeclaration clientVar, bool isAsync)
        {
            var parameters = WriteOperationInvocationParameters(sample, methodSignature.Parameters);

            var returnType = GetReturnType(methodSignature.ReturnType);
            var response = new CodeWriterDeclaration("response");

            _writer.Append($"{returnType} {response:D} = ")
                .AppendRawIf("await ", isAsync)
                .Append($"{clientVar}.");
            WriteOperationInvocation(parameters, sample, methodSignature);
            _writer.LineRaw(";");

            if (sample.HasResponseBody)
                WriteNormalOperationResponse(sample, $"{response}", $"{response}.ContentStream");
            else
            {
                if (returnType.EqualsIgnoreNullable(typeof(Azure.Response)))
                {
                    _writer.ConsoleWriteLine($"{response}.Status");
                }
                else
                {
                    _writer.ConsoleWriteLine($"{response}.GetRawResponse().Status");
                }
            }
        }

        private void WriteNormalOperationResponse(DpgOperationSample sample, FormattableString resultVar, FormattableString jsonVar)
        {
            if (sample.IsResponseStream)
                WriteStreamResponse(resultVar);
            else
            {
                WriteOtherResponse(sample, resultVar, jsonVar);
            }
        }

        private void WriteStreamResponse(FormattableString resultVar)
        {
            using (_writer.Scope($"if ({resultVar}.ContentStream != null)"))
            {
                using (_writer.Scope($"using({typeof(Stream)} outFileStream = {typeof(File)}.{nameof(File.OpenWrite)}({"<filepath>":L}))"))
                {
                    _writer.Line($"{resultVar}.ContentStream.CopyTo(outFileStream);");
                }
            }
        }

        private void WriteOtherResponse(DpgOperationSample sample, FormattableString resultVar, FormattableString jsonVar)
        {
            // we do not write response handling for convenience methods
            if (sample.IsConvenienceSample)
                return;

            var result = new CodeWriterDeclaration("result");
            var apiInvocationChainList = sample.ComposeResponseParsingCode($"{result}");

            _writer.Line();
            if (apiInvocationChainList.Any())
            {
                _writer.Line($"{typeof(JsonElement)} {result:D} = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}({jsonVar}).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    _writer.ConsoleWriteLine($"{apiInvocationChain.ToList().Join(".")}.ToString()");
                }
            }
            else
            {
                _writer.ConsoleWriteLine($"{resultVar}.ToString()");
            }
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
                        .AppendInputExampleParameterValue(parameterValue, parameter.SerializationFormat).LineRaw(";");
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
                        _writer.AppendInputExampleParameterValue(parameter, exampleValue).AppendRaw(",");
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

        private static CSharpType GetLongRunningPageableItemType(CSharpType? returnType)
        {
            var unwrapOperation = GetOperationValueType(returnType);

            return GetPageableItemType(unwrapOperation);
        }

        private static CSharpType GetOperationValueType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            returnType = GetReturnType(returnType);

            Debug.Assert(TypeFactory.IsOperationOfT(returnType));

            return returnType.Arguments.Single();
        }

        private static CSharpType GetPageableItemType(CSharpType? returnType)
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
