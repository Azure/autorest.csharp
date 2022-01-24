﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SystemObjectType : ObjectType
    {
        private Type _type;

        public SystemObjectType(Type type, BuildContext context)
            : base(context)
        {
            _type = type;
            DefaultName = GetNameWithoutGeneric(type);
        }

        protected override string DefaultName { get; }
        protected override string DefaultNamespace => _type.Namespace ?? base.DefaultNamespace;

        public override ObjectTypeProperty? AdditionalPropertiesProperty => null;

        internal override Type? SerializeAs => GetSerializeAs(_type);

        protected override string DefaultAccessibility { get; } = "public";

        private string ToCamelCase(string name)
        {
            return name.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + name.Substring(1);
        }

        internal Type SystemType => _type;

        private IEnumerable<ParameterInfo> GetCtorParameters(string attributeType)
        {
            foreach (var ctor in _type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
                if (!ctor.IsPublic)
                {
                    if (ctor.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name == attributeType) != null)
                        return ctor.GetParameters();
                }
            }

            return new List<ParameterInfo>();
        }

        private static Type? GetSerializeAs(Type type) => type.Name switch
        {
            "ResourceIdentifier" => type,
            "SystemData" => type,
            _ => ReferenceTypes.IsMgmtReferenceType (type) ? typeof(string) : null,
        };

        internal IEnumerable<Attribute> GetCustomAttributes()
        {
            var type = _type;
            return type.GetCustomAttributes();
        }

        internal IEnumerable<PropertyInfo> GetAllProperties()
        {
            var type = _type;
            while (type != null)
            {
                foreach (var property in type.GetProperties())
                {
                    yield return property;
                }
                type = type.BaseType;
            }
        }

        private static string GetNameWithoutGeneric(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;

            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        private ObjectTypeConstructor BuildConstructor(IEnumerable<ParameterInfo> paramInfos)
        {
            var parameters = paramInfos
                .Select(param => new Parameter(ToCamelCase(param.Name!), $"The {param.Name}", new CSharpType(param.ParameterType), null, false))
                .ToArray();

            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var autoRestProperty in Properties)
            {
                Reference reference = new Reference(ToCamelCase(autoRestProperty.Declaration.Name), autoRestProperty.ValueType);
                initializers.Add(new ObjectPropertyInitializer(autoRestProperty, reference));
            }

            return new ObjectTypeConstructor(DefaultName, "protected", parameters, initializers.ToArray(), GetBaseCtor());
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor() => BuildConstructor(GetCtorParameters(ReferenceClassFinder.InitializationCtorAttributeName));

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var property in _type.GetProperties().Where(p => p.DeclaringType == _type))
            {
                var getter = property.GetGetMethod();
                var setter = property.GetSetMethod();
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter != null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    new CSharpType(property.PropertyType));
                Property prop = new Property();
                prop.Nullable = false;
                prop.ReadOnly = GetReadOnly(property); //TODO read this from attribute from reference object
                prop.SerializedName = ToCamelCase(property.Name);
                prop.Summary = $"Gets{GetPropertySummary(setter)} {property.Name}";
                prop.Required = true;
                prop.Language.Default.Name = property.Name;

                //We are only handling a small subset of cases because the set of reference types used from Azure.ResourceManager is known
                //If in the future we add more types which have unique cases we might need to update this code, but it will be obvious
                //given that the generation will fail with the new types
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    prop.Schema = new DictionarySchema();
                    prop.Schema.Type = AllSchemaTypes.Dictionary;
                }

                yield return new ObjectTypeProperty(memberDeclarationOptions, prop.Summary, prop.IsReadOnly, prop, new CSharpType(property.PropertyType, GetSerializeAs(property.PropertyType)));
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
            return property.GetSetMethod() == null;
        }

        private string GetPropertySummary(MethodInfo? setter)
        {
            return setter != null ? " or sets" : string.Empty;
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor() => BuildConstructor(GetCtorParameters(ReferenceClassFinder.SerializationCtorAttributeName));

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType == null ? null : CSharpType.FromSystemType(Context, _type.BaseType);
        }
    }
}
