// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceData : MgmtObjectType
    {
        public ResourceData(ObjectSchema schema, BuildContext<MgmtOutputLibrary> context)
            : base(schema, context)
        {
            Description = BuilderHelpers.EscapeXmlDescription(CreateDescription(schema.Name));
        }

        protected override bool IsResourceType => true;

        protected string CreateDescription(string clientPrefix)
        {
            return $"A class representing the {clientPrefix} data model.";
        }
    }
}
