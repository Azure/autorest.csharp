// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class ObjectType : TypeProvider
    {
        private ObjectTypeConstructor[]? _constructors;
        private ObjectTypeProperty[]? _properties;
        private CSharpType? _inheritsType;
        private ObjectTypeConstructor? _serializationConstructor;
        private ObjectTypeConstructor? _initializationConstructor;
        private string? _description;
        private IEnumerable<ModelMethodDefinition>? _methods;
        private ObjectTypeDiscriminator? _discriminator;

        protected ObjectType(BuildContext context)
            : base(context)
        {
        }

        protected ObjectType(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
        }

        private bool? isUnknownDerivedType;
        public bool IsUnknownDerivedType => isUnknownDerivedType ??= EnsureUnknownDerivedType();
        public bool EnsureUnknownDerivedType()
        {
            if (!Type.Equals(Discriminator?.DefaultObjectType?.Type))
                return false;

            if (!Declaration.Name.StartsWith("Unknown", StringComparison.Ordinal))
                return false;

            return true;
        }

        private bool? _isBaseClass;
        public bool IsBaseClass => _isBaseClass ??= (Inherits is null && HasSubClasses()) || Discriminator is not null && IsDiscriminatorBase(Discriminator.DefaultObjectType);
        protected abstract bool HasSubClasses();

        private ObjectTypeProperty? _rawDataProperty;
        public ObjectTypeProperty? RawDataProperty => _rawDataProperty ??= EnsureRawDataProperty();

        private Parameter? _rawDataParam;
        public Parameter? RawDataParam => _rawDataParam ??= EnsureRawDataParam();

        public bool IsStruct => ExistingType?.IsValueType ?? false;
        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructorsCore().ToArray();

        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();
        public ObjectTypeConstructor SerializationConstructor => _serializationConstructor ??= BuildSerializationConstructor();
        public IEnumerable<ModelMethodDefinition> Methods => _methods ??= BuildMethods();
        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        private bool? _isPropertyBag;
        public bool IsPropertyBag => _isPropertyBag ??= EnsurePropertyBag();

        public ObjectTypeConstructor InitializationConstructor => _initializationConstructor ??= BuildInitializationConstructor();

        public string? Description => _description ??= CreateDescription() + CreateExtraDescriptionWithDiscriminator();
        public abstract ObjectTypeProperty? AdditionalPropertiesProperty { get; }
        protected abstract ObjectTypeConstructor BuildInitializationConstructor();
        protected abstract ObjectTypeConstructor BuildSerializationConstructor();
        protected abstract CSharpType? CreateInheritedType();
        protected abstract IEnumerable<ObjectTypeProperty> BuildProperties();
        protected abstract string CreateDescription();
        public abstract bool IncludeConverter { get; }

        protected virtual bool EnsurePropertyBag() => false;

        protected virtual IEnumerable<ModelMethodDefinition> BuildMethods()
        {
            return Array.Empty<ModelMethodDefinition>();
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

        private IEnumerable<ObjectTypeConstructor> BuildConstructorsCore()
        {
            bool hasEmptyCtor = false;
            foreach (var constructor in BuildConstructors())
            {
                hasEmptyCtor |= constructor.Signature.Parameters.Count == 0;
                yield return constructor;
            }

            if (!hasEmptyCtor && !IsStruct && !GetType().Equals(typeof(SystemObjectType)))
                yield return ObjectTypeConstructor.GetDefaultInternalConstructor(Type);
        }

        protected ObjectType? GetBaseObjectType()
            => Inherits is { IsFrameworkType: false, Implementation: ObjectType objectType } ? objectType : null;

        protected virtual ObjectTypeDiscriminator? BuildDiscriminator()
        {
            return null;
        }

        public static readonly List<string> DiscriminatorDescFixedPart = new List<string> { "Please note ",
            " is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.",
            "The available derived classes include " };

        public virtual string CreateExtraDescriptionWithDiscriminator()
        {
            if (Discriminator?.HasDescendants == true)
            {
                List<FormattableString> childrenList = new List<FormattableString>();
                foreach (var implementation in Discriminator.Implementations)
                {
                    childrenList.Add($"<see cref=\"{implementation.Type.Implementation.Type.Name}\"/>");
                }
                return $"{System.Environment.NewLine}{DiscriminatorDescFixedPart[0]}<see cref=\"{Type.Name}\"/>{DiscriminatorDescFixedPart[1]}" +
                    $"{System.Environment.NewLine}{DiscriminatorDescFixedPart[2]}{FormattableStringHelpers.Join(childrenList, ", ", " and ")}.";
            }
            return string.Empty;
        }

        private bool? _hasRawDataInHeirarchy;
        public bool HasRawDataInHeirarchy => _hasRawDataInHeirarchy ??= EnsureHasRawDataInHeirarchy();

        private bool EnsureHasRawDataInHeirarchy()
        {
            foreach (var objectType in EnumerateHierarchy())
            {
                if (objectType.RawDataParam is not null)
                    return true;
            }
            return false;
        }

        private ObjectTypeProperty? EnsureRawDataProperty()
        {
            if (!ShouldHaveRawData())
                return null;

            var accessor = IsBaseClass && !IsStruct ? "protected internal" : "private";
            if (IsStruct)
                accessor += " readonly";

            return ObjectTypeProperty.GetRawDataWithAccessor(accessor);
        }

        private Parameter? EnsureRawDataParam()
        {
            if (!ShouldHaveRawData())
                return null;

            return Parameter.RawData;
        }

        private bool ShouldHaveRawData()
        {
            if (IsPropertyBag)
                return false;

            if (!(IsBaseClass && Inherits is null) && (Inherits is not null && !Inherits.IsFrameworkType && Inherits.Implementation is not SystemObjectType))
                return false;

            if (AdditionalPropertiesProperty is not null)
                return false;

            return true;
        }

        protected bool IsDiscriminatorBase(ObjectType? defaultDerivedType)
        {
            if (defaultDerivedType is null || defaultDerivedType.Type.IsFrameworkType)
                return false;

            if (defaultDerivedType.Type.Implementation is not ObjectType objectType)
                return false;

            if (objectType.Inherits is null)
                return false;

            if (objectType.Inherits.IsFrameworkType)
                return false;

            if (objectType.Inherits.Implementation is not ObjectType baseObjectType)
                return false;

            return baseObjectType.Type.Equals(Type);
        }
    }
}
