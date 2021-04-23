// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : SchemaObjectType
    {
        private readonly TypeFactory _typeFactory;
        private bool _isResourceType;
        private HashSet<string?>? _hierarchyProperties;
        private ObjectTypeProperty[]? _properties;
        private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _typeFactory = context.TypeFactory;
            _isResourceType = isResourceType;
        }

        public override ObjectTypeProperty[] Properties => _properties ??= GetProperties().ToArray();

        private ObjectTypeProperty[] MyProperties => _myProperties ??= BuildProperties(false).ToArray();

        public override string DefaultName => GetDefaultName(ObjectSchema, _isResourceType);

        public HashSet<string?> HierarchyProperties => _hierarchyProperties ??= GetParentProperties();

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        private bool HasSystemBaseType()
        {
            return (Inherits is not null && !Inherits.IsFrameworkType && Inherits.Implementation is SystemObjectType);
        }

        private IEnumerable<ObjectTypeProperty> GetProperties()
        {
            foreach (var property in base.Properties)
            {
                if (!HierarchyProperties.Contains(property.Declaration.Name))
                    yield return property;
            }
        }

        private HashSet<string?> GetParentPropertiesFromSystemObject()
        {
            HashSet<string?> baseProperties = new HashSet<string?>();
            if (HasSystemBaseType())
            {
                var baseType = Inherits!.Implementation as SystemObjectType;
                foreach (var property in baseType!.GetAllProperties())
                {
                    baseProperties.Add(property.Name);
                }
            }

            return baseProperties;
        }

        protected override HashSet<string?> GetParentProperties()
        {
            if (HasSystemBaseType())
            {
                return GetParentPropertiesFromSystemObject();
            }
            else
            {
                return base.GetParentProperties();
            }
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();

            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChoser.GetExactMatch(typeToReplace, typeToReplace.MyProperties);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChoser.GetSupersetMatch(this, MyProperties) : inheritedType;
        }
    }
}
