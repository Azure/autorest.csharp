// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class SystemObjectType : ObjectType
    {
        private Type _type;
        private CSharpType _csharpType;

        public SystemObjectType(Type type, BuildContext context)
            : base(context)
        {
            _type = type;
            _csharpType = new CSharpType(type);
        }

        public override ObjectTypeProperty? AdditionalPropertiesProperty => null;

        public override bool IncludeSerializer => false;

        public override bool IncludeDeserializer => false;

        public override bool IncludeConverter => false;

        public override string DefaultName => GetNameWithoutGeneric(_type);

        private IEnumerable<PropertyInfo> _myProperties => _type.GetProperties().Where(p => p.DeclaringType == _type);

        protected override ObjectTypeDiscriminator? BuildDiscriminator()
        {
            return null;
        }

        public string GetNameWithoutGeneric(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;

            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(DefaultAccessibility, DefaultName, _csharpType);
            List<Parameter> parameters = new List<Parameter>();
            foreach (var property in _myProperties)
            {
                //object? defaultValue = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : null;
                //Constant constant = new Constant(defaultValue, new CSharpType(property.PropertyType));
                parameters.Add(new Parameter(property.Name, "", new CSharpType(property.PropertyType), null, false));

            }
            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var autoRestProperty in Properties)
            {
                Reference reference = new Reference(autoRestProperty.Declaration.Name, autoRestProperty.ValueType);
                initializers.Add(new ObjectPropertyInitializer(autoRestProperty, reference));
            }
            ObjectTypeConstructor ctor = new ObjectTypeConstructor(memberDeclarationOptions, parameters.ToArray(), initializers.ToArray());
            return ctor;
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var property in _myProperties)
            {
                var getter = property.GetGetMethod();
                var setter = property.GetSetMethod();
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter is not null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    new CSharpType(property.PropertyType));
                yield return new ObjectTypeProperty(memberDeclarationOptions, "", setter is null || !setter.IsPublic, null);
            }
        }

        protected override ObjectTypeConstructor? BuildSerializationConstructor()
        {
            return null;
        }

        protected override ObjectSerialization[] BuildSerializations()
        {
            return new ObjectSerialization[0];
        }

        protected override CSharpType? CreateInheritedDictionaryType()
        {
            throw new NotImplementedException();
        }

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType is null ? null : new CSharpType(_type.BaseType);
        }
    }
}
