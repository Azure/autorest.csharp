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
        private CodeWriter _writer;
        private Resource _resource;
        private BuildContext<MgmtOutputLibrary> _context;
        private ResourceData _resourceData;

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _resource = resource;
            _context = context;
            _resourceData = _context.Library.GetResourceData(_resource.OperationGroup);
        }

        public void WriteResource()
        {
            var cs = _resource.Type;

            using (_writer.Namespace(cs.Namespace))
            {
                _writer.WriteXmlDocumentationSummary(_resource.Description);

                using (_writer.Scope($"{_resource.Declaration.Accessibility} class {cs.Name} : {cs.Name}Operations"))
                {
                    // write an internal default constructor
                    _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref = \"{cs.Name}\"/> class for mocking.");
                    var baseConstructor = _resourceData.IsResource() ? $" : base()" : string.Empty;
                    using (_writer.Scope($"internal {cs.Name}(){baseConstructor}"))
                    { }

                    // internal constructor
                    _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref = \"{cs.Name}\"/> class.");
                    _writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
                    _writer.WriteXmlDocumentationParameter("resource", "The resource that is the target of operations.");
                    // inherits the default constructor when it is not a resource
                    baseConstructor = _resourceData.IsResource() ? $" : base(options, resource.Id)" : string.Empty;
                    if (!string.IsNullOrEmpty(baseConstructor) && _resource.OperationGroup.IsSingletonResource(_context.Configuration.MgmtConfiguration))
                    {
                        baseConstructor = " : base(options)";
                    }

                    using (_writer.Scope($"internal {cs.Name}({typeof(OperationsBase)} options, {_resourceData.Type} resource){baseConstructor}"))
                    {
                        _writer.LineRaw("Data = resource;");
                    }

                    // write Data
                    _writer.Line();
                    _writer.WriteXmlDocumentationSummary($"Gets or sets the {_context.Library.GetResourceData(_resource.OperationGroup).Type.Name}.");
                    _writer.Append($"public {_resourceData.Type} Data");
                    _writer.Append($"{{ get; private set; }}");
                    _writer.Line();
                }
            }
        }
    }
}
