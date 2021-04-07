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
        public void WriteExtension(CodeWriter writer, ResourceGroupExtensions resourceGroupExtensions, IEnumerable<ArmResource> armResources)
        {
            var cs = resourceGroupExtensions.Type;
            var @namespace = cs.Namespace;
            writer.UseNamespace(@"Azure.ResourceManager.Core");
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceGroupExtensions.Description);
                using (writer.Scope($"{resourceGroupExtensions.Declaration.Accessibility} static class {cs.Name}"))
                {
                    foreach (var item in armResources)
                    {
                        writer.Line($"#region {item.Type.Name:D}s");
                        WriteGetContainers(writer, item);
                        writer.LineRaw("#endregion");
                        writer.Line();
                    }
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, ArmResource armResource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {armResource.Type.Name:D}Container along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("resourceGroup", "The <see cref=\"ResourceGroupOperations\" /> instance the method will execute against.");
            writer.WriteXmlDocumentation("return", $"Returns an <see cref=\"{armResource.Type.Name:D}Container\" /> object.");
            using (writer.Scope($"public static {armResource.Type.Name:D}Container Get{armResource.Type.Name:D}s (this ResourceGroupOperations resourceGroup)"))
            {
                writer.Line($"return new {armResource.Type.Name:D}Container(resourceGroup);");
            }
        }
    }
}
