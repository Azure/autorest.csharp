// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
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
        private string _prefix;
        private ObjectSchema _schema;

        public ResourceData(ObjectSchema schema, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, bool isResourceModel) : base(schema, context, isResourceModel)
        {
            _context = context;
            _prefix = operationGroup.Resource;
            _schema = schema;
            Description = BuilderHelpers.EscapeXmlDescription(CreateDescription(operationGroup, _prefix));
        }

        public new string? Description { get; }

        protected string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the {clientPrefix} data model. " :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        protected override HashSet<string?> GetParentProperties()
        {
            if (Inherits?.IsFrameworkType == false)
            {
                return base.GetParentProperties();
            }

            System.Type type = Inherits?.FrameworkType!;
            if (type is null)
            {
                return new HashSet<string?>();
            }

            return type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Select(p =>
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(char.ToLower(p.Name[0]));
                    builder.Append(p.Name.Substring(1));
                    return builder.ToString();
                })
                .ToHashSet<string?>();
        }
    }
}
