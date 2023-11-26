// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
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

        public static SystemObjectType Create(Type type, string defaultNamespace, SourceInputModel? sourceInputModel, IEnumerable<ObjectTypeProperty>? backingProperties = null)
        {
            if (_typeCache.TryGetValue(type, out var result))
                return result;

            result = new SystemObjectType(type, defaultNamespace, sourceInputModel, backingProperties);
            _typeCache.TryAdd(type, result);
            return result;
        }

        private readonly Type _type;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly IReadOnlyDictionary<string, ObjectTypeProperty> _backingProperties;

        private SystemObjectType(Type type, string defaultNamespace, SourceInputModel? sourceInputModel, IEnumerable<ObjectTypeProperty>? backingProperties) : base(defaultNamespace, sourceInputModel)
        {
            _type = type;
            _sourceInputModel = sourceInputModel;
            DefaultName = GetNameWithoutGeneric(type);
            _backingProperties = backingProperties?.ToDictionary(p => p.Declaration.Name) ?? new Dictionary<string, ObjectTypeProperty>();
        }

        protected override string DefaultName { get; }
        protected override string DefaultNamespace => _type.Namespace ?? base.DefaultNamespace;

        public override ObjectTypeProperty? AdditionalPropertiesProperty => null;

        internal override Type? SerializeAs => GetSerializeAs(_type);

        protected override string DefaultAccessibility { get; } = "public";

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
            var parameters = new List<Parameter>();
            foreach (var param in ctor.GetParameters())
            {
                _backingProperties.TryGetValue(param.Name!.ToCleanName(), out var backingProperty);
                var parameter = new Parameter(param.Name!, FormattableStringHelpers.FromString(backingProperty?.Description) ?? $"The {param.Name}", new CSharpType(param.ParameterType), null, ValidationType.None, null);
                parameters.Add(parameter);
            }

            // we should only add initializers when there is a corresponding parameter
            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            foreach (var property in Properties)
            {
                var parameter = parameters.FirstOrDefault(p => p.Name == property.Declaration.Name.ToVariableName());
                if (parameter is not null)
                {
                    initializers.Add(new ObjectPropertyInitializer(property, parameter));
                }
            }

            var modifiers = ctor.IsFamily ? Protected : Public;

            return new ObjectTypeConstructor(Type, modifiers, parameters, initializers.ToArray(), baseConstructor);
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor()
            => BuildConstructor(GetCtor(_type, ReferenceClassFinder.InitializationCtorAttributeName), GetBaseObjectType()?.InitializationConstructor);

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var internalPropertiesToInclude = new List<PropertyInfo>();
            PropertyMatchDetection.AddInternalIncludes(_type, internalPropertiesToInclude);

            foreach (var property in _type.GetProperties().Where(p => p.DeclaringType == _type).Concat(internalPropertiesToInclude))
            {
                // try to get the backing property if any
                _backingProperties.TryGetValue(property.Name, out var backingProperty);

                // construct the property
                var getter = property.GetMethod;
                var setter = property.SetMethod;
                var isNullable = IsNullable(property.PropertyType);
                MemberDeclarationOptions memberDeclarationOptions = new MemberDeclarationOptions(
                    getter != null && getter.IsPublic ? "public" : "internal",
                    property.Name,
                    new CSharpType(property.PropertyType, isNullable));
                Property schemaProperty;
                if (backingProperty?.SchemaProperty is not null)
                {
                    schemaProperty = backingProperty.SchemaProperty;
                }
                else
                {
                    schemaProperty = new Property()
                    {
                        Nullable = isNullable,
                        ReadOnly = property.IsReadOnly(),
                        SerializedName = GetSerializedName(property.Name, SystemType),
                        Summary = GetPropertySummary(setter != null, property.Name),
                        Required = IsRequired(property, SystemType),
                        Language = new Languages()
                        {
                            Default = new Language() { Name = property.Name },
                        }
                    };
                    //We are only handling a small subset of cases because the set of reference types used from Azure.ResourceManager is known
                    //If in the future we add more types which have unique cases we might need to update this code, but it will be obvious
                    //given that the generation will fail with the new types
                    if (TypeFactory.IsList(property.PropertyType))
                    {
                        schemaProperty.Schema = new ArraySchema()
                        {
                            Type = AllSchemaTypes.Array
                        };
                    }
                    if (TypeFactory.IsDictionary(property.PropertyType))
                    {
                        schemaProperty.Schema = new DictionarySchema()
                        {
                            Type = AllSchemaTypes.Dictionary
                        };
                    }
                }

                yield return new ObjectTypeProperty(memberDeclarationOptions, schemaProperty.Summary!, schemaProperty.IsReadOnly, schemaProperty, new CSharpType(property.PropertyType, GetSerializeAs(property.PropertyType)));
            }

            static bool IsNullable(Type type)
            {
                if (type == null)
                    return true; // obvious
                if (type.IsClass)
                    return true; // classes are nullable
                if (Nullable.GetUnderlyingType(type) != null)
                    return true; // Nullable<T>
                return false; // value-type
            }

            static bool IsRequired(PropertyInfo property, Type systemType)
            {
                var dict = ReferenceClassFinder.GetPropertyMetadata(systemType);

                return dict[property.Name].Required;
            }

            static string GetPropertySummary(bool hasSetter, string name)
            {
                var builder = new StringBuilder("Gets ");
                if (hasSetter)
                    builder.Append("or sets ");
                builder.Append(name);
                return builder.ToString();
            }

            static string GetSerializedName(string name, Type systemType)
            {
                var dict = ReferenceClassFinder.GetPropertyMetadata(systemType);

                return dict[name].SerializedName;
            }
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return BuildInitializationConstructor();
            yield return BuildSerializationConstructor();
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
            => BuildConstructor(GetCtor(_type, ReferenceClassFinder.SerializationCtorAttributeName), GetBaseObjectType()?.SerializationConstructor);

        protected override CSharpType? CreateInheritedType()
        {
            return _type.BaseType == null || _type.BaseType == typeof(object) ? null : CSharpType.FromSystemType(_type.BaseType, base.DefaultNamespace, _sourceInputModel);
        }

        protected override FormattableString CreateDescription()
        {
            throw new NotImplementedException("Currently we don't support getting description in SystemObjectType");
        }
    }
}
