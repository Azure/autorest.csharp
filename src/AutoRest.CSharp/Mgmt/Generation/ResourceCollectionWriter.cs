// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

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
                var response = new CodeWriterDeclaration("response");
                _writer
                    .Append($"var {response:D} = {GetAwait(async)} ")
                    .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.MethodName, async)}(");
                WriteArguments(_writer, clientOperation.ParameterMappings.Values.First().SkipLast(1));
                _writer.Line($", cancellationToken: cancellationToken){GetConfigureAwait(async)};");
                _writer.Line($"return Response.FromValue(response.Value != null, response.GetRawResponse());");
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
            var responseVariable = new VariableReference(typeof(Response), "response");
            writer
                .Append($"var {responseVariable.Declaration:D} = {GetAwait(async)} ")
                .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.MethodName, async)}(");
            WriteArguments(writer, parameterMappings.SkipLast(1));
            writer.Line($", cancellationToken: cancellationToken){GetConfigureAwait(async)};");

            var response = new ResponseExpression(responseVariable);
            var armResource = new ArmResourceExpression(response.Value);
            var returnType = operation.MgmtReturnType!;

            var statements = new List<MethodBodyStatement>
            {
                new IfStatement(Equal(armResource, Null))
                {
                    Return(ResponseExpression.FromValue(returnType, Null, response.GetRawResponse()))
                },
                AssignResourceIdentifierIfNeeded(operation, armResource, parameterMappings),
                Return(ResponseExpression.FromValue(New.Instance(returnType, new MemberExpression(null, ArmClientReference), armResource), response.GetRawResponse()))
            };

            writer.WriteMethodBodyStatement(statements);
        }

        private MethodBodyStatement AssignResourceIdentifierIfNeeded(MgmtRestOperation operation, ArmResourceExpression armResource, IReadOnlyList<ParameterMapping> parameterMappings)
            => This.Resource.ResourceData.ShouldSetResourceIdentifier
                ? Assign(armResource.Id, InvokeCreateResourceIdentifier(This.Resource, operation.RequestPath, parameterMappings, armResource))
                : new MethodBodyStatement();
    }
}
