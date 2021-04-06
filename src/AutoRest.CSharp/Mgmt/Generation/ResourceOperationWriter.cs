// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
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
        }
    }
}
