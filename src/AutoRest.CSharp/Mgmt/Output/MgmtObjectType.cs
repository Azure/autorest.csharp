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
        //private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _typeFactory = context.TypeFactory;
            _isResourceType = isResourceType;
        }

        public override ObjectTypeProperty[] Properties => GetProperties().ToArray();

        public override string DefaultName => GetDefaultName(ObjectSchema, _isResourceType);

        protected string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        private IEnumerable<ObjectTypeProperty> GetProperties()
        {
            HashSet<string> baseProperties = new HashSet<string>();
            if (Inherits is not null && !Inherits.IsFrameworkType && Inherits.Implementation is SystemObjectType baseType)
            {
                foreach (var property in baseType.GetAllProperties())
                {
                    baseProperties.Add(property.Name);
                }
            }

            foreach (var property in DefinedProperties)
            {
                if (!baseProperties.Contains(property.Declaration.Name))
                    yield return property;
            }
        }

        protected override CSharpType? CreateInheritedType()
        {
            CSharpType? inheritedType = base.CreateInheritedType();

            var typeToReplace = inheritedType?.Implementation as ObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChoser.GetExactMatch((MgmtObjectType)typeToReplace, DefinedProperties);
                if (match != null)
                {
                    inheritedType = match;
                }
            }
            return inheritedType == null ? InheritanceChoser.GetSupersetMatch(this, DefinedProperties) : inheritedType;
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            if (!(Inherits is not null && Inherits.Implementation is SystemObjectType))
                yield return InitializationConstructor;

            if (!IncludeDeserializer)
            {
                yield break;
            }

            // Skip serialization ctor if they are the same
            if (!InitializationConstructor.Parameters
                .Select(p => p.Type)
                .SequenceEqual(SerializationConstructor!.Parameters.Select(p => p.Type)))
            {
                yield return SerializationConstructor;
            }
        }
    }
}
