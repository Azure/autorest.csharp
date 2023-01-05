// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    internal static class PageableMethodsWriterExtensions
    {
        private static readonly CSharpType BinaryDataType = typeof(BinaryData);

        public static CodeWriter WriteLongRunningPageable(this CodeWriter writer, MethodSignature methodSignature, CSharpType? pageItemType, Reference? restClientReference, RestClientMethod createLroRequestMethod, RestClientMethod? createNextPageRequestMethod, Reference clientDiagnosticsReference, Reference pipelineReference, Diagnostic diagnostic, OperationFinalStateVia finalStateVia, string? itemPropertyName, string? nextLinkPropertyName, bool async)
        {
            using (writer.WriteMethodDeclaration(methodSignature.WithAsync(async)))
            {
                writer.WriteParametersValidation(methodSignature.Parameters);
                using (writer.WriteDiagnosticScope(diagnostic, clientDiagnosticsReference))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var nextPageRequest = GetCreateRequestCall(restClientReference, createNextPageRequestMethod);
                    var nextPageRequestVariable = nextPageRequest != null ? new CodeWriterDeclaration("NextPageRequest") : null;
                    var createPageableParameters = new List<FormattableString>()
                    {
                        $"{KnownParameters.WaitForCompletion.Name}",
                        $"{messageVariable:I}",
                        nextPageRequest != null ? $"{nextPageRequestVariable:I}" : (FormattableString)$"null",
                        GetValueFactory(pageItemType),
                        clientDiagnosticsReference.GetReferenceFormattable(),
                        pipelineReference.GetReferenceFormattable(),
                        $"{typeof(OperationFinalStateVia)}.{finalStateVia}",
                        $"{diagnostic.ScopeName:L}",
                        $"{itemPropertyName:L}",
                        $"{nextLinkPropertyName:L}"
                    };

                    if (writer.EnsureRequestContextVariable(methodSignature.Parameters))
                    {
                        createPageableParameters.Add(((Reference)KnownParameters.RequestContext).GetReferenceFormattable());
                    }

                    if (nextPageRequestVariable != null)
                    {
                        writer.Line($"{typeof(HttpMessage)} {nextPageRequestVariable:D}({KnownParameters.PageSizeHint.Type} {KnownParameters.PageSizeHint.Name}, {KnownParameters.NextLink.Type} {KnownParameters.NextLink.Name}) => {nextPageRequest};");
                    }

                    writer.Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(createLroRequestMethod.Name)}({createLroRequestMethod.Parameters.GetIdentifiersFormattable()});");

                    if (async)
                    {
                        writer.Line($"return await {typeof(PageableHelpers)}.{nameof(PageableHelpers.CreateAsyncPageable)}({createPageableParameters.Join(", ")}).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"return {typeof(PageableHelpers)}.{nameof(PageableHelpers.CreatePageable)}({createPageableParameters.Join(", ")});");
                    }
                }
            }

            return writer.Line();
        }

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

            return writer.Line($"return {typeof(PageableHelpers)}.{(async ? nameof(PageableHelpers.CreateAsyncPageable) : nameof(PageableHelpers.CreatePageable))}({createPageableParameters.Join(", ")});");
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

            var methodName = RequestWriterHelpers.CreateRequestMethodName(method);
            if (restClientReference != null)
            {
                return $"{restClientReference.Value.GetReferenceFormattable()}.{methodName}({method.Parameters.GetIdentifiersFormattable()})";
            }

            return $"{methodName}({method.Parameters.GetIdentifiersFormattable()})";
        }

        private static FormattableString GetValueFactory(CSharpType? pageItemType)
        {
            if (pageItemType is null)
            {
                throw new NotSupportedException("Type of the element of the page must be specified");
            }

            if (pageItemType.IsFrameworkType)
            {
                if (pageItemType.Equals(BinaryDataType))
                {
                    // When `JsonElement` provides access to its UTF8 buffer, change this code to create `BinaryData` from it.
                    // See also PageableHelpers.ParseResponseForBinaryData
                    return $"e => {BinaryDataType}.{nameof(BinaryData.FromString)}(e.GetRawText())";
                }

                if (pageItemType.Equals(typeof(string)))
                {
                    return $"e => e.GetString()";
                }

                throw new NotSupportedException($"{pageItemType.FrameworkType} type is not supported. Only BinaryData, string or user-defined models are supported!");
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
