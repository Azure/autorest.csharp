// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected string Description = "A class to add extension methods to ResourceGroup.";
        protected string Accessibility = "public";
        protected string Type = "ResourceGroupExtensions";

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(Description);
                using (writer.Scope($"{Accessibility} static partial class {Type}"))
                {
                    foreach (var resource in context.Library.ArmResource)
                    {
                        if (resource.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.ResourceGroups))
                        {
                            foreach (var container in context.Library.ResourceContainers)
                            {
                                if (container.ResourceName == resource.Type.Name)
                                {
                                    writer.Line($"#region {resource.Type.Name}s");
                                    WriteGetContainers(writer, resource, container);
                                    writer.LineRaw("#endregion");
                                    writer.Line();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, Mgmt.Output.Resource armResource, ResourceContainer container)
        {
            // TODO: Find a solution to convert from single to plural
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {container.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("resourceGroup", $"The <see cref=\"{typeof(ResourceGroupOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{container.Type.Name}\" /> object.");
            using (writer.Scope($"public static {container.Type} Get{armResource.Type.Name}s (this {typeof(ResourceGroupOperations)} resourceGroup)"))
            {
                writer.Line($"return new {container.Type.Name}(resourceGroup);");
            }
        }
    }
}
