// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ManagementResourceWriter
    {
        public void WriteResource(CodeWriter writer, ManagementResource managementResource)
        {
            var cs = managementResource.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(managementResource.Description);
                using (writer.Scope($"{managementResource.Declaration.Accessibility} partial class {cs.Name}"))
                {
                }
            }
        }
    }
}
