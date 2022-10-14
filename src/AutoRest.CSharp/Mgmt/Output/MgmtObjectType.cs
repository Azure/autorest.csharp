﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : SchemaObjectType
    {
        private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(ObjectSchema objectSchema)
            : this(objectSchema, default, default)
        {
        }

        public MgmtObjectType(ObjectSchema objectSchema, string? name = default, string? nameSpace = default)
            : base(objectSchema, MgmtContext.Context)
        {
            _defaultName = name;
            _defaultNamespace = nameSpace;
        }

        protected virtual bool IsResourceType => false;
        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= GetDefaultName(ObjectSchema, IsResourceType);
        private string? _defaultNamespace;
        protected override string DefaultNamespace => _defaultNamespace ??= GetDefaultNamespace(MgmtContext.Context, ObjectSchema, IsResourceType);

        internal ObjectTypeProperty[] MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        protected override bool IsAbstract => base.IsAbstract || BackingSchema != null;

        private ObjectSchema? _backingSchema;
        public ObjectSchema? BackingSchema => _backingSchema ??= BuildBackingSchema();

        private static string GetDefaultName(ObjectSchema objectSchema, bool isResourceType)
        {
            var name = objectSchema.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        private static string GetDefaultNamespace(BuildContext context, Schema objectSchema, bool isResourceType)
        {
            return isResourceType ? context.DefaultNamespace : GetDefaultNamespace(objectSchema.Extensions?.Namespace, context);
        }

        private HashSet<string> GetParentPropertyNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.Declaration.Name)
                .ToHashSet();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            List<ObjectTypeProperty> objTypeProperties = new List<ObjectTypeProperty>();
            var parentProperties = GetParentPropertyNames();
            foreach (var property in base.BuildProperties())
            {
                if (!parentProperties.Contains(property.Declaration.Name))
                {
                    var propertyType = UpdatePropertyDescription(CreatePropertyType(property));
                    yield return propertyType;
                }
            }
        }

        private IEnumerable<ObjectTypeProperty> BuildMyProperties()
        {
            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (var property in objectSchema.Properties)
                {
                    yield return CreateProperty(property);
                }
            }
        }

        protected virtual ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            if (objectTypeProperty.ValueType.IsFrameworkType && objectTypeProperty.ValueType.FrameworkType.IsGenericType)
            {
                for (int i = 0; i < objectTypeProperty.ValueType.Arguments.Length; i++)
                {
                    var argType = objectTypeProperty.ValueType.Arguments[i];
                    var typeToReplace = argType.IsFrameworkType ? null : argType.Implementation as MgmtObjectType;
                    if (typeToReplace != null)
                    {
                        var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
                        objectTypeProperty.ValueType.Arguments[i] = match ?? argType;
                    }
                }
                return objectTypeProperty;
            }
            else
            {
                ObjectTypeProperty propertyType = objectTypeProperty;
                var typeToReplace = objectTypeProperty.ValueType?.IsFrameworkType == false ? objectTypeProperty.ValueType.Implementation as MgmtObjectType : null;
                if (typeToReplace != null)
                {
                    var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
                    if (match != null)
                    {
                        propertyType = ReferenceTypePropertyChooser.GetObjectTypeProperty(objectTypeProperty, match);
                    }
                }
                return propertyType;
            }
        }

        /// <summary>
        /// Check whether this type should be replaced when used as property type.
        /// </summary>
        /// <returns>true if this type should NOT be replaced when used as property type; false elsewise</returns>
        public bool ShouldNotReplaceForProperty()
        {
            return Configuration.MgmtConfiguration.NoPropertyTypeReplacement.Contains(this.Type.Name);
        }

        private bool IsDescendantOf(SchemaObjectType schemaObjectType)
        {
            if (schemaObjectType.Discriminator == null)
                return false;
            var descendantTypes = schemaObjectType.Discriminator.Implementations.Select(implementation => implementation.Type).ToHashSet();

            // We need this redundant check as the internal backing schema will not be a part of the discriminator implementations of its base type.
            if (ObjectSchema.DiscriminatorValue == "Unknown" &&
                ObjectSchema.Parents?.All.Count == 1 &&
                ObjectSchema.Parents.All.First().Equals(schemaObjectType.ObjectSchema))
            {
                descendantTypes.Add(Type);
            }

            return descendantTypes.Contains(Type);
        }

        private static bool ShouldIncludeArmCoreType(Type type)
        {
            return SystemObjectType.TryGetCtor(type, ReferenceClassFinder.InitializationCtorAttributeName, out _);
        }

        protected override CSharpType? CreateInheritedType()
        {
            // find from the customized code to see if we already have this type defined with a base class
            if (ExistingType != null && ExistingType.BaseType != null)
            {
                // if this type is defined with a base class, we have to use the same base class here
                // otherwise the compiler will throw an error
                if (MgmtContext.Context.TypeFactory.TryCreateType(ExistingType.BaseType, ShouldIncludeArmCoreType, out var existingBaseType))
                {
                    // if we could find a type and it is not a framework type meaning that it is a TypeProvider, return that
                    if (!existingBaseType.IsFrameworkType)
                        return existingBaseType;
                    // if it is a framework type, first we check if it is System.Object. Since it is base type for everything, we would not want it to override anything in our code
                    if (!existingBaseType.Equals(typeof(object)))
                    {
                        // we cannot directly return the FrameworkType here, we need to wrap it inside the SystemObjectType
                        // in order to let the constructor builder have the ability to get base constructor
                        return CSharpType.FromSystemType(MgmtContext.Context, existingBaseType.FrameworkType);
                    }
                }
                // if we did not find that type, this means the customization code is referencing something unrecognized
                // or the customization code is not specifying a base type
            }
            CSharpType? inheritedType = base.CreateInheritedType();
            if (inheritedType != null)
            {
                if (inheritedType.IsFrameworkType)
                    return inheritedType;
                else
                {
                    // if the base type is a TypeProvider, we need to make sure if it is a discriminator provider
                    // by checking if this type is one of its descendants
                    var baseTypeProvider = inheritedType.Implementation;
                    if (baseTypeProvider is SchemaObjectType schemaObjectType && IsDescendantOf(schemaObjectType))
                    {
                        // if the base type has a discriminator and this type is one of them
                        return inheritedType;
                    }
                }
            }

            // try to replace the base type if this is not a type from discriminator
            // try exact match first
            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChooser.GetExactMatch(typeToReplace, typeToReplace.MyProperties);
                if (match != null)
                {
                    inheritedType = match;
                }
            }

            // try superset match because our superset match is checking the proper superset
            var supersetBaseType = InheritanceChooser.GetSupersetMatch(this, MyProperties);
            if (supersetBaseType != null)
                inheritedType = supersetBaseType;

            return inheritedType;
        }

        protected CSharpType? CreateInheritedTypeWithNoExtraMatch()
        {
            return base.CreateInheritedType();
        }

        public override ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                if (Inherits?.Implementation is SystemObjectType)
                {
                    return GetPropertyBySerializedName(property.SerializedName, includeParents);
                }
                throw new InvalidOperationException($"Unable to find object property for schema property '{property.SerializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        protected override string CreateDescription()
        {
            return ObjectSchema.CreateDescription() + CreateExtraDescriptionWithDiscriminator();
        }

        public static readonly List<string> DiscriminatorDescFixedPart = new List<string> { "Please note ",
            " is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.",
            "The available derived classes include " };

        protected virtual string CreateExtraDescriptionWithDiscriminator()
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

        private ObjectTypeProperty UpdatePropertyDescription(ObjectTypeProperty property)
        {
            CSharpType type = property.ValueType;
            string updatedDescription = string.Empty;
            if (type.IsFrameworkType)
            {
                if (TypeFactory.IsList(type))
                {
                    if (!type.Arguments.First().IsFrameworkType && type.Arguments.First().Implementation is MgmtObjectType objectType)
                    {
                        updatedDescription = objectType.CreateExtraDescriptionWithDiscriminator();
                    }
                }
                else if (TypeFactory.IsDictionary(type))
                {
                    var objectTypes = type.Arguments.Where(arg => !arg.IsFrameworkType && arg.Implementation is MgmtObjectType);
                    if (objectTypes.Count() > 0)
                    {
                        var subDescription = objectTypes.Select(o => ((MgmtObjectType)o.Implementation).CreateExtraDescriptionWithDiscriminator());
                        updatedDescription = string.Join("", subDescription);
                    }
                }
            }
            else if (type.Implementation is MgmtObjectType objectType)
            {
                updatedDescription = objectType.CreateExtraDescriptionWithDiscriminator();
            }
            return updatedDescription.IsNullOrEmpty() ? property :
                new ObjectTypeProperty(property.Declaration,
                property.Description + updatedDescription,
                property.IsReadOnly,
                property.SchemaProperty,
                property.ValueType,
                property.OptionalViaNullability);
        }

        private ObjectSchema? BuildBackingSchema()
        {
            if (ObjectSchema.Discriminator?.All != null && ObjectSchema.Parents?.All.Count == 0 && !Configuration.MgmtConfiguration.SuppressAbstractBaseClass.Contains(DefaultName))
            {
                return BuildInternalBackingSchema();
            }
            else
            {
                return null;
            }
        }

        private ObjectSchema BuildInternalBackingSchema()
        {
            // TODO: Avoid potential duplicated schema name and discriminator value.
            // Note: When this Todo is done, the method IsDescendantOf also needs to be updated.
            // Reason:
            // Here we just hard coded the name and discriminator value for the internal backing schema.
            // This could work now, but there are also potential duplicate conflict issue.
            var schema = new ObjectSchema
            {
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = "Unknown" + ObjectSchema.Language.Default.Name
                    }
                },
                Parents = new Relations
                {
                    All = { ObjectSchema },
                    Immediate = { ObjectSchema }
                },
                DiscriminatorValue = "Unknown",
                SerializationFormats = { KnownMediaType.Json }
            };
            ICollection<string> usages = ObjectSchema.Usage.Select(u => u.ToString()).ToList();
            usages.Add("Model");
            schema.Extensions = new RecordOfStringAndAny { { "x-csharp-usage", string.Join(',', usages) }, { "x-ms-skip-init-ctor", true } };
            return schema;
        }
    }
}
