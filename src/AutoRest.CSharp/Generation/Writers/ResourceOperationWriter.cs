// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation)
        {
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientCtors(writer, resourceOperation);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceOperation.Type.Name} for mocking.");
            using (writer.Scope($"protected {resourceOperation.Type.Name:D}()"))
            {

            }
            writer.Line();

            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("CancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("An async collection of location that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationException(typeof(InvalidOperationException), "The default subscription id is null.");
            using (writer.Scope($"public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"return await ListAvailableLocationsAsync(ResourceType, cancellationToken);");
            }
            writer.Line();

            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationReturns("A collection of location that may take multiple service requests to iterate over.");
            using (writer.Scope($"public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"return ListAvailableLocations(ResourceType);");
            }
        }
    }
}
