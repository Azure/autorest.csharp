// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceGroupExtensionsWriter
    {
        public void WriteExtension(CodeWriter writer, ResourceGroupExtensions resourceGroupExtensions, IDictionary<OperationGroup, Mgmt.Output.Resource> armResources)
        {
            var cs = resourceGroupExtensions.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceGroupExtensions.Description);
                using (writer.Scope($"{resourceGroupExtensions.Declaration.Accessibility} static class {cs.Name}"))
                {
                    foreach (var item in armResources)
                    {
                        if (item.Key.Parent.Equals("resourceGroups"))
                        {
                            writer.Line($"#region {item.Value.Type.Name:D}s");
                            WriteGetContainers(writer, item.Value);
                            writer.LineRaw("#endregion");
                            writer.Line();
                        }
                    }
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, Mgmt.Output.Resource armResource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {armResource.Type.Name:D}Container along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("resourceGroup", $"The <see cref=\"{typeof(ResourceGroupOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentation("return", $"Returns an <see cref=\"{armResource.Type.Name:D}Container\" /> object.");
            using (writer.Scope($"public static {armResource.Type.Name:D}Container Get{armResource.Type.Name:D}s (this {typeof(ResourceGroupOperations)} resourceGroup)"))
            {
                // TODO: Bring this back after container class implemented
                // writer.Line($"return new {armResource.Type.Name:D}Container(resourceGroup);");
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }
        }
    }
}
