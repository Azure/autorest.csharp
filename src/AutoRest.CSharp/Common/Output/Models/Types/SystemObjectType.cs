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
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

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

        private ConstructorInfo GetCtor(string attributeType)
        {
            foreach (var ctor in _type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
                if (ctor.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name == attributeType) != null)
                    return ctor;
            }

            throw new InvalidOperationException($"{attributeType} ctor was not found for {_type.Name}");
        }

        private static Type? GetSerializeAs(Type type) => type.Name switch
        {
            "ResourceIdentifier" => type,
            "SystemData" => type,
            _ => null,
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

        private ObjectTypeConstructor BuildConstructor(ConstructorInfo ctor)
        {
            var parameters = ctor.GetParameters()
                .Select(param => new Parameter(ToCamelCase(param.Name!), $"The {param.Name}", new CSharpType(param.ParameterType), null, ValidationType.None, null))
                .ToArray();

            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var autoRestProperty in Properties)
            {
                Reference reference = new Reference(ToCamelCase(autoRestProperty.Declaration.Name), autoRestProperty.ValueType);
                initializers.Add(new ObjectPropertyInitializer(autoRestProperty, reference));
            }

            var modifiers = ctor.IsFamily ? Protected : Public;

            return new ObjectTypeConstructor(DefaultName, modifiers, parameters, initializers.ToArray(), GetBaseCtor());
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor() => BuildConstructor(GetCtor(ReferenceClassFinder.InitializationCtorAttributeName));

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var property in _type.GetProperties().Where(p => p.DeclaringType == _type))
            {
                var getter = property.GetGetMethod();
                var setter = property.GetSetMethod();
                var isNullable = IsNullable(property.PropertyType);
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter != null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    new CSharpType(property.PropertyType, isNullable));
                Property prop = new Property();
                prop.Nullable = isNullable;
                prop.ReadOnly = IsReadOnly(property); //TODO read this from attribute from reference object
                prop.SerializedName = GetSerializedName(property.Name);
                prop.Summary = $"Gets{GetPropertySummary(setter)} {property.Name}";
                prop.Required = IsRequired(property);
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

        private string GetSerializedName(string name)
        {
            if (name.Equals("ResourceType", StringComparison.Ordinal))
                return "type";
            return ToCamelCase(name);
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return BuildInitializationConstructor();
            yield return BuildSerializationConstructor();
        }

        private bool IsReadOnly(PropertyInfo property)
        {
            if (property.Name == "Tags")
                return false;
            return property.GetSetMethod() == null;
        }

        private bool IsRequired(PropertyInfo property)
        {
            var publicCtor = property.DeclaringType?.GetConstructors().Where(c => c.IsPublic).OrderBy(c => c.GetParameters().Count()).FirstOrDefault();
            if (publicCtor == null)
            {
                // ReferenceTypes for inheritance do not have public constructors, and currently there are ResourceData and TrackedResourceData.
                // The properties that are optional for matching should be treated as optional.
                var attributeObj = property.DeclaringType!.GetCustomAttributes()?.Where(a => a.GetType().Name == InheritanceChooser.ReferenceAttributeName).First();
                var optionalPropertiesForMatch = new HashSet<string>((attributeObj?.GetType().GetProperty(InheritanceChooser.OptionalPropertiesName)?.GetValue(attributeObj) as string[])!);
                if (optionalPropertiesForMatch.Contains(property.Name))
                    return false;
                // We treat Id, Name, ResourceType as required although the swagger definition does not set them as required.
                // This leaves Tags as the only remaining optional property.
                if (property.Name == "Tags")
                    return false;
                return true;
            }
            return publicCtor.GetParameters().Any(param => param.Name?.Equals(property.Name, StringComparison.OrdinalIgnoreCase) == true && param.GetType() == property.GetType());
        }

        private bool IsNullable(Type type)
        {
            if (type == null)
                return true; // obvious
            if (!type.IsValueType)
                return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null)
                return true; // Nullable<T>
            return false; // value-type
        }

        private string GetPropertySummary(MethodInfo? setter)
        {
            return setter != null ? " or sets" : string.Empty;
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor() => BuildConstructor(GetCtor(ReferenceClassFinder.SerializationCtorAttributeName));

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType == null || _type.BaseType == typeof(object) ? null : CSharpType.FromSystemType(Context, _type.BaseType);
        }

        protected override string CreateDescription()
        {
            throw new NotImplementedException("Currently we don't support getting description in SystemObjectType");
        }
    }
}
