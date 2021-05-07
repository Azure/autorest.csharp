// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClientMethod
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

        public LowLevelClientMethod(RestClientMethod restClientMethod, SchemaDocumentation[]? schemaDocumentations, Diagnostic diagnostics)
        {
            RestClientMethod = restClientMethod;
            Diagnostics = diagnostics;
            SchemaDocumentations = schemaDocumentations;
        }

        public RestClientMethod RestClientMethod { get; }
        public Diagnostic Diagnostics { get; }
        public SchemaDocumentation[]? SchemaDocumentations { get; }

    }
}
