// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClientMethod : RestClientMethod
    {
        internal class SchemaDocumentation
        {
            internal record DocumentationRow(string Name, string Type, bool Required, string Description) { }

            public string SchemaName { get; }
            public DocumentationRow[] DocumentationRows { get; }

            public SchemaDocumentation(string schemaName, DocumentationRow[] documentationRows)
            {
                SchemaName = schemaName;
                DocumentationRows = documentationRows;
            }
        }

        public LowLevelClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, SchemaDocumentation[]? schemaDocumentations, Diagnostic diagnostics) :
            base (name, description, returnType, request, parameters, responses, headerModel, bufferResponse, accessibility)
        {
            Diagnostics = diagnostics;
            SchemaDocumentations = schemaDocumentations;
        }

        public Diagnostic Diagnostics { get; }
        public SchemaDocumentation[]? SchemaDocumentations { get; }
    }
}
