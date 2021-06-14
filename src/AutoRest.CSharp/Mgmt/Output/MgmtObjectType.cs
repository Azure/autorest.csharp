﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private bool _isResourceType;
        private ObjectTypeProperty[]? _myProperties;
        private BuildContext<MgmtOutputLibrary> _context;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext<MgmtOutputLibrary> context, bool isResourceType) : base(objectSchema, context)
        {
            _isResourceType = isResourceType;
            _context = context;
        }

        private ObjectTypeProperty[] MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        protected override string DefaultName => GetDefaultName(ObjectSchema, _isResourceType);

        internal OperationGroup? OperationGroup => _context.Library.GetOperationGroupBySchema(ObjectSchema);

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
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
            var parentProperties = GetParentPropertyNames();
            foreach (var property in base.BuildProperties())
            {
                if (!parentProperties.Contains(property.Declaration.Name))
                    yield return property;
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

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();

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
