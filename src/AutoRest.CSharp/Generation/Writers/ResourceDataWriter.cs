// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceDataWriter
    {
        public void WriteResourceData(CodeWriter writer, ResourceData resourceData)
        {
            var cs = resourceData.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceData.Description);
                using (writer.Scope($"{resourceData.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    foreach (var property in resourceData.Properties)
                    {
                        writer.WriteXmlDocumentationSummary(property.Description);

                        CSharpType propertyType = property.Declaration.Type;
                        writer.Append($"{property.Declaration.Accessibility} {propertyType} {property.Declaration.Name:D}");
                        writer.AppendRaw(property.IsReadOnly ? "{ get; }" : "{ get; set; }");

                        writer.Line();
                    }
                }
            }
        }
    }
}
