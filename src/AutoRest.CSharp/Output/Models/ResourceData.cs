// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class ResourceData : ResourceOperation
    {
        private const string _suffixValue = "Data";
        private BuildContext _context;
        private ObjectTypeProperty[]? _properties;
        private Schema _schema;

        public ResourceData(Schema schema, OperationGroup operationGroup, BuildContext context) : base(operationGroup, context)
        {
            _context = context;
            _schema = schema;
            DefaultNamespace = GetDefaultNamespace(schema, context);
            var a = (ObjectType)_context.Library.ResourceSchemaMap[_schema];

        }

        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties();
        protected override string SuffixValue => _suffixValue;
        protected override string DefaultNamespace { get; }

        protected override string CreateDescription(OperationGroup operationGroup, string clientPrefix)
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
