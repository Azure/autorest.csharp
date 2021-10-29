// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : SchemaObjectType
    {
        private string? _defaultNamespace;
        private ObjectTypeProperty[]? _myProperties;
        private BuildContext<MgmtOutputLibrary> _context;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext<MgmtOutputLibrary> context)
            : base(objectSchema, context)
        {
            _context = context;
        }

        protected virtual bool IsResourceType => false;

        internal ObjectTypeProperty[] MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        protected override string DefaultNamespace => _defaultNamespace ??= IsResourceType ? base.DefaultNamespace.Substring(0, base.DefaultNamespace.Length - 7) : base.DefaultNamespace;

        protected override string DefaultName => GetDefaultName(ObjectSchema);

        protected string GetDefaultName(ObjectSchema objectSchema)
        {
            var name = objectSchema.CSharpName();
            return IsResourceType ? name + "Data" : name;
        }

        private HashSet<string> GetParentPropertyNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.Declaration.Name)
                .ToHashSet();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            List<ObjectTypeProperty> objTypeProperties = new List<ObjectTypeProperty>();
            var parentProperties = GetParentPropertyNames();
            foreach (var property in base.BuildProperties())
            {
                if (!parentProperties.Contains(property.Declaration.Name))
                {
                    var propertyType = CreatePropertyType(property);
                    yield return propertyType;
                }
            }
        }

        private IEnumerable<ObjectTypeProperty> BuildMyProperties()
        {
            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (var property in objectSchema.Properties)
                {
                    yield return CreateProperty(property);
                }
            }
        }

        protected virtual ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            if (objectTypeProperty.ValueType.IsFrameworkType && objectTypeProperty.ValueType.FrameworkType.IsGenericType)
            {
                for (int i = 0; i < objectTypeProperty.ValueType.Arguments.Length; i++)
                {
                    var argType = objectTypeProperty.ValueType.Arguments[i];
                    var typeToReplace = argType.IsFrameworkType ? null : argType.Implementation as MgmtObjectType;
                    if (typeToReplace != null)
                    {
                        var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace, _context);
                        objectTypeProperty.ValueType.Arguments[i] = match ?? argType;
                    }
                }
                return objectTypeProperty;
            }
            else
            {
                ObjectTypeProperty propertyType = objectTypeProperty;
                var typeToReplace = objectTypeProperty.ValueType?.IsFrameworkType == false ? objectTypeProperty.ValueType.Implementation as MgmtObjectType : null;
                if (typeToReplace != null)
                {
                    var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace, _context);
                    if (match != null)
                    {
                        propertyType = ReferenceTypePropertyChooser.GetObjectTypeProperty(objectTypeProperty, match);
                    }
                }
                return propertyType;
            }
        }

        /// <summary>
        /// Check whether this type should be replaced when used as property type.
        /// </summary>
        /// <returns>true if this type should NOT be replaced when used as property type; false elsewise</returns>
        public bool ShouldNotReplaceForProperty()
        {
            return this._context.Configuration.MgmtConfiguration.NoPropertyTypeReplacement.Contains(this.Type.Name);
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();
            if (inheritedType != null && inheritedType.IsFrameworkType)
                return inheritedType;

            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChooser.GetExactMatch(typeToReplace, typeToReplace.MyProperties, _context);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChooser.GetSupersetMatch(this, MyProperties, _context) : inheritedType;
        }

        protected CSharpType? CreateInheritedTypeWithNoExtraMatch()
        {
            return base.CreateInheritedType();
        }

        public override ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                if (Inherits?.Implementation is SystemObjectType)
                {
                    return GetPropertyBySerializedName(property.SerializedName, includeParents);
                }
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {DefaultName}");
            }

            return objectProperty;
        }
    }
}
