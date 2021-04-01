// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Responses
{
    internal class DataPlaneResponseHeaderGroupType: TypeProvider
    {
        private static string[] _knownResponseHeaders = new[]
        {
            "Date",
            "ETag",
            "x-ms-client-request-id",
            "x-ms-request-id"
        };

        public DataPlaneResponseHeaderGroupType(OperationGroup operationGroup, Operation operation, HttpResponseHeader[] httpResponseHeaders, BuildContext<DataPlaneOutputLibrary> context) : base(context)
        {
            ResponseHeader CreateResponseHeader(HttpResponseHeader header)
            {
                CSharpType type = context.TypeFactory.CreateType(header.Schema, true);

                return new ResponseHeader(
                    header.CSharpName(),
                    header.Extensions?.HeaderCollectionPrefix ?? header.Header,
                    type,
                    BuilderHelpers.EscapeXmlDescription(header.Language!.Default.Description));
            }

            string operationName = operation.CSharpName();
            var clientName = context.Library.FindRestClient(operationGroup).ClientPrefix;

            DefaultName = clientName + operationName + "Headers";
            Description = $"Header model for {operationName}";
            Headers = httpResponseHeaders.Select(CreateResponseHeader).ToArray();
        }

        public string Description { get; }
        public ResponseHeader[] Headers { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "internal";

        public static DataPlaneResponseHeaderGroupType? TryCreate(OperationGroup operationGroup, Operation operation, BuildContext<DataPlaneOutputLibrary> context)
        {
            var httpResponseHeaders = operation.Responses.SelectMany(r => r.HttpResponse.Headers)
                .Where(h => !_knownResponseHeaders.Contains(h.Header, StringComparer.InvariantCultureIgnoreCase))
                .GroupBy(h => h.Header)
                // Take first header definition with any particular name
                .Select(h => h.First())
                .ToArray();

            if (!httpResponseHeaders.Any())
            {
                return null;
            }

            return new DataPlaneResponseHeaderGroupType(operationGroup, operation, httpResponseHeaders, context);
        }
    }
}