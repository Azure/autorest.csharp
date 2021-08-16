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

        internal OperationGroup? OperationGroup => _context.Library.GetOperationGroupBySchema(ObjectSchema);

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

        private ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            ObjectTypeProperty propertyType = objectTypeProperty;
            var typeToReplace = objectTypeProperty.ValueType?.IsFrameworkType == false ? objectTypeProperty.ValueType.Implementation as MgmtObjectType : null;
            if (typeToReplace != null)
            {
                var match = ReferenceTypePropertyChooser.GetExactMatch(objectTypeProperty, typeToReplace, typeToReplace.MyProperties);
                if (match != null)
                {
                    propertyType = match;
                }
            }
            return propertyType;
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();
            if (inheritedType?.IsFrameworkType == true && !inheritedType.FrameworkType.IsGenericType)
                return inheritedType;

            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            var operationGroupToUse = OperationGroup ?? GetOperationGroupFromChildren();
            if (typeToReplace != null)
            {
                var match = InheritanceChooser.GetExactMatch(operationGroupToUse, typeToReplace, typeToReplace.MyProperties);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChooser.GetSupersetMatch(operationGroupToUse, this, MyProperties) : inheritedType;
        }

        private OperationGroup? GetOperationGroupFromChildren()
        {
            OperationGroup? operationGroup = null;
            var children = ObjectSchema.Children;
            if (children == null)
                return null;

            foreach (var child in children.Immediate)
            {
                var resourceData = _context.Library.GetResourceDataFromSchema(child.Name);
                if (resourceData != null)
                {
                    return resourceData.OperationGroup;
                }
                else
                {
                    operationGroup = _context.Library.GetOperationGroupForNonResource(child.Name);
                    if (operationGroup != null)
                        return operationGroup;

                    // child is Model not Data
                    MgmtObjectType? mgmtObject = _context.Library.GetMgmtObjectFromModelName(child.Name);
                    if (mgmtObject != null)
                    {
                        operationGroup = mgmtObject.GetOperationGroupFromChildren();
                        if (operationGroup != null)
                            return operationGroup;

                    }
                }
            }

            return operationGroup;
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
