// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceGroupExtensionsWriter
    {
        public void WriteExtension(CodeWriter writer, IEnumerable<ArmResource> armResources, IEnumerable<ResourceOperation> resourceOperations, IEnumerable<ResourceContainer> resourceContainers )
        {
            var resourceGroupExtensions = new ResourceGroupExtensions();
            var cs = resourceGroupExtensions.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceGroupExtensions.Description);
                using (writer.Scope($"{resourceGroupExtensions.Declaration.Accessibility} static class {cs.Name}"))
                {
                    foreach (var item in armResources)
                    {
                        writer.LineRaw($"#region {item.Type.Name}");
                        WriteGetOperations(writer, item);
                    }
                    
                }
            }
        }

        private void WriteGetOperations(CodeWriter writer, ArmResource armResource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing the operations that can be performed over a specific {armResource.Type.Name}");
            writer.WriteXmlDocumentationParameter("resourceGroup", "The <see cref=\"ResourceGroupOperations\" /> instance the method will execute against.");
            //writer.WriteXmlDocumentationParameter(item.Type.)
            //writer.WriteXmlDocumentationRequiredParametersException()
            using (writer.Scope($"public static {armResource.Type.Name:D}(this ResourceGroupOperations resourceGroup, string vmName)"))
            {
            }
        }

        private void WriteGetContainers(CodeWriter writer, ResourceGroupExtensions resourceOperation)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing {resourceOperation.Type.Name} for mocking.");
            using (writer.Scope($"public static {resourceOperation.Type.Name:D}()"))
            {
            }
        }
    }
}
