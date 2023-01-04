﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Samples;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.MgmtTest.Generation.Samples
{
    internal class MgmtSampleWriter : MgmtTestWriterBase<MgmtSampleProvider>
    {
        public MgmtSampleWriter(MgmtSampleProvider sample) : base(sample)
        {
        }

        public override void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteImplementation();
                }
            }
        }

        private void WriteImplementation()
        {
            foreach (var sample in This.Samples)
            {
                WriteSample(sample);
                _writer.Line();
            }
        }

        private readonly Dictionary<string, int> _sampleMethods = new();

        private void WriteSample(Sample sample)
        {
            var signature = sample.GetMethodSignature(false);
            if (_sampleMethods.TryGetValue(signature.Name, out var count))
            {
                _sampleMethods[signature.Name]++;
                signature = signature with
                {
                    Name = $"{signature.Name}{count}", // we never care the name of the method that is enclosing the sample implementation. Our sample fetching pipeline only takes the content.
                };
            }
            else
            {
                _sampleMethods.Add(signature.Name, 1);
            }

            // write the attributes
            _writer.Line($"// {sample.Name}");
            _writer.Line($"[NUnit.Framework.Test]");
            _writer.Line($"[NUnit.Framework.Ignore(\"Only verifying that the sample builds\")]");
            using (_writer.WriteMethodDeclaration(signature))
            {
                WriteSampleSteps(sample);
            }
        }

        private void WriteSampleSteps(Sample sample)
        {
            // Write sample source file
            _writer.Line($"// Generated from example definition: {sample.OriginalFilepath}");
            // Write claimers
            _writer.Line($"// this example is just showing the usage of \"{sample.OperationId}\" operation, for the dependent resources, they will have to be created separately.");
            _writer.Line();

            // Write the ArmClient and authentication
            var clientStepResult = WriteGetArmClient();

            // Write the operation invocation
            var result = sample.Carrier switch
            {
                ResourceCollection collection => WriteSampleOperationForResourceCollection(clientStepResult, collection, sample),
                Resource resource => WriteSampleOperationForResource(clientStepResult, resource, sample),
                MgmtExtensions extension => WriteSampleOperationForExtension(clientStepResult, extension, sample),
                _ => throw new InvalidOperationException("Should never happen"),
            };

            // Write the result handling
            WriteResultHandling(result);
        }

        private void WriteResultHandling(CodeWriterVariableDeclaration? result, bool newLine = true)
        {
            if (newLine)
                _writer.Line();

            if (result == null)
            {
                _writer.Line($"{typeof(Console)}.WriteLine($\"Succeeded\");");
            }
            else if (result.Type.TryCastResource(out var resource))
            {
                WriteResourceResultHandling(result, resource);
            }
            else if (result.Type.TryCastResourceData(out var resourceData))
            {
                WriteResourceDataResultHandling(result, resourceData);
            }
            else
            {
                WriteOtherResultHandling(result);
            }
        }

        private void WriteResourceResultHandling(CodeWriterVariableDeclaration result, Resource resource)
        {
            // create a data variable for this data
            _writer.Line($"// the variable {result.Declaration} is a resource, you could call other operations on this instance as well");
            _writer.Line($"// but just for demo, we get its data from this resource instance");
            var dataResult = new CodeWriterVariableDeclaration("resourceData", resource.ResourceData.Type);
            _writer.AppendDeclaration(dataResult)
                .Line($" = {result.Declaration}.Data;");

            // handle the data
            WriteResourceDataResultHandling(dataResult, resource.ResourceData);
        }

        private void WriteResourceDataResultHandling(CodeWriterVariableDeclaration result, ResourceData resourceData)
        {
            _writer.Line($"// for demo we just print out the id");
            _writer.Line($"{typeof(Console)}.WriteLine($\"Succeeded on id: {{{result.Declaration}.Id}}\");");
        }

        private void WriteOtherResultHandling(CodeWriterVariableDeclaration result)
        {
            if (result.Type.IsFrameworkType)
            {
                _writer.Line($"{typeof(Console)}.WriteLine($\"Succeeded: {{{result.Declaration}}}\");");
            }
            else
            {
                _writer.Line($"{typeof(Console)}.WriteLine($\"Succeeded: {{{result.Declaration}}}\");");
            }
        }

        private CodeWriterVariableDeclaration WriteGetArmClient()
        {
            _writer.LineRaw("// get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line");
            var cred = new CodeWriterVariableDeclaration("cred", typeof(TokenCredential));
            _writer.UseNamespace("Azure.Identity");
            _writer.AppendDeclaration(cred)
                .Line($" = new DefaultAzureCredential();");
            _writer.Line($"// authenticate your client");
            var clientResult = new CodeWriterVariableDeclaration("client", typeof(ArmClient));
            _writer.AppendDeclaration(clientResult)
                .Line($" = new {typeof(ArmClient)}({cred.Declaration});");

            return clientResult;
        }

        private string GetResourceName(MgmtTypeProvider provider) => provider switch
        {
            Resource resource => resource.Type.Name,
            MgmtExtensions extension => extension.ArmCoreType.Name,
            _ => throw new InvalidOperationException("Should never happen")
        };

        private CodeWriterVariableDeclaration? WriteSampleOperationForResourceCollection(CodeWriterVariableDeclaration clientResult, ResourceCollection collection, Sample sample)
        {
            _writer.Line();

            var collectionResult = WriteGetCollection(clientResult, collection, sample);
            var result = WriteSampleOperation(collectionResult, sample);

            return result;
        }

        private CodeWriterVariableDeclaration? WriteSampleOperationForResource(CodeWriterVariableDeclaration clientVar, Resource resource, Sample sample)
        {
            _writer.Line();

            var resourceName = GetResourceName(resource);
            _writer.Line($"// this example assumes you already have this {resourceName} created on azure");
            _writer.Line($"// for more information of creating {resourceName}, please refer to the document of {resourceName}");
            var resourceResult = WriteGetResource(resource, sample, $"{clientVar.Declaration}");
            var result = WriteSampleOperation(new CodeWriterVariableDeclaration(resourceResult, resource.Type), sample);

            return result;
        }

        private CodeWriterVariableDeclaration? WriteSampleOperationForExtension(CodeWriterVariableDeclaration clientVar, MgmtExtensions extension, Sample sample)
        {
            _writer.Line();

            var resourceName = GetResourceName(extension);
            _writer.Line($"// this example assumes you already have this {resourceName} created on azure");
            _writer.Line($"// for more information of creating {resourceName}, please refer to the document of {resourceName}");
            var resourceResult = WriteGetExtension(extension, sample, $"{clientVar.Declaration}");
            var result = WriteSampleOperation(new CodeWriterVariableDeclaration(resourceResult, extension.ArmCoreType), sample);

            return result;
        }

        private CodeWriterDeclaration? WriteGetParentResource(MgmtTypeProvider parent, MockTestCase testCase, FormattableString clientExpression)
        {
            if (parent is MgmtExtensions extension && extension.ArmCoreType == typeof(ArmResource))
                return null;

            return WriteGetResource(parent, testCase, clientExpression);
        }

        private CodeWriterVariableDeclaration WriteGetCollection(CodeWriterVariableDeclaration clientResult, ResourceCollection collection, Sample sample)
        {
            var parent = sample.Parent;
            Debug.Assert(parent != null);

            var parentName = GetResourceName(parent);
            _writer.Line($"// this example assumes you already have this {parentName} created on azure");
            _writer.Line($"// for more information of creating {parentName}, please refer to the document of {parentName}");
            var parentVar = WriteGetParentResource(parent, sample, $"{clientResult.Declaration}");

            var resourceName = collection.Resource.ResourceName;
            // now we have the parent resource, get the collection from that resource
            // TODO -- we might should look this up inside the code project for correct method name
            var getResourceCollectionMethodName = $"Get{resourceName.ResourceNameToPlural()}";
            var collectionResult = new CodeWriterVariableDeclaration("collection", collection.Type);

            _writer.Line();
            _writer.Line($"// get the collection of this {collection.Resource.Type.Name}");

            var idVar = new CodeWriterDeclaration("scopeId");
            if (parentVar == null)
            {
                // this case will happen only when the resource is a scope resource
                WriteCreateScopeResourceIdentifier(sample, idVar, sample.RequestPath.GetScopePath());
            }
            // first find the variables we need and write their assignments
            var parameters = new Dictionary<Parameter, CodeWriterVariableDeclaration>();
            foreach (var extraParameter in collection.ExtraConstructorParameters)
            {
                if (sample.ParameterValueMapping.TryGetValue(extraParameter.Name, out var value))
                {
                    var declaration = new CodeWriterVariableDeclaration(extraParameter.Name, extraParameter.Type);
                    parameters.Add(extraParameter, declaration);

                    _writer.AppendDeclaration(declaration)
                        .AppendRaw(" = ")
                        .AppendExampleParameterValue(value)
                        .LineRaw(";");
                }
            }
            _writer.AppendDeclaration(collectionResult).AppendRaw(" = ");
            if (parentVar == null)
            {
                _writer.Append($"{clientResult.Declaration}.{getResourceCollectionMethodName}({idVar}, ");
            }
            else
            {
                _writer.Append($"{parentVar}.{getResourceCollectionMethodName}(");
            }

            var parameterValues = sample.ParameterValueMapping;
            // iterate over the parameter list and put them into the invocation
            foreach ((var parameter, var declaration) in parameters)
            {
                _writer.AppendIf($"{parameter.Name}: ", parameter.DefaultValue != null)
                    .Append($"{declaration.Declaration}")
                    .AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");

            _writer.Line();

            return collectionResult;
        }

        private CodeWriterVariableDeclaration? WriteSampleOperation(CodeWriterVariableDeclaration collectionResult, Sample sample)
        {
            if (sample.IsLro)
            {
                return WriteSampleLroOperation(collectionResult.Declaration, sample);
            }
            else if (sample.IsPageable)
            {
                return WriteSamplePageableOperation(collectionResult.Declaration, sample);
            }

            return WriteSampleNormalOperation(collectionResult.Declaration, sample);
        }

        private CodeWriterVariableDeclaration? WriteSampleLroOperation(CodeWriterDeclaration instanceVar, Sample sample)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation");
            // if the Lro is an ArmOperation<T>
            var parameters = WriteOperationInvocationParameters(sample);
            var lroType = sample.Operation.ReturnType;
            if (lroType.IsGenericType)
            {
                var lroResult = new CodeWriterVariableDeclaration("lro", sample.Operation.ReturnType);
                _writer.AppendDeclaration(lroResult).AppendRaw(" = ");
                // write the method invocation
                WriteOperationInvocation(instanceVar, parameters, sample);
                var valueResult = new CodeWriterVariableDeclaration("result", lroType.Arguments.First());
                _writer.AppendDeclaration(valueResult)
                    .Line($"= {lroResult.Declaration}.Value;");

                return valueResult;
            }
            else
            {
                // if the Lro is an ArmOperation without body, we just write the method invocation without assignment
                WriteOperationInvocation(instanceVar, parameters, sample);
                return null;
            }
        }

        private CodeWriterVariableDeclaration? WriteSampleNormalOperation(CodeWriterDeclaration instanceVar, Sample sample)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation");
            var parameters = WriteOperationInvocationParameters(sample);
            var returnType = sample.Operation.ReturnType;
            if (returnType.IsGenericType)
            {
                // an operation with a response
                var valueResult = new CodeWriterVariableDeclaration("result", returnType.Arguments.First());
                _writer.AppendDeclaration(valueResult).AppendRaw(" = ");
                // write the method invocation
                WriteOperationInvocation(instanceVar, parameters, sample);
                return valueResult;
            }
            else
            {
                // an operation without a response
                WriteOperationInvocation(instanceVar, parameters, sample);
                return null;
            }
        }

        private CodeWriterVariableDeclaration? WriteSamplePageableOperation(CodeWriterDeclaration instanceVar, Sample sample)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation and iterate over the result");
            var parameters = WriteOperationInvocationParameters(sample);
            // when the operation is pageable, the return type refers to the type of the item T, instead of Pageable<T>
            var itemResult = new CodeWriterVariableDeclaration("item", sample.Operation.ReturnType);
            _writer.Append($"await foreach (")
                .AppendDeclaration(itemResult)
                .AppendRaw(" in ");

            WriteOperationInvocation(instanceVar, parameters, sample, isEndOfLine: false);
            using (_writer.Scope($")"))
            {
                WriteResultHandling(itemResult, newLine: false);
            }

            // an invocation of a pageable operation does not return a result
            return null;
        }

        private Dictionary<string, CodeWriterVariableDeclaration> WriteOperationInvocationParameters(Sample sample)
        {
            var result = new Dictionary<string, CodeWriterVariableDeclaration>();
            foreach (var parameter in sample.Operation.MethodParameters)
            {
                // some parameters are always inline
                if (IsInlineParameter(parameter))
                    continue;

                if (sample.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    var declaration = new CodeWriterVariableDeclaration(parameter.Name, parameter.Type);
                    _writer.AppendDeclaration(declaration).AppendRaw(" = ")
                        .AppendExampleParameterValue(parameterValue).LineRaw(";");
                    result.Add(parameter.Name, declaration);
                }
            }

            return result;
        }

        private static readonly HashSet<Parameter> InlineParameters = new() { KnownParameters.WaitForCompletion, KnownParameters.CancellationTokenParameter };

        private static bool IsInlineParameter(Parameter parameter)
            => InlineParameters.Contains(parameter);

        private void WriteOperationInvocation(CodeWriterDeclaration instanceVar, Dictionary<string, CodeWriterVariableDeclaration> parameters, Sample sample, bool isEndOfLine = true, bool isAsync = true)
        {
            var methodName = CreateMethodName(sample.Operation.Name);
            _writer.AppendIf($"await ", isAsync && !sample.Operation.IsPagingOperation) // paging operation never needs this await
                .Append($"{instanceVar}.{methodName}(");
            foreach (var parameter in sample.Operation.MethodParameters)
            {
                if (IsInlineParameter(parameter))
                {
                    if (sample.ParameterValueMapping.TryGetValue(parameter.Name, out var value))
                    {
                        _writer.AppendExampleParameterValue(parameter, value).AppendRaw(",");
                    }
                    continue;
                }
                if (parameters.TryGetValue(parameter.Name, out var declaration))
                {
                    _writer.AppendIf($"{parameter.Name}: ", parameter.DefaultValue != null)
                        .Append($"{declaration.Declaration}")
                        .AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")").LineRawIf(";", isEndOfLine);
        }

        protected override void WriteCreateResourceIdentifier(OperationExample example, CodeWriterDeclaration idDeclaration, RequestPath requestPath, CSharpType resourceType)
        {
            var parameters = new List<CodeWriterVariableDeclaration>();
            foreach (var value in example.ComposeResourceIdentifierExpressionValues(requestPath))
            {
                var declaration = new CodeWriterVariableDeclaration(value.Name, value.Type);
                if (value.Value is not null)
                {
                    _writer.AppendDeclaration(declaration)
                        .AppendRaw(" = ").AppendExampleParameterValue(value.Value).LineRaw(";");
                }
                else
                {
                    // first write the variables
                    foreach (var parameterValue in value.ScopeValues!)
                    {
                        var parameterDeclaration = new CodeWriterVariableDeclaration(parameterValue.Name, parameterValue.Type);
                        _writer.AppendDeclaration(parameterDeclaration)
                            .AppendRaw(" = ").AppendExampleParameterValue(parameterValue).LineRaw(";");
                    }
                    // then write the scope
                    _writer.AppendDeclaration(declaration).AppendRaw(" = ")
                        .AppendRaw("$\"")
                        .AppendRaw(value.Scope!.ToString()!)
                        .LineRaw("\";");
                }

                parameters.Add(declaration);
            }
            _writer.Append($"{typeof(ResourceIdentifier)} {idDeclaration:D} = {resourceType}.CreateResourceIdentifier(");
            foreach (var parameter in parameters)
            {
                _writer.Append($"{parameter.Declaration}").AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
        }

        protected override void WriteCreateScopeResourceIdentifier(OperationExample example, CodeWriterDeclaration idDeclaration, RequestPath requestPath)
        {
            var parameters = new List<CodeWriterVariableDeclaration>();
            foreach (var value in example.ComposeResourceIdentifierExpressionValues(requestPath))
            {
                var declaration = new CodeWriterVariableDeclaration(value.Name, value.Type);
                if (value.Value is not null)
                {
                    _writer.AppendDeclaration(declaration)
                        .AppendRaw(" = ").AppendExampleParameterValue(value.Value).LineRaw(";");
                }
                else
                {
                    // first write the variables
                    foreach (var parameterValue in value.ScopeValues!)
                    {
                        var parameterDeclaration = new CodeWriterVariableDeclaration(parameterValue.Name, parameterValue.Type);
                        _writer.AppendDeclaration(parameterDeclaration)
                            .AppendRaw(" = ").AppendExampleParameterValue(parameterValue).LineRaw(";");
                    }
                    // then write the scope
                    _writer.AppendDeclaration(declaration).AppendRaw(" = ")
                        .AppendRaw("$\"")
                        .AppendRaw(value.Scope!.ToString()!)
                        .LineRaw("\";");
                }

                parameters.Add(declaration);
            }
            _writer.Append($"{typeof(ResourceIdentifier)} {idDeclaration:D} = new {typeof(ResourceIdentifier)}(");
            // we do not know exactly which resource the scope is, therefore we need to use the string.Format method to include those parameter values and construct a valid resource id of the scope
            _writer.Append($"{typeof(string)}.Format(\"");
            int refIndex = 0;
            foreach (var segment in requestPath)
            {
                _writer.AppendRaw("/");
                if (segment.IsConstant)
                    _writer.AppendRaw(segment.ConstantValue);
                else
                    _writer.Append($"{{{refIndex++}}}");
            }
            _writer.AppendRaw("\", ");
            foreach (var parameter in parameters)
            {
                _writer.Append($"{parameter.Declaration}").AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw("));");
        }
    }
}
