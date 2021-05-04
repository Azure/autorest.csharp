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
            if (typeToReplace != null)
            {
                var operationGroupToUse = OperationGroup;
                if (operationGroupToUse == null)
                {
                    var children = ObjectSchema.Children;
                    if (children != null)
                    {
                        foreach (var child in children.Immediate)
                        {
                            var resourceData = _context.Library.GetResourceDataFromSchema(child.Name);
                            if (resourceData != null)
                            {
                                operationGroupToUse = resourceData.OperationGroup;
                                break;
                            }
                        }
                    }
                }
                var match = InheritanceChooser.GetExactMatch(operationGroupToUse, typeToReplace, typeToReplace.MyProperties); //AzureEntityResource gets set here
                if (match != null)
                {
                    inheritedType = match; //gets set to TenantResourceIdentifier
                }
            }
            return inheritedType == null ? InheritanceChooser.GetSupersetMatch(OperationGroup, this, MyProperties) : inheritedType;
        }
    }
}
