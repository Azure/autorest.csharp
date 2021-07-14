// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter
    {
        public void WriteResource(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            var cs = resource.Type;

            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(resource.Description);
                var resourceDataObject = context.Library.GetResourceData(resource.OperationGroup);

                using (writer.Scope($"{resource.Declaration.Accessibility} class {cs.Name} : {cs.Name}Operations"))
                {
                    // internal constructor
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref = \"{cs.Name}\"/> class.");
                    writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
                    writer.WriteXmlDocumentationParameter("resource", "The resource that is the target of operations.");
                    // inherits the default constructor when it is not a resource
                    var resourceData = context.Library.GetResourceData(resource.OperationGroup);
                    var baseConstructor = resourceData.IsResource() ? $" : base(options, resource.Id)" : string.Empty;
                    if (!string.IsNullOrEmpty(baseConstructor) && resource.OperationGroup.IsSingletonResource(context.Configuration.MgmtConfiguration))
                    {
                        baseConstructor = " : base(options)";
                    }

                    using (writer.Scope($"internal {cs.Name}({typeof(OperationsBase)} options, {resourceDataObject.Type} resource){baseConstructor}"))
                    {
                        writer.LineRaw("Data = resource;");
                    }

                    // write Data
                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Gets or sets the {context.Library.GetResourceData(resource.OperationGroup).Type.Name}.");
                    writer.Append($"public {resourceDataObject.Type} Data");
                    writer.Append($"{{ get; private set; }}");
                    writer.Line();

                    // Only write GetResource if it is NEITHER singleton NOR scope resource.
                    if (!resource.OperationGroup.IsSingletonResource(context.Configuration.MgmtConfiguration) && !resource.OperationGroup.IsScopeResource(context.Configuration.MgmtConfiguration))
                    {
                        // protected override GetResource
                        writer.Line();
                        writer.WriteXmlDocumentationInheritDoc();
                        using (writer.Scope(
                            $"protected override {cs.Name} GetResource({typeof(CancellationToken)} cancellation = default)")
                        )
                        {
                            writer.LineRaw("return this;");
                        }

                        // protected override GetResourceAsync
                        writer.Line();
                        writer.WriteXmlDocumentationInheritDoc();
                        using (writer.Scope(
                            $"protected override {typeof(Task)}<{cs.Name}> GetResourceAsync({typeof(CancellationToken)} cancellation = default)")
                        )
                        {
                            writer.Line($"return {typeof(Task)}.FromResult(this);");
                        }
                    }
                }
            }
        }
    }
}
