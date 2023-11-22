// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;

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
        private IEnumerable<Method>? _methods;
        private ObjectTypeDiscriminator? _discriminator;

        protected ObjectType(BuildContext context)
            : base(context)
        {
        }

        protected ObjectType(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
        }

        public bool IsUnknownDerivedType { get; protected init; }
        public bool IsPropertyBag { get; protected init; }
        public bool IsStruct => ExistingType?.IsValueType ?? false;
        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();
        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();
        public ObjectTypeConstructor SerializationConstructor => _serializationConstructor ??= BuildSerializationConstructor();
        public IEnumerable<Method> Methods => _methods ??= BuildMethods();
        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public ObjectTypeConstructor InitializationConstructor => _initializationConstructor ??= BuildInitializationConstructor();

        public FormattableString Description => _description ??= $"{CreateDescription()}{CreateExtraDescriptionWithDiscriminator()}";
        public abstract ObjectTypeProperty? AdditionalPropertiesProperty { get; }
        protected abstract ObjectTypeConstructor BuildInitializationConstructor();
        protected abstract ObjectTypeConstructor BuildSerializationConstructor();
        protected abstract CSharpType? CreateInheritedType();
        protected abstract IEnumerable<ObjectTypeProperty> BuildProperties();
        protected abstract FormattableString CreateDescription();
        public abstract bool IncludeConverter { get; }

        protected virtual IEnumerable<Method> BuildMethods()
        {
            return Array.Empty<Method>();
        }

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

        protected ObjectType? GetBaseObjectType()
            => Inherits is { IsFrameworkType: false, Implementation: ObjectType objectType } ? objectType : null;

        protected virtual ObjectTypeDiscriminator? BuildDiscriminator()
        {
            return null;
        }

        public static readonly IReadOnlyList<string> DiscriminatorDescFixedPart = new List<string> { "Please note ",
            " is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.",
            "The available derived classes include " };

        public virtual FormattableString CreateExtraDescriptionWithDiscriminator()
        {
            if (Discriminator?.HasDescendants == true)
            {
                List<FormattableString> childrenList = new List<FormattableString>();
                foreach (var implementation in Discriminator.Implementations)
                {
                    // when the base type is public and the implementation type is not public, we skip it
                    if (Type.IsPublic && !implementation.Type.IsPublic)
                        continue;
                    childrenList.Add($"{implementation.Type:C}");
                }
                return $"{Environment.NewLine}{DiscriminatorDescFixedPart[0]}{Type:C}{DiscriminatorDescFixedPart[1]}{Environment.NewLine}{DiscriminatorDescFixedPart[2]}{childrenList.Join(", ", " and ")}.";
            }
            return $"";
        }
    }
}
