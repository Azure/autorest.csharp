// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClientMethod : RestClientMethod
    {
        internal class SchemaDocumentation
        {
            public const string RequestBody = "Request Body";
            public const string ResponseBody = "Response Body";
            public const string ResponseError = "Response Error";

            internal record DocumentationRow(string Name, string Type, bool Required, string Description) { }

            public string SchemaName { get; }
            public DocumentationRow[] DocumentationRows { get; }

            public SchemaDocumentation(string schemaName, DocumentationRow[] documentationRows)
            {
                SchemaName = schemaName;
                DocumentationRows = documentationRows;
            }
        }

        public LowLevelClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, Operation operation, IReadOnlyDictionary<string, SchemaDocumentation[]> schemaDocumentations, Diagnostic diagnostics) :
            base (name, description, returnType, request, parameters, responses, headerModel, bufferResponse, accessibility, operation)
        {
            Diagnostics = diagnostics;
            SchemaDocumentations = schemaDocumentations;
        }

        public Diagnostic Diagnostics { get; }
        public IReadOnlyDictionary<string, SchemaDocumentation[]> SchemaDocumentations { get; }
    }
}
