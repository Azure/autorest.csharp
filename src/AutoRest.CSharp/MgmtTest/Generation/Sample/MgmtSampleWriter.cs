// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Sample;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.MgmtTest.Generation.Sample
{
    internal class MgmtSampleWriter : MgmtTestWriterBase<MgmtSampleProvider>
    {
        private MockTestCase testCase => This.Sample;

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
            _writer.Line($"// {This.Sample.Name}");
            _writer.Line($"[NUnit.Framework.Test]");
            _writer.Line($"[NUnit.Framework.Ignore(\"Only verifying that the sample builds\")]");
            using (_writer.WriteMethodDeclaration(testCase.GetMethodSignature(false)))
            {
                WriteSampleSteps();
            }
        }

        private void WriteSampleSteps()
        {
            // Write claimers
            _writer.Line($"// this example is just showing the usage of \"{testCase.OperationId}\" operation, for the dependent resources, they will have to be created separately.");
            _writer.Line();

            // Write the ArmClient and authentication
            var clientStepResult = WriteGetArmClient();

            // Write the operation invocation
            var result = testCase.Carrier switch
            {
                ResourceCollection collection => WriteSampleOperationForResourceCollection(clientStepResult, collection),
                Resource resource => WriteSampleOperationForResource(clientStepResult, resource),
                MgmtExtensions extension => WriteSampleOperationForExtension(clientStepResult, extension),
                _ => throw new InvalidOperationException("Should never happen"),
            };

            // Write the result handling
            WriteResultHandling(result);
        }

        private void WriteResultHandling(CodeWriterVariableDeclaration? result, bool newLine = true)
        {
            // do nothing if the previous step returns nothing
            if (result == null)
                return;

            if (newLine)
                _writer.Line();

            if (result.Type.IsResourceType(out var resource))
            {
                WriteResourceResultHandling(result, resource);
            }
            else if (result.Type.IsResourceDataType(out var resourceData))
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
            var dataResult = new CodeWriterVariableDeclaration("data", resource.ResourceData.Type);
            _writer.AppendDeclaration(dataResult)
                .Line($"= {result.Declaration}.Data;");

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
            _writer.Line($"// authenticate your client");
            var clientResult = new CodeWriterVariableDeclaration("client", typeof(ArmClient));
            _writer.UseNamespace("Azure.Identity");
            _writer.AppendDeclaration(clientResult)
                .Line($" = new {typeof(ArmClient)}(new DefaultAzureCredential());");

            return clientResult;
        }

        private string GetResourceName(MgmtTypeProvider provider) => provider switch
        {
            Resource resource => resource.Type.Name,
            MgmtExtensions extension => extension.ArmCoreType.Name,
            _ => throw new InvalidOperationException("Should never happen")
        };

        private CodeWriterVariableDeclaration? WriteSampleOperationForResourceCollection(CodeWriterVariableDeclaration clientResult, ResourceCollection collection)
        {
            _writer.Line();

            var collectionResult = WriteGetCollection(clientResult, collection);
            var result = WriteSampleOperation(collectionResult);

            return result;
        }

        private CodeWriterVariableDeclaration? WriteSampleOperationForResource(CodeWriterVariableDeclaration clientVar, Resource resource)
        {
            _writer.Line();

            var resourceName = GetResourceName(resource);
            _writer.Line($"// this example assumes you already have this {resourceName} created on azure");
            _writer.Line($"// for more information of creating {resourceName}, please refer to the document of {resourceName}");
            var resourceResult = WriteGetResource(resource, testCase, $"{clientVar.Declaration}");
            var result = WriteSampleOperation(new CodeWriterVariableDeclaration(resourceResult, resource.Type));

            return result;
        }

        private CodeWriterVariableDeclaration? WriteSampleOperationForExtension(CodeWriterVariableDeclaration clientVar, MgmtExtensions extension)
        {
            _writer.Line();

            var resourceName = GetResourceName(extension);
            _writer.Line($"// this example assumes you already have this {resourceName} created on azure");
            _writer.Line($"// for more information of creating {resourceName}, please refer to the document of {resourceName}");
            var resourceResult = WriteGetExtension(extension, testCase, $"{clientVar.Declaration}");
            var result = WriteSampleOperation(new CodeWriterVariableDeclaration(resourceResult, extension.ArmCoreType));

            return result;
        }

        private CodeWriterVariableDeclaration WriteGetCollection(CodeWriterVariableDeclaration clientResult, ResourceCollection collection)
        {
            var parent = testCase.Parent;
            Debug.Assert(parent != null);

            var parentName = GetResourceName(parent);
            _writer.Line($"// this example assumes you already have this {parentName} created on azure");
            _writer.Line($"// for more information of creating {parentName}, please refer to the document of {parentName}");
            var parentVar = WriteGetResource(parent, testCase, $"{clientResult.Declaration}");

            var resourceName = collection.Resource.ResourceName;
            // now we have the parent resource, get the collection from that resource
            // TODO -- we might should look this up inside the code project for correct method name
            var getResourceCollectionMethodName = $"Get{resourceName.ResourceNameToPlural()}";
            var collectionResult = new CodeWriterVariableDeclaration("collection", collection.Type);

            _writer.Line();
            _writer.Line($"// get the collection of this {collection.Resource.Type.Name}");
            // first find the variables we need and write their assignments
            var parameters = new Dictionary<Parameter, CodeWriterVariableDeclaration>();
            foreach (var extraParameter in collection.ExtraConstructorParameters)
            {
                if (testCase.ParameterValueMapping.TryGetValue(extraParameter.Name, out var value))
                {
                    var declaration = new CodeWriterVariableDeclaration(extraParameter.Name, extraParameter.Type);
                    parameters.Add(extraParameter, declaration);

                    _writer.AppendDeclaration(declaration)
                        .AppendRaw(" = ")
                        .AppendExampleParameterValue(value, extraParameter.Type)
                        .LineRaw(";");
                }
            }
            _writer.AppendDeclaration(collectionResult)
                .Append($"= {parentVar}.{getResourceCollectionMethodName}(");
            var parameterValues = testCase.ParameterValueMapping;
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

        private CodeWriterVariableDeclaration? WriteSampleOperation(CodeWriterVariableDeclaration collectionResult)
        {
            if (testCase.IsLro)
            {
                return WriteSampleLroOperation(collectionResult.Declaration);
            }
            else if (testCase.IsPageable)
            {
                return WriteSamplePageableOperation(collectionResult.Declaration);
            }

            return WriteSampleNormalOperation(collectionResult.Declaration);
        }

        private CodeWriterVariableDeclaration? WriteSampleLroOperation(CodeWriterDeclaration instanceVar)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation");
            // if the Lro is an ArmOperation<T>
            var lroType = testCase.Operation.ReturnType;
            if (lroType.IsGenericType)
            {
                var lroResult = new CodeWriterVariableDeclaration("lro", testCase.Operation.ReturnType);
                _writer.AppendDeclaration(lroResult).AppendRaw(" = ");
                // write the method invocation
                WriteOperationInvocation(instanceVar);
                var valueResult = new CodeWriterVariableDeclaration("result", lroType.Arguments.First());
                _writer.AppendDeclaration(valueResult)
                    .Line($"= {lroResult.Declaration}.Value;");

                return valueResult;
            }
            else
            {
                // if the Lro is an ArmOperation without body, we just write the method invocation without assignment
                WriteOperationInvocation(instanceVar);
                return null;
            }
        }

        private CodeWriterVariableDeclaration? WriteSampleNormalOperation(CodeWriterDeclaration instanceVar)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation");
            var returnType = testCase.Operation.ReturnType;
            if (returnType.IsGenericType)
            {
                // an operation with a response
                var valueResult = new CodeWriterVariableDeclaration("result", returnType.Arguments.First());
                _writer.AppendDeclaration(valueResult).AppendRaw(" = ");
                // write the method invocation
                WriteOperationInvocation(instanceVar);
                return valueResult;
            }
            else
            {
                // an operation without a response
                WriteOperationInvocation(instanceVar);
                return null;
            }
        }

        private CodeWriterVariableDeclaration? WriteSamplePageableOperation(CodeWriterDeclaration instanceVar)
        {
            _writer.Line();
            _writer.Line($"// invoke the operation and iterate over the result");
            // when the operation is pageable, the return type refers to the type of the item T, instead of Pageable<T>
            var itemResult = new CodeWriterVariableDeclaration("item", testCase.Operation.ReturnType);
            _writer.Append($"await foreach (")
                .AppendDeclaration(itemResult)
                .AppendRaw(" in ");

            WriteOperationInvocation(instanceVar, isEndOfLine: false);
            using (_writer.Scope($")"))
            {
                WriteResultHandling(itemResult, newLine: false);
            }

            // an invocation of a pageable operation does not return a result
            return null;
        }

        private void WriteOperationInvocation(CodeWriterDeclaration instanceVar, bool isEndOfLine = true, bool isAsync = true)
        {
            var methodName = CreateMethodName(testCase.Operation.Name);
            _writer.AppendIf($"await ", isAsync && !testCase.Operation.IsPagingOperation) // paging operation never needs this await
                .Append($"{instanceVar}.{methodName}(");
            foreach (var parameter in testCase.Operation.MethodParameters)
            {
                if (testCase.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    _writer.AppendExampleParameterValue(parameter, parameterValue);
                    _writer.AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")").LineRawIf(";", isEndOfLine);
        }

        protected override CodeWriterDeclaration WriteGetFromResource(Resource carrierResource, OperationExample example, FormattableString client)
        {
            var idVar = new CodeWriterDeclaration($"{carrierResource.Type.Name}Id".ToVariableName());
            _writer.Append($"{typeof(ResourceIdentifier)} {idVar:D} = {carrierResource.Type}.CreateResourceIdentifier(");
            foreach (var value in example.ComposeResourceIdentifierParameterValues(carrierResource.RequestPath))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
            var resourceVar = new CodeWriterDeclaration(carrierResource.ResourceName.ToVariableName());
            _writer.Line($"{carrierResource.Type} {resourceVar:D} = {client}.Get{carrierResource.Type.Name}({idVar});");

            return resourceVar;
        }
    }
}
