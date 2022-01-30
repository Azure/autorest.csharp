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
            _customMethods.Add(nameof(WriteExistsBody), WriteExistsBody);
            _customMethods.Add(nameof(WriteGetIfExistsBody), WriteGetIfExistsBody);
        }

        protected override void WriteProperties()
        {
            var allPossibleTypes = This.ResourceTypes.SelectMany(p => p.Value).Distinct();

            FormattableString validResourceType = allPossibleTypes.Count() == 1
                ? validResourceType = GetResourceTypeExpression(allPossibleTypes.First())
                : validResourceType = $"{typeof(Azure.Core.ResourceIdentifier)}.Root.ResourceType";
            _writer.Line();

            if (allPossibleTypes.Count() == 1)
                WriteStaticValidate(validResourceType, _writer);
        }

        private void WriteExistsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(clientOperation.OperationMappings.Values.First())))
            {
                _writer.Append($"var response = {GetAwait(async)} {CreateMethodName("GetIfExists", async)}(");
                foreach (var parameter in clientOperation.MethodParameters)
                {
                    if (parameter.IsRequired)
                    {
                        _writer.AppendRaw(parameter.Name);
                    }
                    else
                    {
                        _writer.AppendRaw($"{parameter.Name}: {parameter.Name}");
                    }
                    _writer.AppendRaw(", ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($"){GetConfigureAwait(async)};");
                _writer.Line($"return Response.FromValue(response.Value != null, response.GetRawResponse());");
            }
        }

        private void WriteGetIfExistsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(clientOperation.OperationMappings.Values.First())))
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

        private void WriteGetMethodBranch(CodeWriter writer, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var response = new CodeWriterDeclaration("response");
            writer
                .Append($"var {response:D} = {GetAwait(async)} ")
                .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
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
    }
}
