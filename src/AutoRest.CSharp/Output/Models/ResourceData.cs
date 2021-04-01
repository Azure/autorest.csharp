// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class ResourceData : MgmtObjectType
    {
        public ResourceData(ObjectSchema schema, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context) : base(schema, context, true)
        {
            Description = BuilderHelpers.EscapeXmlDescription(CreateDescription(operationGroup, operationGroup.Resource));
        }

        protected override string DefaultName => GetDefaultName(OjectSchema, true);

        public new string? Description { get; }

        protected string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
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

            return GetPropertiesFromSystemType(type).ToHashSet<string?>();
        }
    }
}
