// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource collection.
    /// A resource collection should have 3 operations:
    /// 1. CreateOrUpdate (2 variants)
    /// 2. Get (2 variants)
    /// 3. List (2 variants)
    /// </summary>
    internal class ResourceCollectionWriter : MgmtClientBaseWriter
    {
        private ResourceCollection This { get; }

        public ResourceCollectionWriter(ResourceCollection resourceCollection) : this(new CodeWriter(), resourceCollection)
        {
        }

        protected ResourceCollectionWriter(CodeWriter writer, ResourceCollection resourceCollection)
            : base(writer, resourceCollection)
        {
            This = resourceCollection;
            _customMethods.Add(nameof(WriteExistsBody), WriteExistsBody);
            _customMethods.Add(nameof(WriteGetIfExistsBody), WriteGetIfExistsBody);
        }

        protected override void WriteProperties()
        {
            var allPossibleTypes = This.ResourceTypes.SelectMany(p => p.Value).Distinct();

            FormattableString validResourceType = allPossibleTypes.Count() == 1
                ? GetResourceTypeExpression(allPossibleTypes.First())
                : $"{typeof(Azure.Core.ResourceIdentifier)}.Root.ResourceType";
            _writer.Line();

            if (allPossibleTypes.Count() == 1)
                WriteStaticValidate(validResourceType);
        }

        private void WriteExistsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(clientOperation.OperationMappings.Values.First())))
            {
                var operation = clientOperation.OperationMappings.Values.First();
                var response = new CodeWriterDeclaration(Configuration.ApiTypes.ResponseParameterName);
                _writer
                    .Append($"var {response:D} = {GetAwait(async)} ")
                    .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.MethodName, async)}(");
                WriteArguments(_writer, clientOperation.ParameterMappings.Values.First().SkipLast(1));
                _writer.Line($", cancellationToken: cancellationToken){GetConfigureAwait(async)};");
                _writer.Line($"return {Configuration.ApiTypes.ResponseType}.FromValue({Configuration.ApiTypes.ResponseParameterName}.Value != null, {Configuration.ApiTypes.ResponseParameterName}.{Configuration.ApiTypes.GetRawResponseName}());");
            }
        }

        private void WriteGetIfExistsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(clientOperation.OperationMappings.Values.First())))
            {
                // we need to write multiple branches for a normal method
                if (clientOperation.OperationMappings.Count == 1)
                {
                    // if we only have one branch, we would not need those if-else statements
                    var branch = clientOperation.OperationMappings.Keys.First();
                    WriteGetMethodBranch(_writer, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
                }
                else
                {
                    // branches go here
                    throw new NotImplementedException("multi-branch normal method not supported yet");
                }
            }
        }

        private void WriteGetMethodBranch(CodeWriter writer, MgmtRestOperation operation, IReadOnlyList<ParameterMapping> parameterMappings, bool async)
        {
            var returnType = operation.MgmtReturnType!;
            var restClient = new MemberExpression(null, GetRestClientName(operation));
            var arguments = GetArguments(writer, parameterMappings.SkipLast(1));
            arguments.Add(new PositionalParameterReference(KnownParameters.CancellationTokenParameter.Name, KnownParameters.CancellationTokenParameter));

            writer.WriteMethodBodyStatement(new[]
            {
                Var(Configuration.ApiTypes.ResponseParameterName, new(restClient.Invoke(CreateMethodName(operation.MethodName, async), arguments, async)), out ResponseExpression response),
                new IfStatement(Equal(response.Value, Null), AddBraces: false)
                {
                    Return(New.Instance(new CSharpType(typeof(NoValueResponse<>), returnType), response.GetRawResponse()))
                },
                AssignResourceIdentifierIfNeeded(operation, new(response.Value), parameterMappings),
                Return(ResponseExpression.FromValue(New.Instance(returnType, new MemberExpression(null, ArmClientReference), response.Value), response.GetRawResponse()))
            });
        }

        private MethodBodyStatement AssignResourceIdentifierIfNeeded(MgmtRestOperation operation, ArmResourceExpression armResource, IReadOnlyList<ParameterMapping> parameterMappings)
            => This.Resource.ResourceData.ShouldSetResourceIdentifier
                ? Assign(armResource.Id, InvokeCreateResourceIdentifier(This.Resource, operation.RequestPath, parameterMappings, armResource))
                : new MethodBodyStatement();
    }
}
