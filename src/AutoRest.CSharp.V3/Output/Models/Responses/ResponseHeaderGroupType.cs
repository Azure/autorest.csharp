// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class ResponseHeaderGroupType: TypeProvider
    {
        private static string[] _knownResponseHeaders = new[]
        {
            "Date",
            "ETag",
            "x-ms-client-request-id",
            "x-ms-request-id"
        };

        public ResponseHeaderGroupType(OperationGroup operationGroup, Operation operation, HttpResponseHeader[] httpResponseHeaders, BuildContext context) : base(context)
        {
            ResponseHeader CreateResponseHeader(HttpResponseHeader header) =>
                new ResponseHeader(
                    header.CSharpName(),
                    header.Header,
                    context.TypeFactory.CreateType(header.Schema, true),
                    BuilderHelpers.EscapeXmlDescription(header.Language!.Default.Description));

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

        public static ResponseHeaderGroupType? TryCreate(OperationGroup operationGroup, Operation operation, BuildContext context)
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

            return new ResponseHeaderGroupType(operationGroup, operation, httpResponseHeaders, context);
        }
    }
}
