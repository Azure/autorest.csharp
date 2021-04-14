// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceGroupExtensionsWriter
    {
        protected string Description = "A class to add extension methods to ResourceGroup.";
        protected string Accessibility = "public";
        protected string Type = "ResourceGroupExtensions";

        public void WriteExtension(string @namespace, MgmtConfiguration mgmtConfiguration, CodeWriter writer, Dictionary<OperationGroup, Resource> armResources)
        {
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(Description);
                using (writer.Scope($"{Accessibility} static class {Type}"))
                {
                    foreach (var item in armResources)
                    {
                        if (item.Key.Parent(mgmtConfiguration).Equals("resourceGroups"))
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
            // TODO: Find a solution to convert from single to plural
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
