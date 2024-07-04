// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceData : MgmtObjectType
    {
        public ResourceData(InputModelType inputModel, SerializableObjectType? defaultDerivedType = null)
            : base(inputModel, defaultDerivedType)
        {
            _clientPrefix = inputModel.Name;
        }

        public static ResourceData Empty = new ResourceData(new InputModelType(string.Empty, string.Empty, null, null, null, InputModelTypeUsage.None, Array.Empty<InputModelProperty>(), null, Array.Empty<InputModelType>(), null, null, new Dictionary<string, InputModelType>(), null));

        protected override bool IsResourceType => true;

        protected override FormattableString CreateDescription()
        {
            FormattableString baseDescription = $"{BuilderHelpers.EscapeXmlDocDescription($"A class representing the {_clientPrefix} data model.")}";
            FormattableString extraDescription = string.IsNullOrWhiteSpace(InputModel.Description) ?
                (FormattableString)$"" :
                $"{Environment.NewLine}{BuilderHelpers.EscapeXmlDocDescription(InputModel.Description)}";
            return $"{baseDescription}{extraDescription}";
        }

        private string _clientPrefix;

        private bool? _isTaggable;
        public bool IsTaggable => _isTaggable ??= EnsureIsTaggable();
        private bool EnsureIsTaggable()
        {
            return InputModel.HasTags();
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

        internal virtual bool ShouldSetResourceIdentifier => TypeOfId == null;
    }
}
