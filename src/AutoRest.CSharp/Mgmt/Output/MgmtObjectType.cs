// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtObjectType : SchemaObjectType
    {
        private IReadOnlyList<ObjectTypeProperty>? _myProperties;

        public MgmtObjectType(InputModelType inputModel, SerializableObjectType? defaultDerivedType = null)
            : base(inputModel, Configuration.Namespace, MgmtContext.TypeFactory, MgmtContext.Context.SourceInputModel, defaultDerivedType)
        {
        }

        protected virtual bool IsResourceType => false;
        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= GetDefaultName(InputModel, IsResourceType);
        private string? _defaultNamespace;
        protected override string DefaultNamespace => _defaultNamespace ??= GetDefaultNamespace(MgmtContext.Context, IsResourceType);

        internal IReadOnlyList<ObjectTypeProperty> MyProperties => _myProperties ??= BuildMyProperties().ToArray();

        private static string GetDefaultName(InputModelType inputModel, bool isResourceType)
        {
            var name = inputModel.CSharpName();
            return isResourceType ? name + "Data" : name;
        }

        private static string GetDefaultNamespace(BuildContext context, bool isResourceType)
        {
            return isResourceType ? context.DefaultNamespace : GetDefaultModelNamespace(null, context.DefaultNamespace);
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
            if (property.Declaration.Type is not { IsFrameworkType: false, Implementation: ObjectType objType })
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
            if (objType.Discriminator != null)
                return false;

            if (objType.AdditionalPropertiesProperty != null)
                return false;

            // we cannot use the EnumerateHierarchy method because we are calling this when we are building that
            var properties = objType.InputModel.GetSelfAndBaseModels().SelectMany(obj => obj.Properties).Select(x => x.Name).Distinct();
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
            foreach (var model in InputModel.GetSelfAndBaseModels())
            {
                foreach (var property in model.Properties)
                {
                    yield return CreateProperty(property);
                }
            }
        }

        protected virtual ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            var type = objectTypeProperty.ValueType;
            if (type is { IsFrameworkType: true, FrameworkType: { } frameworkType } && frameworkType.IsGenericType)
            {
                var arguments = new CSharpType[type.Arguments.Count];
                bool shouldReplace = false;
                for (int i = 0; i < type.Arguments.Count; i++)
                {
                    var argType = type.Arguments[i];
                    arguments[i] = argType;
                    if (argType is { IsFrameworkType: false, Implementation: MgmtObjectType typeToReplace })
                    {
                        var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
                        if (match != null)
                        {
                            shouldReplace = true;
                            string fullSerializedName = this.GetFullSerializedName(objectTypeProperty, i);
                            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                                new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                                fullSerializedName,
                                "ReplacePropertyType", typeToReplace.Declaration.FullName, $"{match.Namespace}.{match.Name}");
                            arguments[i] = match;
                        }
                    }
                }
                if (shouldReplace)
                {
                    var newType = new CSharpType(frameworkType.GetGenericTypeDefinition(), type.IsNullable, arguments);
                    return new ObjectTypeProperty(
                        new MemberDeclarationOptions(objectTypeProperty.Declaration.Accessibility, objectTypeProperty.Declaration.Name, newType),
                        objectTypeProperty.Description,
                        objectTypeProperty.IsReadOnly,
                        objectTypeProperty.InputModelProperty
                    );
                }
                return objectTypeProperty;
            }
            else
            {
                ObjectTypeProperty property = objectTypeProperty;
                if (type is { IsFrameworkType: false, Implementation: MgmtObjectType typeToReplace })
                {
                    var match = ReferenceTypePropertyChooser.GetExactMatch(typeToReplace);
                    if (match != null)
                    {
                        property = ReferenceTypePropertyChooser.GetObjectTypeProperty(objectTypeProperty, match);
                        string fullSerializedName = this.GetFullSerializedName(objectTypeProperty);
                        MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                            new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                           fullSerializedName,
                            "ReplacePropertyType", typeToReplace.Declaration.FullName, $"{match.Namespace}.{match.Name}");
                    }
                }
                return property;
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
            if (InputModel.IsUnknownDiscriminatorModel && InputModel.BaseModel == schemaObjectType.InputModel)
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
                    if (inheritedType is { IsFrameworkType: false, Implementation: SchemaObjectType schemaObjectType } && IsDescendantOf(schemaObjectType))
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
                    string fullSerializedName = this.GetFullSerializedName();
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplaceBaseType, fullSerializedName),
                        fullSerializedName,
                        "ReplaceBaseTypeByExactMatch", inheritedType?.GetNameForReport() ?? "<no base type>", match.GetNameForReport());
                    inheritedType = match;
                }
            }

            // try superset match because our superset match is checking the proper superset
            var supersetBaseType = InheritanceChooser.GetSupersetMatch(this, MyProperties);
            if (supersetBaseType != null)
            {
                string fullSerializedName = this.GetFullSerializedName();
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

        public override ObjectTypeProperty GetPropertyForSchemaProperty(InputModelProperty property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.InputModelProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                if (Inherits?.Implementation is SystemObjectType)
                {
                    return GetPropertyBySerializedName(property.SerializedName, includeParents);
                }
                throw new InvalidOperationException($"Unable to find object property for schema property '{property.SerializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        protected override FormattableString CreateDescription()
        {
            return $"{InputModel.Description}";
        }

        internal string GetFullSerializedName()
        {
            return this.InputModel.GetFullSerializedName();
        }

        internal string GetFullSerializedName(InputModelProperty property)
        {
            var parentSchema = InputModel.GetSelfAndBaseModels().FirstOrDefault(s => s.Properties.Contains(property));
            if (parentSchema == null)
            {
                throw new InvalidOperationException($"Can't find parent object schema for property schema: '{this.Declaration.Name}.{property.CSharpName()}'");
            }
            else
            {
                return parentSchema.GetFullSerializedName(property);
            }
        }

        internal string GetFullSerializedName(ObjectTypeProperty otProperty)
        {
            if (otProperty.InputModelProperty != null)
                return this.GetFullSerializedName(otProperty.InputModelProperty);
            else
                return $"{this.GetFullSerializedName()}.{otProperty.Declaration.Name}";
        }

        internal string GetFullSerializedName(ObjectTypeProperty otProperty, int argumentIndex)
        {
            if (otProperty.ValueType.Arguments == null || otProperty.ValueType.Arguments.Count <= argumentIndex)
                throw new ArgumentException("argumentIndex out of range");
            var argType = otProperty.ValueType.Arguments[argumentIndex];
            return $"{this.GetFullSerializedName(otProperty)}.Arguments[{argumentIndex}-{argType.Namespace}.{argType.Name}]";
        }
    }
}
