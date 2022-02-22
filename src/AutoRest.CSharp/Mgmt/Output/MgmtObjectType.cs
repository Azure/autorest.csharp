// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
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
        private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema)
            : this(objectSchema, default, default)
        {
        }

        public MgmtObjectType(ObjectSchema objectSchema, string? name = default, string? nameSpace = default)
            : base(objectSchema, MgmtContext.Context)
        {
            _defaultName = name;
            _defaultNamespace = nameSpace;
        }

        protected virtual bool IsResourceType => false;
        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= GetDefaultName(ObjectSchema, IsResourceType);
        private string? _defaultNamespace;
        protected override string DefaultNamespace => _defaultNamespace ??= GetDefaultNamespace(Context, ObjectSchema, IsResourceType);

        internal ObjectTypeProperty[] MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        private static string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        private static string GetDefaultNamespace(BuildContext context, Schema objectSchema, bool isResourceType)
        {
            return isResourceType ? context.DefaultNamespace : GetDefaultNamespace(objectSchema.Extensions?.Namespace, context);
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
                        var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
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
                    var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
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
            return Configuration.MgmtConfiguration.NoPropertyTypeReplacement.Contains(this.Type.Name);
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();
            if (inheritedType != null && inheritedType.IsFrameworkType)
                return inheritedType;

            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChooser.GetExactMatch(typeToReplace, typeToReplace.MyProperties);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChooser.GetSupersetMatch(this, MyProperties) : inheritedType;
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
