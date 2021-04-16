// Copyright (c) Microsoft Corporation. All rights reserved.
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
    internal class MgmtObjectType : SchemaObjectType
    {
        private readonly TypeFactory _typeFactory;
        private bool _isResourceType;
        //private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _typeFactory = context.TypeFactory;
            _isResourceType = isResourceType;
        }

        public override string DefaultName => GetDefaultName(ObjectSchema, _isResourceType);

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();

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
