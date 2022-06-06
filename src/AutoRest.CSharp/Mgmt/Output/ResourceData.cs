// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceData : MgmtObjectType
    {
        public ResourceData(ObjectSchema schema)
            : this(schema, default, default)
        {
        }

        public ResourceData(ObjectSchema schema, string? name = default, string? nameSpace = default)
            : base(schema, name, nameSpace)
        {
            _clientPrefix = schema.Name;
        }

        protected override bool IsResourceType => true;

        protected override string CreateDescription()
        {
            return BuilderHelpers.EscapeXmlDescription($"A class representing the {_clientPrefix} data model.") + BuilderHelpers.UpdateDescription(this);
        }

        private string _clientPrefix;

        private bool? _isTaggable;
        public bool IsTaggable => _isTaggable ??= EnsureIsTaggable();
        private bool EnsureIsTaggable()
        {
            return ObjectSchema.HasTags();
        }

        private CSharpType? typeOfId;
        internal CSharpType? TypeOfId => typeOfId ??= GetTypeOfId();

        /// <summary>
        /// Get the <see cref="CSharpType"/> of the `Id` property of this ResourceData.
        /// Return null if this resource data does not have an Id property.
        /// </summary>
        /// <returns></returns>
        private CSharpType? GetTypeOfId()
        {
            var baseTypes = EnumerateHierarchy().TakeLast(2).ToArray();
            var baseType = baseTypes.Length == 1 || baseTypes[1].Declaration.Name == "Object" ? baseTypes[0] : baseTypes[1];
            var idProperty = baseType.Properties.Where(p => p.Declaration.Name == "Id").FirstOrDefault();
            return idProperty?.Declaration.Type;
        }

        internal CSharpType? GetTypeOfName()
        {
            var baseTypes = EnumerateHierarchy().TakeLast(2).ToArray();
            var baseType = baseTypes.Length == 1 || baseTypes[1].Declaration.Name == "Object" ? baseTypes[0] : baseTypes[1];
            var nameProperty = baseType.Properties.Where(p => p.Declaration.Name == "Name").FirstOrDefault();
            return nameProperty?.Declaration.Type;
        }

        internal bool ShouldSetResourceIdentifier => TypeOfId == null;
    }
}
