// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Output.Models.Types
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

        protected override string DefaultName => GetNameWithoutGeneric(_type);
        protected override string DefaultAccessibility { get; } = "public";

        private string ToCamelCase(string name)
        {
            return name.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + name.Substring(1);
        }

        private IEnumerable<ParameterInfo> GetCtorParameters(Type attributeType)
        {
            foreach (var ctor in _type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
                if (!ctor.IsPublic)
                {
                    if (ctor.GetCustomAttributes().FirstOrDefault(a => a.GetType() == attributeType) is not null)
                        return ctor.GetParameters();
                }
            }

            return new List<ParameterInfo>();
        }

        internal IEnumerable<PropertyInfo> GetAllProperties()
        {
            var type = _type;
            while (type is not null)
            {
                foreach (var property in type.GetProperties())
                {
                    yield return property;
                }
                type = type.BaseType;
            }
        }

        private string GetNameWithoutGeneric(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;

            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        private ObjectTypeConstructor BuildConstructor(IEnumerable<ParameterInfo> paramInfos)
        {
            MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions("protected", DefaultName, _csharpType);
            List<Parameter> parameters = new List<Parameter>();
            foreach (var param in paramInfos)
            {
                parameters.Add(new Parameter(ToCamelCase(param.Name!), $"The {param.Name}", GetTypeFromSystem(param.ParameterType), null, false));

            }

            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var autoRestProperty in Properties)
            {
                Reference reference = new Reference(ToCamelCase(autoRestProperty.Declaration.Name), autoRestProperty.ValueType);
                initializers.Add(new ObjectPropertyInitializer(autoRestProperty, reference));
            }

            ObjectTypeConstructor ctor = new ObjectTypeConstructor(memberDeclarationOptions, parameters.ToArray(), initializers.ToArray(), GetBaseCtor());
            return ctor;
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor() => BuildConstructor(GetCtorParameters(typeof(InitializationConstructor)));

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var property in _type.GetProperties().Where(p => p.DeclaringType == _type))
            {
                var getter = property.GetGetMethod();
                var setter = property.GetSetMethod();
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter is not null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    GetTypeFromSystem(property.PropertyType));
                Property prop = new Property();
                prop.Nullable = false;
                prop.ReadOnly = GetReadOnly(property); //TODO read this from attribute from reference object
                prop.SerializedName = ToCamelCase(property.Name);
                prop.Summary = $"Gets{GetPropertySummary(setter)} {property.Name}";
                prop.Required = true;
                prop.Language.Default.Name = property.Name;

                //We are only handling a small subset of cases because the set of reference types used from Azure.ResourceManager.Core is known
                //If in the future we add more types which have unique cases we might need to update this code, but it will be obvious
                //given that the generation will fail with the new types
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    prop.Schema = new DictionarySchema();
                    prop.Schema.Type = AllSchemaTypes.Dictionary;
                }

                yield return new ObjectTypeProperty(memberDeclarationOptions, prop.Summary, prop.IsReadOnly, prop, GetTypeFromSystem(property.PropertyType));
            }
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return BuildInitializationConstructor();
            yield return BuildSerializationConstructor();
        }

        private bool GetReadOnly(PropertyInfo property)
        {
            if (property.Name == "Tags")
                return false;
            return property.GetSetMethod() is null;
        }

        private CSharpType GetTypeFromSystem(Type type)
        {
            List<CSharpType> args = new List<CSharpType>();
            if (type.IsGenericType)
            {
                foreach (var argType in type.GetGenericArguments())
                {
                    args.Add(GetTypeFromSystem(argType));
                }
            }
            return new CSharpType(type, false, args.ToArray());
        }

        private string GetPropertySummary(MethodInfo? setter)
        {
            return setter is not null ? " or sets" : string.Empty;
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor() => BuildConstructor(GetCtorParameters(typeof(SerializationConstructor)));

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType is null ? null : CSharpType.FromSystemType(Context, _type.BaseType);
        }
    }
}
