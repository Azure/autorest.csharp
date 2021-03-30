// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Responses
{
    internal abstract class ResponseHeaderGroupType: TypeProvider
    {
        protected static string[] _knownResponseHeaders = new[]
        {
            "Date",
            "ETag",
            "x-ms-client-request-id",
            "x-ms-request-id"
        };

        private readonly HttpResponseHeader[] _httpResponseHeaders;

        public ResponseHeaderGroupType(Operation operation, HttpResponseHeader[] httpResponseHeaders, string clientName, BuildContext context) : base(context)
        {
            string operationName = operation.CSharpName();

            DefaultName = clientName + operationName + "Headers";
            Description = $"Header model for {operationName}";
            _httpResponseHeaders = httpResponseHeaders;
        }

        protected abstract CSharpType GetCsharpType(Schema schema, bool isNullable);

        protected ResponseHeader CreateResponseHeader(HttpResponseHeader header)
        {
            CSharpType type = GetCsharpType(header.Schema, true);

            return new ResponseHeader(
                header.CSharpName(),
                header.Extensions?.HeaderCollectionPrefix ?? header.Header,
                type,
                BuilderHelpers.EscapeXmlDescription(header.Language!.Default.Description));
        }

        public string Description { get; }
        public ResponseHeader[] Headers => _httpResponseHeaders.Select(CreateResponseHeader).ToArray();
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "internal";
    }
}
