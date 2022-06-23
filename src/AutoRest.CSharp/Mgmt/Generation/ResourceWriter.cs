// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        private Resource This { get; }

        public ResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            This = resource;
            _customMethods.Add(nameof(WriteAddTagBody), WriteAddTagBody);
            _customMethods.Add(nameof(WriteSetTagsBody), WriteSetTagsBody);
            _customMethods.Add(nameof(WriteRemoveTagBody), WriteRemoveTagBody);
        }

        protected override void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            var method = This.CreateResourceIdentifierMethodSignature();
            _writer.WriteXmlDocumentationSummary($"{method.Description}");
            var parameterList = string.Join(", ", method.Parameters.Select(param => $"{param.Type.Name} {param.Name}"));

            var requestPath = This.RequestPath;
            using (_writer.Scope($"public static {method.ReturnType?.Name} {method.Name}({parameterList})"))
            {
                // Storage has inconsistent definitions:
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L58
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L146
                // so here we have to use `Seqment.BuildSerializedSegments` instead of `RequestPath.SerializedPath` which could be from `RestClientMethod.Operation.GetHttpPath`
                // If first segment is "{var}", then we should not add leading "/". Instead, we should let callers to specify, e.g. "{scope}/providers/Microsoft.Resources/..." v.s. "/subscriptions/{subscriptionId}/..."
                _writer.Line($"var resourceId = $\"{Segment.BuildSerializedSegments(requestPath, !requestPath.Any() || requestPath.First().IsConstant)}\";");
                _writer.Line($"return new {method.ReturnType?.Name}(resourceId);");
            }
        }

        protected override void WriteProperties()
        {
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
            _writer.Line($"public virtual bool HasData {{ get; }}");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
            _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
            using (_writer.Scope($"public virtual {This.ResourceData.Type} Data"))
            {
                using (_writer.Scope($"get"))
                {
                    _writer.Line($"if (!HasData)");
                    _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                    _writer.Line($"return _data;");
                }
            }

            _writer.Line();
            WriteStaticValidate($"ResourceType");
        }

        private void WriteAddTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                _writer.Append($"var originalTags = ");
                if (async)
                {
                    _writer.Append($"await ");
                }
                _writer.Line($"GetTagResource().{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                _writer.Line($"originalTags.Value.Data.TagValues[key] = value;");
                WriteTaggableCommonMethod(async);
            }
            _writer.Line();
        }

        private void WriteSetTagsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                if (async)
                {
                    _writer.Append($"await ");
                }
                _writer.Line($"GetTagResource().{CreateMethodName("Delete", async)}({typeof(WaitUntil)}.Completed, cancellationToken: cancellationToken){GetConfigureAwait(async)};");
                _writer.Append($"var originalTags  = ");
                if (async)
                {
                    _writer.Append($"await ");
                }
                _writer.Line($"GetTagResource().{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                _writer.Line($"originalTags.Value.Data.TagValues.ReplaceWith(tags);");
                WriteTaggableCommonMethod(async);
            }
            _writer.Line();
        }

        private void WriteRemoveTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                _writer.Append($"var originalTags = ");
                if (async)
                {
                    _writer.Append($"await ");
                }
                _writer.Line($"GetTagResource().{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                _writer.Line($"originalTags.Value.Data.TagValues.Remove(key);");
                WriteTaggableCommonMethod(async);
            }
            _writer.Line();
        }

        private void WriteTaggableCommonMethod(bool async)
        {
            _writer.Line($"{GetAwait(async)} GetTagResource().{CreateMethodName("CreateOrUpdate", async)}({typeof(WaitUntil)}.Completed, originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(async)};");

            MgmtClientOperation clientOperation = This.GetOperation!;
            // we need to write multiple branches for a normal method
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WriteTaggableCommonMethodBranch(clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var originalResponse = new CodeWriterDeclaration("originalResponse");
            _writer
                .Append($"var {originalResponse:D} = {GetAwait(async)} ")
                .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");

            WriteArguments(_writer, parameterMappings, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            if (This.ResourceData.ShouldSetResourceIdentifier)
            {
                _writer.Line($"{originalResponse}.Value.Id = {CreateResourceIdentifierExpression(This, operation.RequestPath, parameterMappings, $"{originalResponse}.Value")};");
            }

            _writer.Line($"return {typeof(Response)}.FromValue(new {operation.ReturnType.UnWrapResponse()}({ArmClientReference}, {originalResponse}.Value), {originalResponse}.GetRawResponse());");
        }
    }
}
