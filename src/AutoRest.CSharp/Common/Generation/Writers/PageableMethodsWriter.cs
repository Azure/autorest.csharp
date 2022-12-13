// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class PageableMethodsWriter
    {
        public static CodeWriter WritePageable(this CodeWriter writer, MethodSignature methodSignature, CSharpType? pageItemType, Reference? restClientReference, RestClientMethod? createFirstPageRequestMethod, RestClientMethod? createNextPageRequestMethod, Reference clientDiagnosticsReference, Reference pipelineReference, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, bool async)
        {
            using (writer.WriteMethodDeclaration(methodSignature.WithAsync(async)))
            {
                var firstPageRequest = GetCreateRequestCall(restClientReference, createFirstPageRequestMethod);
                var nextPageRequest = GetCreateRequestCall(restClientReference, createNextPageRequestMethod);
                writer
                    .WriteParametersValidation(methodSignature.Parameters)
                    .WritePageableBody(methodSignature.Parameters, pageItemType, firstPageRequest, nextPageRequest, clientDiagnosticsReference, pipelineReference, scopeName, itemPropertyName, nextLinkPropertyName, async);
            }

            return writer.Line();
        }

        public static CodeWriter WritePageableBody(this CodeWriter writer, IReadOnlyList<Parameter> methodParameters, CSharpType? pageItemType, FormattableString? firstPageRequest, FormattableString? nextPageRequest, Reference clientDiagnosticsReference, Reference pipelineReference, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, bool async)
        {
            var firstPageRequestVariable = firstPageRequest != null ? new CodeWriterDeclaration("FirstPageRequest") : null;
            var nextPageRequestVariable = nextPageRequest != null ? new CodeWriterDeclaration("NextPageRequest") : null;
            List<FormattableString> createPageableParameters = new()
            {
                firstPageRequest != null ? $"{firstPageRequestVariable:I}" : (FormattableString)$"null",
                nextPageRequest != null ? $"{nextPageRequestVariable:I}" : (FormattableString)$"null",
                GetValueFactory(pageItemType),
                clientDiagnosticsReference.GetReferenceFormattable(),
                pipelineReference.GetReferenceFormattable(),
                $"{scopeName:L}",
                $"{itemPropertyName:L}",
                $"{nextLinkPropertyName:L}"
            };

            if (writer.EnsureRequestContextVariable(methodParameters))
            {
                createPageableParameters.Add(((Reference)KnownParameters.RequestContext).GetReferenceFormattable());
            }

            if (firstPageRequestVariable != null)
            {
                writer.Line($"{typeof(HttpMessage)} {firstPageRequestVariable:D}({KnownParameters.PageSizeHint.Type} {KnownParameters.PageSizeHint.Name}) => {firstPageRequest};");
            }

            if (nextPageRequestVariable != null)
            {
                writer.Line($"{typeof(HttpMessage)} {nextPageRequestVariable:D}({KnownParameters.PageSizeHint.Type} {KnownParameters.PageSizeHint.Name}, {KnownParameters.NextLink.Type} {KnownParameters.NextLink.Name}) => {nextPageRequest};");
            }

            return writer.Line($"return {typeof(PageableHelpers)}.{(async ? nameof(PageableHelpers.CreatePageableAsync) : nameof(PageableHelpers.CreatePageable))}({createPageableParameters.Join(", ")});");
        }

        private static bool EnsureRequestContextVariable(this CodeWriter writer, IReadOnlyList<Parameter> parameters)
        {
            if (parameters.Contains(KnownParameters.RequestContext))
            {
                return true;
            }

            var requestContextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            if (!parameters.Contains(KnownParameters.CancellationTokenParameter))
            {
                return false;
            }

            writer.Line($"var {requestContextVariable:D} = {KnownParameters.CancellationTokenParameter.Name:I}.{nameof(CancellationToken.CanBeCanceled)} ? new {KnownParameters.RequestContext.Type} {{ {nameof(RequestContext.CancellationToken)} = {KnownParameters.CancellationTokenParameter.Name:I} }} : null;");
            return true;
        }


        private static FormattableString? GetCreateRequestCall(Reference? restClientReference, RestClientMethod? method)
        {
            if (method == null)
            {
                return null;
            }

            if (restClientReference != null)
            {
                return $"{restClientReference.Value.GetReferenceFormattable()}.Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()})";
            }

            return $"Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()})";
        }

        private static FormattableString GetValueFactory(CSharpType? pageItemType)
        {
            if (pageItemType is null || pageItemType.IsFrameworkType)
            {
                throw new NotSupportedException("Only models are supported!");
            }

            if (pageItemType.Implementation is Resource { ResourceData: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } resourceDataType } resource)
            {
                return $"e => new {resource.Type}(Client, {resourceDataType.Type}.Deserialize{resourceDataType.Declaration.Name}(e))";
            }

            if (pageItemType.Implementation is SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type)
            {
                return $"{type.Type}.Deserialize{type.Declaration.Name}";
            }

            throw new NotSupportedException($"No deserialization logic exists for {pageItemType.Implementation.GetType()}");

        }
    }
}
