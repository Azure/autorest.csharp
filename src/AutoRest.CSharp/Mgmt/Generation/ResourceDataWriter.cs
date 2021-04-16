// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceDataWriter : ModelWriter
    {
        public void WriteResourceData(CodeWriter writer, ResourceData resourceData)
        {
            WriteModel(writer, resourceData);

            //var cs = resourceData.Type;
            //var @namespace = cs.Namespace;
            //using (writer.Namespace(@namespace))
            //{
            //    writer.WriteXmlDocumentationSummary(resourceData.Description);
            //    writer.Append($"{resourceData.Declaration.Accessibility} partial class {cs.Name}");
            //    if (!(resourceData.Inherits is null))
            //    {
            //        writer.Append($" : {resourceData.Inherits}");
            //    }

            //    writer.Line();

            //    using (writer.Scope())
            //    {
            //        ModelWriter.WriteConstructor(writer, resourceData);

            //        foreach (var property in resourceData.Properties)
            //        {
            //            writer.WriteXmlDocumentationSummary(property.Description);

            //            CSharpType propertyType = property.Declaration.Type;
            //            writer.Append($"{property.Declaration.Accessibility} {propertyType} {property.Declaration.Name:D}");
            //            writer.AppendRaw(property.IsReadOnly ? "{ get; }" : "{ get; set; }");

            //            writer.Line();
            //        }
            //    }
            //}
        }
    }
}
