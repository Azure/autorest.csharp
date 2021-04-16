// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class ObjectType : TypeProvider
    {
        private ObjectTypeConstructor[]? _constructors;
        protected ObjectTypeProperty[]? _properties;
        private CSharpType? _inheritsType;
        private ObjectTypeConstructor? _serializationConstructor;
        private CSharpType? _implementsDictionaryType;
        private ObjectTypeConstructor? _initializationConstructor;
        private ObjectSerialization[]? _serializations;
        private ObjectTypeDiscriminator? _discriminator;

        public ObjectType(BuildContext context) : base(context)
        {
        }

        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();
        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();
        public virtual CSharpType? Inherits => _inheritsType ??= CreateInheritedType();
        public ObjectTypeConstructor? SerializationConstructor => _serializationConstructor ??= BuildSerializationConstructor();
        public CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();
        public ObjectTypeConstructor InitializationConstructor => _initializationConstructor ??= BuildInitializationConstructor();
        public ObjectSerialization[] Serializations => _serializations ??= BuildSerializations();
        public bool IsStruct => ExistingType?.IsValueType == true;
        public virtual string? Description { get; protected set; }
        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public abstract bool IncludeSerializer { get; }
        public abstract bool IncludeDeserializer { get; }
        public abstract bool IncludeConverter { get; }
        public abstract ObjectTypeProperty? AdditionalPropertiesProperty { get; }
        protected abstract ObjectTypeDiscriminator? BuildDiscriminator();
        protected abstract ObjectSerialization[] BuildSerializations();
        protected abstract ObjectTypeConstructor BuildInitializationConstructor();
        protected abstract CSharpType? CreateInheritedDictionaryType();
        protected abstract ObjectTypeConstructor? BuildSerializationConstructor();
        protected abstract CSharpType? CreateInheritedType();
        protected abstract IEnumerable<ObjectTypeProperty> BuildProperties();

        public IEnumerable<ObjectType> EnumerateHierarchy()
        {
            ObjectType? type = this;
            while (type != null)
            {
                yield return type;

                if (type.Inherits?.IsFrameworkType == false && type.Inherits.Implementation is ObjectType o)
                {
                    type = o;
                }
                else
                {
                    type = null;
                }
            }
        }

        protected IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
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

        public ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {DefaultName}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name {serializedName} in schema {DefaultName}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyForGroupedParameter(RequestParameter groupedParameter, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(
                p => (p.SchemaProperty as GroupProperty)?.OriginalParameter.Contains(groupedParameter) == true,
                out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for grouped parameter {groupedParameter.Language.Default.Name} in schema {DefaultName}");
            }

            return objectProperty;
        }

        private bool TryGetPropertyForSchemaProperty(Func<ObjectTypeProperty, bool> propertySelector, [NotNullWhen(true)] out ObjectTypeProperty? objectProperty, bool includeParents = false)
        {
            objectProperty = null;

            foreach (var type in EnumerateHierarchy())
            {
                objectProperty = type.Properties.SingleOrDefault(propertySelector);
                if (objectProperty != null || !includeParents)
                {
                    break;
                }
            }

            return objectProperty != null;
        }
    }
}
