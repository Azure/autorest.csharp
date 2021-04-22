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

        public MgmtObjectType(ObjectSchema objectSchema, BuildContext context, bool isResourceType) : base(objectSchema, context)
        {
            _typeFactory = context.TypeFactory;
            _isResourceType = isResourceType;
        }

        public override ObjectTypeProperty[] Properties => HasSystemBaseType() ? GetProperties().ToArray() : base.Properties;

        private ObjectTypeProperty[] DefinedProperties => base.Properties;

        public override string DefaultName => GetDefaultName(ObjectSchema, _isResourceType);

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
            HashSet<string> baseProperties = new HashSet<string>();
            if (HasSystemBaseType())
            {
                var baseType = Inherits!.Implementation as SystemObjectType;
                foreach (var property in baseType!.GetAllProperties())
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

            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChoser.GetExactMatch(typeToReplace, typeToReplace.Properties);
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
