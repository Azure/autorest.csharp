// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter
    {
        public void WriteResource(CodeWriter writer, Resource resource)
        {
            var cs = resource.Type;

            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(resource.Description);

                using (writer.Scope($"{resource.Declaration.Accessibility} class {cs.Name} : {cs.Name}Operations"))
                {
                    // internal constructor
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref = \"{cs.Name}\"/> class.");
                    writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
                    writer.WriteXmlDocumentationParameter("resource", "The resource that is the target of operations.");
                    using (writer.Scope($"internal {cs.Name}({typeof(ResourceOperationsBase)} options, {resource.ResourceDataObject.Type} resource) : base(options, resource.Id)"))
                    {
                        writer.LineRaw("Data = resource;");
                    }

                    // write Data
                    writer.Line();
                    var x = resource.ResourceDataObject.GetType();
                    writer.WriteXmlDocumentationSummary($"Gets or sets the {resource.ResourceDataObject.Type.Name}.");
                    writer.LineRaw("public " + resource.ResourceDataObject.Type.Name + " Data {get; private set;}");

                    // protected override GetResource
                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    using (writer.Scope($"protected override {cs.Name} GetResource({typeof(CancellationToken)} cancellation = default)"))
                    {
                        writer.LineRaw("return this;");
                    }

                    // protected override GetResourceAsync
                    writer.Line();
                    writer.WriteXmlDocumentationInheritDoc();
                    using (writer.Scope($"protected override {typeof(Task)}<{cs.Name}> GetResourceAsync({typeof(CancellationToken)} cancellation = default)"))
                    {
                        writer.Line($"return {typeof(Task)}.FromResult(this);");
                    }
                }
            }
        }
    }
}
