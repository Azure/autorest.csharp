﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Azure.ResourceManager.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        private Resource This { get; }

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context) : base(writer, resource, context)
        {
            This = resource;
        }

        protected override void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            // Right now, `RequestPaths` contains only one path. But in the future when we start to support multiple context path per resource,
            // we should implement the logic to avoid overload conflicts (e.g. /{A}/{B}/{C} v.s. /{D}/{E}/{F}, both context path contains 3 parameters).
            foreach (var requestPath in This.RequestPaths)
            {
                if (requestPath.Count == 0)
                    continue;
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Generate the resource identifier of a <see cref=\"{This.Type}\"/> instance.");
                var parameterList = string.Join(", ", requestPath.Where(segment => segment.IsReference).Select(segment => $"string {segment.ReferenceName}"));
                using (_writer.Scope($"public static {typeof(Azure.Core.ResourceIdentifier)} CreateResourceIdentifier({parameterList})"))
                {
                    // Storage has inconsistent definitions:
                    // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L58
                    // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L146
                    // so here we have to use `Seqment.BuildSerializedSegments` instead of `RequestPath.SerializedPath` which could be from `RestClientMethod.Operation.GetHttpPath`
                    // If first segment is "{var}", then we should not add leading "/". Instead, we should let callers to specify, e.g. "{scope}/providers/Microsoft.Resources/..." v.s. "/subscriptions/{subscriptionId}/..."
                    _writer.Line($"var resourceId = $\"{Segment.BuildSerializedSegments(requestPath, requestPath.First().IsConstant)}\";");
                    _writer.Line($"return new {typeof(Azure.Core.ResourceIdentifier)}(resourceId);");
                }
            }
        }

        protected override void WriteCustomMethods()
        {
            WriteListAvailableLocationsMethod(true);
            WriteListAvailableLocationsMethod(false);

            if (This.IsTaggable)
            {
                WriteAddTagMethod(true);
                WriteAddTagMethod(false);

                WriteSetTagsMethod(true);
                WriteSetTagsMethod(false);

                WriteRemoveTagMethod(true);
                WriteRemoveTagMethod(false);
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
            WriteStaticValidate($"ResourceType", _writer);
        }

        private void WriteListAvailableLocationsMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"A collection of locations that may take multiple service requests to iterate over.");

            var responseType = new CSharpType(typeof(IEnumerable<AzureLocation>)).WrapAsync(async);

            using (_writer.Scope($"public {GetAsyncKeyword(async)} virtual {responseType} {CreateMethodName("GetAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                Diagnostic diagnostic = new Diagnostic($"{This.Type.Name}.GetAvailableLocations", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
                {
                    _writer.Line($"return {GetAwait(async)} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken){GetConfigureAwait(async)};");
                }
            }
        }

        private void WriteAddTagMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Add a tag to the current resource.");
            _writer.WriteXmlDocumentationParameter("key", $"The key for the tag.");
            _writer.WriteXmlDocumentationParameter("value", $"The value for the tag.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tag added.");

            var responseType = This.Type.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} virtual {responseType} {CreateMethodName("AddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteVariableNullOrWhiteSpaceCheck("key");
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{This.Type.Name}.AddTag", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue[key] = value;");
                    WriteTaggableCommonMethod(async);
                }
                _writer.Line();
            }
        }

        private void WriteSetTagsMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Replace the tags on the resource with the given set.");
            _writer.WriteXmlDocumentationParameter("tags", $"The set of tags to use as replacement.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tags replaced.");

            var responseType = This.Type.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} virtual {responseType} {CreateMethodName("SetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                using (_writer.Scope($"if (tags == null)"))
                {
                    _writer.Line($"throw new {typeof(ArgumentNullException)}(nameof(tags), $\"{{nameof(tags)}} provided cannot be null.\");");
                }
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{This.Type.Name}.SetTags", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
                {
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Delete", async)}(true, cancellationToken: cancellationToken){GetConfigureAwait(async)};");
                    _writer.Append($"var originalTags  = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);");
                    WriteTaggableCommonMethod(async);
                }
                _writer.Line();
            }
        }

        private void WriteRemoveTagMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Removes a tag by key from the resource.");
            _writer.WriteXmlDocumentationParameter("key", $"The key of the tag to remove.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tag removed.");

            var responseType = This.Type.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} virtual {responseType} {CreateMethodName("RemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteVariableNullOrWhiteSpaceCheck("key");
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{This.Type.Name}.RemoveTag");
                using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue.Remove(key);");
                    WriteTaggableCommonMethod(async);
                }
                _writer.Line();
            }
        }

        private void WriteTaggableCommonMethod(bool async)
        {
            _writer.Line($"{GetAwait(async)} TagResource.{CreateMethodName("CreateOrUpdate", async)}(true, originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(async)};");

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

            _writer.Line($"return {typeof(Response)}.FromValue(new {This.Type}({ArmClientReference}, {originalResponse}.Value), {originalResponse}.GetRawResponse());");
        }
    }
}
