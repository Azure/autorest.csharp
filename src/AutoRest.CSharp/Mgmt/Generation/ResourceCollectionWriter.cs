// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource collection.
    /// A resource collection should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceCollectionWriter : MgmtClientBaseWriter
    {
        protected override string ContextProperty => "this";

        protected override string BranchIdVariableName => "Id";

        private ResourceCollection This { get; }

        public ResourceCollectionWriter(CodeWriter writer, ResourceCollection resourceCollection, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceCollection, context)
        {
            This = resourceCollection;
        }

        protected override void WriteProperties()
        {
            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            //if (!resourceType.Contains(".ResourceType"))
            //{
            //    resourceType = $"\"{resourceType}\"";
            //}

            var allPossibleTypes = This.ResourceTypes.SelectMany(p => p.Value).Distinct();

            FormattableString validResourceType = allPossibleTypes.Count() == 1
                ? validResourceType = GetResourceTypeExpression(allPossibleTypes.First())
                : validResourceType = $"{typeof(Azure.Core.ResourceIdentifier)}.Root.ResourceType";
            _writer.Line();

            if (allPossibleTypes.Count() == 1)
                WriteStaticValidate(validResourceType, _writer);
        }

        protected override void BuildParameters(
            MgmtClientOperation clientOperation,
            out Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            out Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings,
            out List<Parameter> methodParameters)
        {
            // get the corresponding MgmtClientOperation mapping
            operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName).Concat(This.ExtraContextualParameterMapping));
            // build parameter mapping
            parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.GetResourceType(Config);
        }

        private void WriteExists(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");

            BuildParameters(clientOperation, out var operationMappings, out _, out var methodParameters);
            WriteCollectionMethodScope(typeof(bool).WrapResponse(async), "Exists", methodParameters, operationMappings.Values.First(), writer =>
            {
                WriteExistsBody(methodParameters, async);
            }, async, isOverride: false);
        }

        private void WriteExistsBody(IEnumerable<Parameter> passThruParameters, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} {CreateMethodName("GetIfExists", async)}(");
            foreach (var parameter in passThruParameters)
            {
                _writer.AppendRaw(parameter.Name);
                _writer.AppendRaw(", ");
            }
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return Response.FromValue(response.Value != null, response.GetRawResponse());");
        }

        private void WriteGetIfExists(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");

            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            WriteCollectionMethodScope(This.Resource.Type.WrapResponse(async), "GetIfExists", methodParameters, operationMappings.Values.First(), writer =>
            {
                WriteGetMethodBody(writer, operationMappings, parameterMappings, async);
            }, async, isOverride: false);
        }

        private void WriteGetMethodBody(CodeWriter writer, IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteGetMethodBranch(writer, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteGetMethodBranch(CodeWriter writer, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var response = new CodeWriterDeclaration("response");
            writer
                .Append($"var {response:D} = {GetAwait(async)} ")
                .Append($"{GetRestFieldName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(async)};");

            writer.Line($"if ({response}.Value == null)");
            writer.Line($"return {typeof(Response)}.FromValue<{This.Resource.Type}>(null, {response}.GetRawResponse());");

            if (This.Resource.ResourceData.ShouldSetResourceIdentifier)
            {
                writer.Line($"{response}.Value.Id = {CreateResourceIdentifierExpression(This.Resource, operation.RequestPath, parameterMappings, $"{response}.Value")};");
            }

            writer.Line($"return {typeof(Response)}.FromValue(new {This.Resource.Type}({ArmClientReference}, {response}.Value), {response}.GetRawResponse());");
        }

        /// <summary>
        /// Write some scaffolding for collection operation methods.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="methodName">Method name in its sync form.</param>
        /// <param name="methodParameters">The "pass-through" parameters, must not contain cancellationToken.</param>
        /// <param name="inner">Main logic of the method writer.</param>
        /// <param name="async"></param>
        /// <param name="isOverride"></param>
        private void WriteCollectionMethodScope(CSharpType returnType, string methodName, IReadOnlyList<Parameter> methodParameters, MgmtRestOperation operation,
            CodeWriterDelegate inner, bool async, bool isOverride = false)
        {
            var fullMethodName = CreateMethodName(methodName, async);

            if (isOverride)
                _writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);

            _writer.Append($"public {GetAsyncKeyword(async)} {GetOverride(isOverride, true)} {returnType} {fullMethodName}(");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Append($"{typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{This.Type.Name}.{methodName}"), GetClientDiagnosticFieldName(operation)))
                {
                    inner(_writer);
                }
            }
        }

        private void WriteEnumerableImpl(CodeWriter writer)
        {
            if (This.GetAllOperation is null)
                return;

            // if this collection has a GetAll function, we could have all kinds of IEnumerable implemented since we have wrapped non-pageable list functions to pageable
            _writer.Line();
            _writer.Line($"{new CSharpType(typeof(IEnumerator<>), This.Resource.Type)} {new CSharpType(typeof(IEnumerable<>), This.Resource.Type)}.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll().GetEnumerator();");
            }
            _writer.Line();
            _writer.Line($"{typeof(IEnumerator)} {typeof(IEnumerable)}.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll().GetEnumerator();");
            }

            _writer.Line();
            _writer.Line($"{new CSharpType(typeof(IAsyncEnumerator<>), This.Resource.Type)} {new CSharpType(typeof(IAsyncEnumerable<>), This.Resource.Type)}.GetAsyncEnumerator({typeof(CancellationToken)} cancellationToken)");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);");
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{typeof(Azure.Core.ResourceIdentifier)}, {This.Resource.Type.Name}, {This.Resource.ResourceData.Type.Name}> Construct() {{ }}");
        }
    }
}
