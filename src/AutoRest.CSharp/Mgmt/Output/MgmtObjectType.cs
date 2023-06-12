// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

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

        private HashSet<string?> GetParentSchemaPropertyNames()
            => EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.SchemaProperty?.Language.Default.Name)
                .ToHashSet();

        /// <summary>
        /// Returns the schema propeties that should be generated for this model, properties on parent model excluded
        /// We need this method instead of just call `ObjectSchema.Properties` because in mgmt plane, we may replace the base object type with types from Azure.ResourceManager, therefore the current base type might not come from the base schema.
        /// Therefore there might be properties that are not included in the base object type, and we need to include them here.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Property> GetSchemaProperties()
        {
            var existingProperties = GetParentSchemaPropertyNames();
            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (var property in objectSchema.Properties!)
                {
                    if (existingProperties.Contains(property.Language.Default.Name))
                    {
                        continue;
                    }

                    yield return property;
                }
            }
        }

        protected override IObjectTypeFields<Property> EnsureFields()
        {
            return new SchemaObjectTypeFields(Type, GetSchemaProperties(), _usage, MgmtContext.Context.TypeFactory, MgmtContext.Context.SourceInputModel?.CreateForModel(ExistingType));
        }

        private IEnumerable<ObjectTypeProperty> AllProperties
        {
            get
            {
                ObjectType? objectType = this;
                while (objectType != null)
                {
                    foreach (var property in objectType.Properties)
                    {
                        yield return property;
                    }
                    objectType = objectType.GetBaseObjectType();
                }
            }
        }

        protected override ConstructorSignature EnsurePublicConstructorSignature()
        {
            var signature = base.EnsurePublicConstructorSignature();

            var properties = AllProperties.ToDictionary(
                property => property.Declaration.Name.ToVariableName(),
                property => property);
            var parameters = signature.Parameters.ToArray();
            bool changed = false;
            // apply the replaced types
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var property = properties[parameter.Name];
                var inputType = TypeFactory.GetInputType(property.Declaration.Type);
                if (!inputType.Equals(parameter.Type))
                {
                    changed = true;
                    parameters[i] = parameter with
                    {
                        Type = property.Declaration.Type
                    };
                }
            }
            return !changed ? signature : signature with
            {
                Parameters = parameters
            };
        }

        protected override ConstructorSignature EnsureSerializationConstructorSignature()
        {
            var signature = base.EnsureSerializationConstructorSignature();

            var properties = AllProperties.ToDictionary(
                property => property.Declaration.Name.ToVariableName(),
                property => property);
            var parameters = signature.Parameters.ToArray();
            bool changed = false;
            // apply the replaced types
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var property = properties[parameter.Name];
                if (!property.Declaration.Type.Equals(parameter.Type))
                {
                    changed = true;
                    parameters[i] = parameter with
                    {
                        Type = property.Declaration.Type
                    };
                }
            }
            return !changed ? signature : signature with
            {
                Parameters = parameters
            };
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var parentProperties = GetParentPropertyNames();
            foreach (var property in base.BuildProperties())
            {
                if (!parentProperties.Contains(property.Declaration.Name))
                {
                    var newProperty = CreatePropertyType(property);
                    // check if the type of this property is "single property type"
                    if (IsSinglePropertyObject(newProperty))
                    {
                        newProperty = newProperty.MarkFlatten();
                    }
                    yield return newProperty;
                }
            }
        }

        private static bool IsSinglePropertyObject(ObjectTypeProperty property)
        {
            if (!property.Declaration.Type.TryCast<ObjectType>(out var objType))
                return false;

            return objType switch
            {
                SystemObjectType systemObjectType => HandleSystemObjectType(systemObjectType),
                SchemaObjectType schemaObjectType => HandleSchemaObjectType(schemaObjectType),
                _ => throw new InvalidOperationException($"Unhandled case {objType.GetType()} for property {property.Declaration.Type} {property.Declaration.Name}")
            };
        }

        private static bool HandleSchemaObjectType(SchemaObjectType objType)
        {
            if (objType.Discriminator != null)
                return false;

            if (objType.AdditionalPropertiesProperty != null)
                return false;

            // we cannot use the EnumerateHierarchy method because we are calling this when we are building that
            var properties = objType.GetCombinedSchemas().SelectMany(obj => obj.Properties);
            return properties.Count() == 1;
        }

        private static bool HandleSystemObjectType(SystemObjectType objType)
        {
            var properties = objType.EnumerateHierarchy().SelectMany(obj => obj.Properties);
            return properties.Count() == 1;
        }

        private IEnumerable<ObjectTypeProperty> BuildMyProperties()
        {
            foreach (var objectSchema in GetCombinedSchemas())
            {
                var fields = new SchemaObjectTypeFields(Type, objectSchema.Properties, _usage, MgmtContext.Context.TypeFactory, MgmtContext.Context.SourceInputModel?.CreateForModel(ExistingType));
                foreach (var field in fields)
                    yield return new ObjectTypeProperty(field, fields.GetInputByField(field), this, field.SerializationFormat);
            }
        }

        protected virtual ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            if (objectTypeProperty.ValueType.IsFrameworkType && objectTypeProperty.ValueType.FrameworkType.IsGenericType)
            {
                for (int i = 0; i < objectTypeProperty.ValueType.Arguments.Length; i++)
                {
                    var argType = objectTypeProperty.ValueType.Arguments[i];
                    if (argType.TryCast<MgmtObjectType>(out var typeToReplace))
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
                if (objectTypeProperty.ValueType.TryCast<MgmtObjectType>(out var typeToReplace))
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
                    if (inheritedType.TryCast<SchemaObjectType>(out var schemaObjectType) && IsDescendantOf(schemaObjectType))
                    {
                        // if the base type has a discriminator and this type is one of them
                        return inheritedType;
                    }
                }
            }

            // try to replace the base type if this is not a type from discriminator
            // try exact match first
            if (inheritedType != null && inheritedType.TryCast<MgmtObjectType>(out var typeToReplace))
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
            return ObjectSchema.CreateDescription();
        }
    }
}
