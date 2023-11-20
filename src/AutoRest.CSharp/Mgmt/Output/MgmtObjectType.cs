// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : SchemaObjectType
    {
        private ObjectTypeProperty[]? _myProperties;

        public MgmtObjectType(MgmtOutputLibrary library, InputModelType inputModelType, TypeFactory typeFactory, SourceInputModel? sourceInputModel, string? name = default, string? nameSpace = default, string? newName = default, SerializableObjectType? defaultDerivedType = null)
            : base(library, inputModelType, typeFactory, sourceInputModel, newName, defaultDerivedType)
        {
            _typeFactory = typeFactory;
            _defaultName = name;
            _defaultNamespace = nameSpace;
        }

        protected virtual bool IsResourceType => false;
        private readonly TypeFactory _typeFactory;
        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= GetDefaultName(InputModel, IsResourceType);
        private string? _defaultNamespace;
        protected override string DefaultNamespace => _defaultNamespace ??= GetDefaultNamespace(InputModel, IsResourceType);

        internal ObjectTypeProperty[] MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        private static string GetDefaultName(InputModelType inputModelType, bool isResourceType)
        {
            var name = inputModelType.Name;
            return isResourceType ? name + "Data" : name;
        }

        private static string GetDefaultNamespace(InputModelType inputModelType, bool isResourceType)
        {
            return isResourceType ? Configuration.Namespace : GetDefaultNamespace(inputModelType.Namespace);
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
            var parentProperties = GetParentPropertyNames();
            foreach (var property in base.BuildProperties())
            {
                if (!parentProperties.Contains(property.Declaration.Name))
                {
                    var propertyType = CreatePropertyType(property);
                    // check if the type of this property is "single property type"
                    if (IsSinglePropertyObject(propertyType))
                    {
                        propertyType = propertyType.MarkFlatten();
                    }
                    yield return propertyType;
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
                SchemaObjectType schemaObjectType => HandleMgmtObjectType(schemaObjectType),
                _ => throw new InvalidOperationException($"Unhandled case {objType.GetType()} for property {property.Declaration.Type} {property.Declaration.Name}")
            };
        }

        private static bool HandleMgmtObjectType(SchemaObjectType objType)
        {
            // TODO: this is cauing circular reference
            //if (objType.Discriminator != null)
            //    return false;
            if (objType.AdditionalPropertiesProperty != null)
                return false;

            // we cannot use the EnumerateHierarchy method because we are calling this when we are building that
            var properties = objType.GetCombinedSchemas().SelectMany(obj => obj.Properties);
            return properties.Count() == 1;
        }

        private static bool HandleSystemObjectType(SystemObjectType objType)
        {
            var properties = objType.EnumerateHierarchy().SelectMany(obj => obj.Properties).ToArray();

            // only bother flattening if the single property is public
            return properties.Length == 1 && properties[0].Declaration.Accessibility == "public";
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
                    if (argType.TryCast<MgmtObjectType>(out var typeToReplace))
                    {
                        var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace, _sourceInputModel);
                        if (match != null)
                        {
                            string fullSerializedName = GetFullSerializedName(objectTypeProperty, i);
                            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                                new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                               fullSerializedName,
                                "ReplacePropertyType", typeToReplace.Declaration.FullName, $"{match.Namespace}.{match.Name}");
                            objectTypeProperty.ValueType.Arguments[i] = match;
                        }
                    }
                }
                return objectTypeProperty;
            }
            else
            {
                ObjectTypeProperty propertyType = objectTypeProperty;
                if (objectTypeProperty.ValueType.TryCast<MgmtObjectType>(out var typeToReplace))
                {
                    var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace, _sourceInputModel);
                    if (match != null)
                    {
                        propertyType = ReferenceTypePropertyChooser.GetObjectTypeProperty(objectTypeProperty, match);
                        string fullSerializedName = GetFullSerializedName(objectTypeProperty);
                        MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                            new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                           fullSerializedName,
                            "ReplacePropertyType", typeToReplace.Declaration.FullName, $"{match.Namespace}.{match.Name}");
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
            return Configuration.MgmtConfiguration.NoPropertyTypeReplacement.Contains(Type.Name);
        }

        private bool IsDescendantOf(SchemaObjectType schemaObjectType)
        {
            if (schemaObjectType.Discriminator == null)
                return false;
            var descendantTypes = schemaObjectType.Discriminator.Implementations.Select(implementation => implementation.Type).ToHashSet();

            // We need this redundant check as the internal backing schema will not be a part of the discriminator implementations of its base type.
            if (InputModel.DiscriminatorValue == "Unknown" &&
                InputModel.DerivedModels.Count == 1 &&
                InputModel.DerivedModels.First().Equals(schemaObjectType.InputModel))
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
                if (_typeFactory.TryCreateType(ExistingType.BaseType, ShouldIncludeArmCoreType, out var existingBaseType))
                {
                    // if we could find a type and it is not a framework type meaning that it is a TypeProvider, return that
                    if (!existingBaseType.IsFrameworkType)
                        return existingBaseType;
                    // if it is a framework type, first we check if it is System.Object. Since it is base type for everything, we would not want it to override anything in our code
                    if (!existingBaseType.Equals(typeof(object)))
                    {
                        // we cannot directly return the FrameworkType here, we need to wrap it inside the SystemObjectType
                        // in order to let the constructor builder have the ability to get base constructor
                        return CSharpType.FromSystemType(_sourceInputModel, existingBaseType.FrameworkType);
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
            var typeToReplace = inheritedType?.Implementation as MgmtObjectType;
            if (typeToReplace != null)
            {
                var match = InheritanceChooser.GetExactMatch(typeToReplace, typeToReplace.MyProperties, _sourceInputModel);
                if (match != null)
                {
                    string fullSerializedName = GetFullSerializedName();
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplaceBaseType, fullSerializedName),
                        fullSerializedName,
                        "ReplaceBaseTypeByExactMatch", inheritedType?.GetNameForReport() ?? "<no base type>", match.GetNameForReport());
                    inheritedType = match;
                }
            }

            // try superset match because our superset match is checking the proper superset
            var supersetBaseType = InheritanceChooser.GetSupersetMatch(this, MyProperties, _sourceInputModel);
            if (supersetBaseType != null)
            {
                string fullSerializedName = GetFullSerializedName();
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.ReplaceBaseType, fullSerializedName),
                    fullSerializedName,
                    "ReplaceBaseTypeBySupersetMatch", inheritedType?.GetNameForReport() ?? "<no base type>", supersetBaseType.GetNameForReport());
                inheritedType = supersetBaseType;
            }

            return inheritedType;
        }

        protected CSharpType? CreateInheritedTypeWithNoExtraMatch()
        {
            return base.CreateInheritedType();
        }

        protected override FormattableString CreateDescription()
        {
            return $"{InputModel.Description}";
        }

        internal string GetFullSerializedName()
        {
            return InputModel.Name;
        }

        internal string GetFullSerializedName(InputModelProperty property)
        {
            var parentSchema = GetCombinedSchemas().FirstOrDefault(s => s.Properties.Contains(property));
            if (parentSchema == null)
            {
                throw new InvalidOperationException($"Can't find parent object schema for property schema: '{Declaration.Name}.{property.CSharpName()}'");
            }
            else
            {
                return parentSchema.GetFullSerializedName(property);
            }
        }

        internal string GetFullSerializedName(ObjectTypeProperty otProperty)
        {
            if (otProperty.InputModelProperty != null)
                return GetFullSerializedName(otProperty.InputModelProperty);
            else
                return $"{GetFullSerializedName()}.{otProperty.Declaration.Name}";
        }

        internal string GetFullSerializedName(ObjectTypeProperty otProperty, int argumentIndex)
        {
            if (otProperty.ValueType.Arguments == null || otProperty.ValueType.Arguments.Length <= argumentIndex)
                throw new ArgumentException("argumentIndex out of range");
            var argType = otProperty.ValueType.Arguments[argumentIndex];
            return $"{GetFullSerializedName(otProperty)}.Arguments[{argumentIndex}-{argType.Namespace}.{argType.Name}]";
        }
    }
}
