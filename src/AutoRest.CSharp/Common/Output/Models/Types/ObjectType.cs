// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class ObjectType : TypeProvider
    {
        private ObjectTypeConstructor[]? _constructors;
        private ObjectTypeProperty[]? _properties;
        private CSharpType? _inheritsType;
        private ObjectTypeConstructor? _serializationConstructor;
        private ObjectTypeConstructor? _initializationConstructor;
        private FormattableString? _description;
        private ObjectTypeDiscriminator? _discriminator;

        protected ObjectType(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
        }

        public bool IsStruct => ExistingType?.IsValueType ?? false;
        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();
        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();
        public ObjectTypeConstructor SerializationConstructor => _serializationConstructor ??= BuildSerializationConstructor();
        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public ObjectTypeConstructor InitializationConstructor => _initializationConstructor ??= BuildInitializationConstructor();

        public FormattableString Description => _description ??= $"{CreateDescription()}{CreateExtraDescriptionWithDiscriminator()}";
        public abstract ObjectTypeProperty? AdditionalPropertiesProperty { get; }
        protected abstract ObjectTypeConstructor BuildInitializationConstructor();
        protected abstract ObjectTypeConstructor BuildSerializationConstructor();
        protected abstract CSharpType? CreateInheritedType();
        protected abstract IEnumerable<ObjectTypeProperty> BuildProperties();
        protected abstract FormattableString CreateDescription();

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

        protected abstract IEnumerable<ObjectTypeConstructor> BuildConstructors();

        public ObjectType? GetBaseObjectType()
            => Inherits is { IsFrameworkType: false, Implementation: ObjectType objectType } ? objectType : null;

        protected virtual ObjectTypeDiscriminator? BuildDiscriminator()
        {
            return null;
        }

        public static readonly List<string> DiscriminatorDescFixedPart = new List<string> { "Please note ",
            " is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.",
            "The available derived classes include " };

        public string CreateExtraDescriptionWithDiscriminator()
        {
            if (Discriminator?.HasDescendants != true)
            {
                return string.Empty;
            }

            var childrenList = string.Join(", ", Discriminator.Implementations.Select(implementation => $"<see cref=\"global::{implementation.Type.Namespace}.{implementation.Type.ToStringForDocs()}\"/>")).ReplaceLast(", ", " and ");
            return $"{System.Environment.NewLine}{DiscriminatorDescFixedPart[0]}<see cref=\"global::{Type.Namespace}.{Type.ToStringForDocs()}\"/>{DiscriminatorDescFixedPart[1]}{System.Environment.NewLine}{DiscriminatorDescFixedPart[2]}{childrenList}.";
        }
    }
}
