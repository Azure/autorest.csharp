// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class LongRunningOperationWriterExtensions
    {
        public static void WriteCreateResult(this CodeWriter writer, LongRunningOperation operation, string responseVariable, PagingResponseInfo? pagingResponse, CSharpType? interfaceType)
        {
            if (operation.ResultType != null)
            {
                using (writer.Scope($"{operation.ResultType} {interfaceType}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    writer.WriteCreateResultImpl(false, operation, responseVariable, pagingResponse);
                }
                writer.Line();

                using (writer.Scope($"async {new CSharpType(typeof(ValueTask<>), operation.ResultType)} {interfaceType}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    writer.WriteCreateResultImpl(true, operation, responseVariable, pagingResponse);
                }
            }
        }

        public static void WriteCreateResultImpl(this CodeWriter writer, bool async, LongRunningOperation operation, string responseVariable, PagingResponseInfo? pagingResponse)
        {
            // default value callback, just write a return statement
            Action<FormattableString> valueCallback = fs => writer.Line($"return {fs};");

            if (operation.ResultSerialization != null)
            {
                if (pagingResponse != null)
                {
                    var itemPropertyName = pagingResponse.ItemProperty.Declaration.Name;
                    var nextLinkPropertyName = pagingResponse.NextLinkProperty?.Declaration.Name;

                    writer.Line($"{pagingResponse.ResponseType} firstPageResult;");
                    writer.WriteDeserializationForMethods(
                        operation.ResultSerialization,
                        async: async,
                        v => writer.Line($"firstPageResult = {v};"),
                        responseVariable,
                        pagingResponse.ItemProperty.ValueType);

                    writer.Line($"{pagingResponse.PageType} firstPage = {typeof(Page)}.FromValues(firstPageResult.{itemPropertyName}, firstPageResult.{nextLinkPropertyName}, {responseVariable});");
                    writer.Line();

                    valueCallback($"{typeof(PageableHelpers)}.CreateAsyncEnumerable(_ => Task.FromResult(firstPage), (nextLink, _) => GetNextPage(nextLink, cancellationToken))");
                }
                else
                {
                    writer.WriteDeserializationForMethods(operation.ResultSerialization, async: async, valueCallback, responseVariable, operation.ResultType);
                }
            }
            else
            {
                writer.WriteNonPagingCreateResultImpl(async, responseVariable, valueCallback);
            }
        }

        public static void WriteNonPagingCreateResultImpl(this CodeWriter writer, bool async, string responseVariable, Action<FormattableString> valueCallback)
        {
            if (async)
            {
                valueCallback($"await new {typeof(ValueTask<Response>)}({responseVariable}).ConfigureAwait(false)");
            }
            else
            {
                valueCallback($"{responseVariable}");
            }
        }
    }
}
