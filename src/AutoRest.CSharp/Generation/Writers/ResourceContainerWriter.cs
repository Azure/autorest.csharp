// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceContainerWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceContainer resourceContainer)
        {
            var cs = resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceContainer.Description);
                using (writer.Scope($"{resourceContainer.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientCtors(writer, resourceContainer);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceContainer.Type.Name} for mocking.");
            using (writer.Scope($"protected {resourceContainer.Type.Name:D}()"))
            {
            }
        }
    }
}
