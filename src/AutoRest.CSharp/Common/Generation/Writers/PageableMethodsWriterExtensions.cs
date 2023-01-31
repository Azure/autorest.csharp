// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class PageableMethodsWriterExtensions
    {
        private static readonly CSharpType BinaryDataType = typeof(BinaryData);

        public static CodeWriter WritePageable(this CodeWriter writer, MethodSignature methodSignature, CSharpType? pageItemType, Reference? restClientReference, RestClientMethod? createFirstPageRequestMethod, RestClientMethod? createNextPageRequestMethod, Reference clientDiagnosticsReference, Reference pipelineReference, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, bool async)
        {
            using (writer.WriteMethodDeclaration(methodSignature))
            {
                writer.WriteParametersValidation(methodSignature.Parameters);
                var parameters = methodSignature.Parameters.ToList();
                var firstPageRequest = GetCreateRequestCall(restClientReference, createFirstPageRequestMethod);
                var nextPageRequest = GetCreateRequestCall(restClientReference, createNextPageRequestMethod);

                writer.EnsureRequestContextVariable(parameters, createFirstPageRequestMethod, createNextPageRequestMethod);
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

                if (ContainsRequestContext(methodSignature.Parameters))
                {
                    createPageableParameters.Add($"{KnownParameters.RequestContext.Name:I}");
                }
                else if (methodSignature.Parameters.Contains(KnownParameters.CancellationTokenParameter))
                {
                    createPageableParameters.Add($"{KnownParameters.CancellationTokenParameter.Name:I}");
                }

                if (firstPageRequestVariable != null)
                {
                    writer.Line($"{typeof(HttpMessage)} {firstPageRequestVariable:D}({KnownParameters.PageSizeHint.Type} {KnownParameters.PageSizeHint.Name}) => {firstPageRequest};");
                }

                if (nextPageRequestVariable != null)
                {
                    writer.Line($"{typeof(HttpMessage)} {nextPageRequestVariable:D}({KnownParameters.PageSizeHint.Type} {KnownParameters.PageSizeHint.Name}, {KnownParameters.NextLink.Type} {KnownParameters.NextLink.Name}) => {nextPageRequest};");
                }

                writer.Line($"return {typeof(PageableHelpers)}.{(async ? nameof(PageableHelpers.CreateAsyncPageable) : nameof(PageableHelpers.CreatePageable))}({createPageableParameters.Join(", ")});");
            }

            return writer.Line();
        }

        private static void EnsureRequestContextVariable(this CodeWriter writer, List<Parameter> parameters, RestClientMethod? createFirstPageRequestMethod, RestClientMethod? createNextPageRequestMethod)
        {
            if (ContainsRequestContext(parameters))
            {
                return;
            }

            if (!ContainsRequestContext(createFirstPageRequestMethod?.Parameters) && !ContainsRequestContext(createNextPageRequestMethod?.Parameters))
            {
                return;
            }

            var requestContextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            if (parameters.Contains(KnownParameters.CancellationTokenParameter))
            {
                writer.Line($"{KnownParameters.RequestContext.Type} {requestContextVariable:D} = {KnownParameters.CancellationTokenParameter.Name:I}.{nameof(CancellationToken.CanBeCanceled)} ? new {KnownParameters.RequestContext.Type} {{ {nameof(RequestContext.CancellationToken)} = {KnownParameters.CancellationTokenParameter.Name:I} }} : null;");
            }
            else
            {
                writer.Line($"{KnownParameters.RequestContext.Type} {requestContextVariable:D} = null;");
            }

            parameters.Add(KnownParameters.RequestContext);

        }

        private static bool ContainsRequestContext(IReadOnlyCollection<Parameter>? parameters) =>
            parameters != null && parameters.Contains(KnownParameters.RequestContext);

        private static FormattableString? GetCreateRequestCall(Reference? restClientReference, RestClientMethod? createRequestMethod)
        {
            if (createRequestMethod == null)
            {
                return null;
            }

            var methodName = RequestWriterHelpers.CreateRequestMethodName(createRequestMethod);
            if (restClientReference != null)
            {
                return $"{restClientReference.Value.GetReferenceFormattable()}.{methodName}({createRequestMethod.Parameters.GetIdentifiersFormattable()})";
            }

            return $"{methodName}({createRequestMethod.Parameters.GetIdentifiersFormattable()})";
        }

        public static FormattableString GetValueFactory(CSharpType? pageItemType)
        {
            if (pageItemType is null)
            {
                throw new NotSupportedException("Type of the element of the page must be specified");
            }

            if (pageItemType.Equals(BinaryDataType))
            {
                // When `JsonElement` provides access to its UTF8 buffer, change this code to create `BinaryData` from it.
                // See also PageableHelpers.ParseResponseForBinaryData
                return $"e => {BinaryDataType}.{nameof(BinaryData.FromString)}(e.{nameof(JsonElement.GetRawText)}())";
            }

            if (!pageItemType.IsFrameworkType && pageItemType.Implementation is SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type)
            {
                return $"{type.Type}.Deserialize{type.Declaration.Name}";
            }

            var deserializeImplementation = JsonCodeWriterExtensions.GetDeserializeValueFormattable($"e", pageItemType);
            return $"e => {deserializeImplementation}";
        }
    }
}
