// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources.Models;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceData : MgmtObjectType
    {
        public ResourceData(ObjectSchema schema, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context) : base(schema, context, true)
        {
            Description = BuilderHelpers.EscapeXmlDescription(CreateDescription(operationGroup, operationGroup.Resource(context.Configuration.MgmtConfiguration)));
        }

        protected override string DefaultName => GetDefaultName(ObjectSchema, true);

        protected string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the {clientPrefix} data model. " :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        /// <summary>
        /// Tells if a [Resource]Data is a resource by checking if it inherits any of:
        /// Resource, TrackedResource, SubResource, or SubResourceWritable from the Azure.ResourceManager library.
        /// </summary>
        /// <returns></returns>
        internal bool IsResource()
        {
            return EnumerateHierarchy().
                Where(t => t.Inherits != null)
                .Select(t => t.Inherits!.Implementation)
                .Any(s => s is SystemObjectType o && o.SystemType.Assembly.FullName!.StartsWith("Azure.ResourceManager,"));
        }
    }
}
