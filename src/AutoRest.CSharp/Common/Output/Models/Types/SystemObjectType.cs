// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SystemObjectType : ObjectType
    {
        private static ConcurrentDictionary<Type, SystemObjectType> _typeCache = new ConcurrentDictionary<Type, SystemObjectType>();

        public static SystemObjectType Create(Type type, string defaultNamespace, SourceInputModel? sourceInputModel)
        {
            if (_typeCache.TryGetValue(type, out var result))
                return result;

            result = new SystemObjectType(type, defaultNamespace, sourceInputModel);
            _typeCache.TryAdd(type, result);
            return result;
        }

        private readonly Type _type;

        private SystemObjectType(Type type, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
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

        public override bool IncludeConverter => false;

        internal static bool TryGetCtor(Type type, string attributeType, [MaybeNullWhen(false)] out ConstructorInfo result)
        {
            foreach (var ctor in type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
                if (ctor.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name == attributeType) != null)
                {
                    result = ctor;
                    return true;
                }
            }

            result = null;
            return false;
        }

        private static ConstructorInfo GetCtor(Type type, string attributeType)
        {
            if (TryGetCtor(type, attributeType, out var ctor))
                return ctor;

            throw new InvalidOperationException($"{attributeType} ctor was not found for {type.Name}");
        }

        private static Type? GetSerializeAs(Type type) => type.Name switch
        {
            _ when type == typeof(ResourceIdentifier) => type,
            _ when type == typeof(SystemData) => type,
            _ => null,
        };

        private static string GetNameWithoutGeneric(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;

            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        private ObjectTypeConstructor BuildConstructor(ConstructorInfo ctor, ObjectTypeConstructor? baseConstructor)
        {
            var parameters = ctor.GetParameters()
                .Select(param => new Parameter(ToCamelCase(param.Name!), $"The {param.Name}", new CSharpType(param.ParameterType), null, ValidationType.None, null))
                .ToArray();

            // we should only add initializers when there is a corresponding parameter
            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var autoRestProperty in Properties)
            {
                if (parameters.Any(parameter => parameter.Name == autoRestProperty.Declaration.Name.ToVariableName()))
                {
                    Reference reference = new Reference(ToCamelCase(autoRestProperty.Declaration.Name), autoRestProperty.ValueType);
                    initializers.Add(new ObjectPropertyInitializer(autoRestProperty, reference));
                }
            }

            var modifiers = ctor.IsFamily ? Protected : Public;

            return new ObjectTypeConstructor(DefaultName, modifiers, parameters, initializers.ToArray(), baseConstructor);
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor()
            => BuildConstructor(GetCtor(_type, ReferenceClassFinder.InitializationCtorAttributeName), GetBaseObjectType()?.InitializationConstructor);

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var internalPropertiesToInclude = new List<PropertyInfo>();
            PropertyMatchDetection.AddInternalIncludes(_type, internalPropertiesToInclude);

            foreach (var property in _type.GetProperties().Where(p => p.DeclaringType == _type).Concat(internalPropertiesToInclude))
            {
                var getter = property.GetGetMethod();
                var setter = property.GetSetMethod();
                var isNullable = IsNullable(property.PropertyType);
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter != null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    new CSharpType(property.PropertyType, isNullable));
                Property prop = new Property()
                {
                    Nullable = isNullable,
                    ReadOnly = property.IsReadOnly(),
                    SerializedName = GetSerializedName(property.Name),
                    Summary = $"Gets{GetPropertySummary(setter)} {property.Name}",
                    Required = IsRequired(property),
                    Language = new Languages()
                    {
                        Default = new Language() { Name = property.Name },
                    }
                };

                //We are only handling a small subset of cases because the set of reference types used from Azure.ResourceManager is known
                //If in the future we add more types which have unique cases we might need to update this code, but it will be obvious
                //given that the generation will fail with the new types
                if (TypeFactory.IsDictionary(property.PropertyType))
                {
                    prop.Schema = new DictionarySchema()
                    {
                        Type = AllSchemaTypes.Dictionary
                    };
                }

                yield return new ObjectTypeProperty(memberDeclarationOptions, prop.Summary, prop.IsReadOnly, prop, new CSharpType(property.PropertyType, GetSerializeAs(property.PropertyType)));
            }
        }

        private string GetSerializedName(string name)
        {
            var dict = ReferenceClassFinder.GetPropertyMetadata(SystemType);

            return dict[name].SerializedName;
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return BuildInitializationConstructor();
            yield return BuildSerializationConstructor();
        }

        private bool IsRequired(PropertyInfo property)
        {
            var dict = ReferenceClassFinder.GetPropertyMetadata(SystemType);

            return dict[property.Name].Required;
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

        protected override ObjectTypeConstructor BuildSerializationConstructor()
            => BuildConstructor(GetCtor(_type, ReferenceClassFinder.SerializationCtorAttributeName), GetBaseObjectType()?.SerializationConstructor);

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType == null || _type.BaseType == typeof(object) ? null : CSharpType.FromSystemType(_type.BaseType, base.DefaultNamespace, _sourceInputModel);
        }

        protected override string CreateDescription()
        {
            throw new NotImplementedException("Currently we don't support getting description in SystemObjectType");
        }
    }
}
