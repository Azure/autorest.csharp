// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

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

        public DataPlaneResponseHeaderGroupType(InputClient inputClient, InputOperation operation, OperationResponseHeader[] httpResponseHeaders, BuildContext<DataPlaneOutputLibrary> context)
            :this(httpResponseHeaders, context, operation.Name.ToCleanName(), context.Library.FindRestClient(inputClient).ClientPrefix)
        {
        }

        private DataPlaneResponseHeaderGroupType(OperationResponseHeader[] httpResponseHeaders, BuildContext<DataPlaneOutputLibrary> context, string operationName, string clientName)
            : base(context)
        {
            ResponseHeader CreateResponseHeader(OperationResponseHeader header)
            {
                CSharpType type = context.TypeFactory.CreateType(header.Type);

                return new ResponseHeader(
                    header.Name.ToCleanName(),
                    header.NameInResponse,
                    type,
                    BuilderHelpers.EscapeXmlDescription(header.Description));
            }

            DefaultName = clientName + operationName + "Headers";
            Description = $"Header model for {operationName}";
            Headers = httpResponseHeaders.Select(CreateResponseHeader).ToArray();
        }

        protected override string DefaultName { get; }
        public string Description { get; }
        public ResponseHeader[] Headers { get; }
        protected override string DefaultAccessibility { get; } = "internal";

        public static DataPlaneResponseHeaderGroupType? TryCreate(InputClient inputClient, InputOperation operation, BuildContext<DataPlaneOutputLibrary> context)
        {
            var OperationResponseHeaders = operation.Responses.SelectMany(r => r.Headers)
                .Where(h => !_knownResponseHeaders.Contains(h.NameInResponse, StringComparer.InvariantCultureIgnoreCase))
                .GroupBy(h => h.NameInResponse)
                // Take first header definition with any particular name
                .Select(h => h.First())
                .ToArray();

            if (!OperationResponseHeaders.Any())
            {
                return null;
            }

            return new DataPlaneResponseHeaderGroupType(inputClient, operation, OperationResponseHeaders, context);
        }
    }
}
