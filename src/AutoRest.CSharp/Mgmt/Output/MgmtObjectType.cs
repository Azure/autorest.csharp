﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : ObjectType
    {
        private readonly TypeFactory _typeFactory;
        private bool _isResourceType;
        private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _typeFactory = context.TypeFactory;
            _isResourceType = isResourceType;
        }

        protected override string DefaultName => GetDefaultName(OjectSchema, _isResourceType);

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        public override CSharpType? Inherits => _inheritsType ??= CreateInheritedType();

        public ObjectTypeProperty[] MyProperties => _myProperties ??= BuildProperties(false).ToArray();

        protected override HashSet<string?> GetParentProperties()
        {
            HashSet<string?> result = new HashSet<string?>();
            CSharpType? type = Inherits;
            while (type != null)
            {
                if (type.IsFrameworkType == false)
                {
                    if (type.Implementation is ObjectType objType)
                    {
                        result.UnionWith(objType.Properties.Select(p => p.SchemaProperty?.Language.Default.Name));
                        type = objType.Inherits;
                    }
                    else
                    {
                        type = null;
                    }
                }
                else
                {
                    result.UnionWith(GetPropertiesFromSystemType(type.FrameworkType));
                    type = null;
                }
            }
            return result;
        }

        protected IEnumerable<string> GetPropertiesFromSystemType(System.Type systemType)
        {
            return systemType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Select(p =>
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(char.ToLower(p.Name[0]));
                    builder.Append(p.Name.Substring(1));
                    return builder.ToString();
                });
        }

        private CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = null;

            var sourceBaseType = ExistingType?.BaseType;
            if (sourceBaseType != null &&
                sourceBaseType.SpecialType != SpecialType.System_ValueType &&
                sourceBaseType.SpecialType != SpecialType.System_Object &&
                _typeFactory.TryCreateType(sourceBaseType, out CSharpType? baseType))
            {
                inheritedType = baseType;
            }
            else
            {
                var objectSchemas = OjectSchema.Parents!.Immediate.OfType<ObjectSchema>().ToArray();

                ObjectSchema? selectedSchema = null;

                foreach (var objectSchema in objectSchemas)
                {
                    // Take first schema or the one with discriminator
                    selectedSchema ??= objectSchema;

                    if (objectSchema.Discriminator != null)
                    {
                        selectedSchema = objectSchema;
                        break;
                    }
                }

                if (selectedSchema != null)
                {
                    CSharpType type = _typeFactory.CreateType(selectedSchema, false);
                    Debug.Assert(!type.IsFrameworkType);
                    inheritedType = type;
                }
            }

            var typeToReplace = inheritedType?.Implementation as ObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChoser.GetExactMatch((MgmtObjectType)typeToReplace);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChoser.GetSupersetMatch(this) : inheritedType;
        }
    }
}
