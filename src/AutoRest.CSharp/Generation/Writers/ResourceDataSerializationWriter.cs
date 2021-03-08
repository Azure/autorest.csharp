// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text.Json;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceDataSerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, ResourceData resourceData)
        {
            var cs = resourceData.Type;
            var @namespace = cs.Namespace;
            var declarationName = resourceData.Declaration.Name;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceData.Description);
                using (writer.Scope($"{resourceData.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    using (writer.Scope($"internal static {cs} Deserialize{declarationName}({typeof(JsonElement)} element)"))
                    {
                        writer.Append($"return new {cs}();");
                    }
                }
            }
        }
    }
}
