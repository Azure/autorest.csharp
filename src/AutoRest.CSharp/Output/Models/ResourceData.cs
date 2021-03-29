// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class ResourceData : ObjectType
    {
        private const string _suffixValue = "Data";
        private BuildContext<MgmtOutputLibrary> _context;
        private ObjectTypeProperty[]? _properties;
        private string _prefix;
        private Schema _schema;

        public ResourceData(ObjectSchema schema, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, bool isResourceModel) : base(schema, context, isResourceModel)
        {
            _context = context;
            _prefix = operationGroup.Resource;
            _schema = schema;
            Description = BuilderHelpers.EscapeXmlDescription(CreateDescription(operationGroup, _prefix));
        }

        public new string? Description { get; }

        public new ObjectTypeProperty[] Properties => _properties ??= BuildProperties();

        protected string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the {clientPrefix} data model. " :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private ObjectTypeProperty[] BuildProperties()
        {
            var resourceModel = (ObjectType)_context.Library.ResourceSchemaMap[_schema];
            return resourceModel.Properties;
        }
    }
}
