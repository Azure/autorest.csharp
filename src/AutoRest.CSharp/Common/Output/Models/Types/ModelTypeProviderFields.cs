// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProviderFields : IReadOnlyCollection<FieldDeclaration>
    {
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<FieldDeclaration, InputModelProperty> _fieldsToInputs;
        // parameter name should be unique since it's bound to field property
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public IReadOnlyList<Parameter> PublicConstructorParameters { get; }
        public IReadOnlyList<Parameter> SerializationParameters { get; }
        public int Count => _fields.Count;
        public FieldDeclaration? AdditionalProperties { get; }

        public ModelTypeProviderFields(IReadOnlyList<InputModelProperty> properties, string modelName, InputModelTypeUsage inputModelUsage, TypeFactory typeFactory, ModelTypeMapping? sourceTypeMapping, InputDictionaryType? additionalPropertiesType, bool isStruct, bool isPropertyBag, bool hasBaseModel)
        {
            var fields = new List<FieldDeclaration>();
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            var visitedMembers = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
            foreach (var inputModelProperty in properties)
            {
                var originalFieldName = Configuration.Generation1ConvenienceClient
                    ? inputModelProperty.Name == "null" ? "NullProperty" : inputModelProperty.Name.ToCleanName()
                    : inputModelProperty.Name.ToCleanName();

                originalFieldName = BuilderHelpers.DisambiguateName(modelName, originalFieldName);
                var existingMember = sourceTypeMapping?.GetMemberByOriginalName(originalFieldName);
                if (existingMember is not null)
                {
                    visitedMembers.Add(existingMember);
                    if (hasBaseModel && existingMember.ContainingType.Name != modelName)
                    {
                        // Member defined in a base type, don't generate parameters for it
                        continue;
                    }
                }

                var propertyType = GetPropertyDefaultType(inputModelUsage, inputModelProperty, typeFactory);

                // We represent property being optional by making it nullable (when it is a value type)
                // Except in the case of collection where there is a special handling
                var optionalViaNullability = inputModelProperty is { IsRequired: false, Type.IsNullable: false } &&
                                             !TypeFactory.IsCollectionType(propertyType);

                var serialization = sourceTypeMapping?.GetForMemberSerialization(existingMember);
                if (optionalViaNullability)
                {
                    propertyType = propertyType.WithNullable(true);
                }

                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, serialization, propertyType, GetPropertyDefaultValue(propertyType, inputModelProperty), typeFactory, inputModelProperty.IsRequired, optionalViaNullability)
                    : CreateField(originalFieldName, propertyType, inputModelUsage, inputModelProperty, isStruct, isPropertyBag, optionalViaNullability);

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameterName = field.Name.ToVariableName();
                var parameterValidation = GetParameterValidation(field, inputModelProperty);

                var parameter = new Parameter(parameterName, BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Description), field.Type, null, parameterValidation, null);
                parametersToFields[parameter.Name] = field;
                // all properties should be included in the serialization ctor
                serializationParameters.Add(parameter with { Validation = Validation.None });

                // for classes, only required + not readonly + not property with constant value + not discriminator could get into the public ctor
                // for structs, all properties must be set in public constructor
                if (isStruct || inputModelProperty is { IsRequired: true, IsDiscriminator: false, ConstantValue: null })
                {
                    if (Configuration.Generation1ConvenienceClient || !inputModelProperty.IsReadOnly)
                    {
                        publicParameters.Add(parameter with { Type = TypeFactory.GetInputType(parameter.Type) });
                    }
                }
            }

            if (additionalPropertiesType is not null)
            {
                // We use a $ prefix here as AdditionalProperties comes from a swagger concept
                // and not a swagger model/operation name to disambiguate from a possible property with
                // the same name.
                var existingMember = sourceTypeMapping?.GetMemberByOriginalName("$AdditionalProperties");

                var type = typeFactory.CreateType(additionalPropertiesType);
                if (!inputModelUsage.HasFlag(InputModelTypeUsage.Input))
                {
                    type = TypeFactory.GetOutputType(type);
                }

                var name = existingMember is null ? "AdditionalProperties" : existingMember.Name;
                var declaration = new CodeWriterDeclaration(name);
                declaration.SetActualName(name);

                var accessModifiers = existingMember is null ? Public : GetAccessModifiers(existingMember);

                var additionalPropertiesField = new FieldDeclaration($"Additional Properties", accessModifiers | ReadOnly, type, declaration, null, false, true);
                var additionalPropertiesParameter = new Parameter(name.ToVariableName(), "Additional Properties", type, null, Validation.None, null);

                fields.Add(additionalPropertiesField);
                serializationParameters.Add(additionalPropertiesParameter);
                if (isStruct)
                {
                    publicParameters.Add(additionalPropertiesParameter with {Validation = Validation.AssertNotNull});
                }

                parametersToFields[additionalPropertiesParameter.Name] = additionalPropertiesField;

                AdditionalProperties = additionalPropertiesField;
            }

            // adding the leftover members from the source type
            if (sourceTypeMapping is not null)
            {
                foreach (var serializationMapping in sourceTypeMapping.GetSerializationMembers())
                {
                    if (visitedMembers.Contains(serializationMapping.ExistingMember))
                    {
                        continue;
                    }

                    // since the property doesn't exist in the input type, we use type of existing member both as original and field type
                    // the serialization will be generated for this type and it might has issues if the type is not recognized properly.
                    // but customer could always use the `CodeGenMemberSerializationHooks` attribute to override those incorrect serialization/deserialization code.
                    var originalType = BuilderHelpers.GetTypeFromExisting(serializationMapping.ExistingMember, typeof(object), typeFactory);
                    var field = CreateFieldFromExisting(serializationMapping.ExistingMember, serializationMapping, originalType, null, typeFactory, false, false);
                    var parameter = new Parameter(field.Name.ToVariableName(), "to be removed by post process", field.Type, null, Validation.None, null);

                    fields.Add(field);
                    serializationParameters.Add(parameter);
                }
            }

            _fields = fields;
            _fieldsToInputs = fieldsToInputs;
            _parameterNamesToFields = parametersToFields;

            PublicConstructorParameters = publicParameters;
            SerializationParameters = serializationParameters;
        }

        private static Validation GetParameterValidation(FieldDeclaration field, InputModelProperty inputModelProperty)
        {
            // we do not validate a parameter when it is a value type (struct or int, etc)
            if (field.Type.IsValueType)
            {
                return Validation.None;
            }

            // or it is readonly in DPG (in Legacy Data Plane readonly property require validation)
            if (inputModelProperty.IsReadOnly && !Configuration.Generation1ConvenienceClient)
            {
                return Validation.None;
            }

            // or it is optional
            if (!field.IsRequired)
            {
                return Validation.None;
            }

            // or it it nullable
            if (field.Type.IsNullable)
            {
                return Validation.None;
            }

            return Validation.AssertNotNull;
        }

        public FieldDeclaration? GetFieldByParameterName(string name) => _parameterNamesToFields.TryGetValue(name, out var fieldDeclaration) ? fieldDeclaration : null;
        public InputModelProperty? GetInputByField(FieldDeclaration field) => _fieldsToInputs.TryGetValue(field, out var property) ? property : null;

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static FieldDeclaration CreateField(string fieldName, CSharpType originalType, InputModelTypeUsage usage, InputModelProperty inputModelProperty, bool isStruct, bool isPropertyBag, bool optionalViaNullability)
        {
            var propertyIsDiscriminator = inputModelProperty.IsDiscriminator;
            FieldModifiers fieldModifiers;
            FieldModifiers? setterModifiers = null;
            if (propertyIsDiscriminator)
            {
                fieldModifiers = Configuration.PublicDiscriminatorProperty ? Public : Internal;
                setterModifiers = Configuration.PublicDiscriminatorProperty ? Internal | Protected : null;
            }
            else
            {
                fieldModifiers = Public;
            }

            if (PropertyIsReadOnly(inputModelProperty, usage, originalType, isStruct, isPropertyBag))
            {
                fieldModifiers |= ReadOnly;
            }

            var declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration(
                FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Description)),
                fieldModifiers,
                originalType,
                declaration,
                GetPropertyDefaultValue(originalType, inputModelProperty),
                inputModelProperty.IsRequired,
                OptionalViaNullability: optionalViaNullability,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static bool PropertyIsReadOnly(InputModelProperty property, InputModelTypeUsage usage, CSharpType type, bool isStruct, bool isPropertyBag)
        {
            if (property.IsDiscriminator)
            {
                // discriminator properties should be writable because we need to set values to the discriminators in the public ctor of derived classes.
                return false;
            }

            // a property will not have setter when it is readonly
            if (property.IsReadOnly)
            {
                return true;
            }

            // structs must have all their properties set in constructor
            if (isStruct)
            {
                return true;
            }

            // structs must have all their properties set in constructor
            if (!usage.HasFlag(InputModelTypeUsage.Input))
            {
                return true;
            }

            if (property.ConstantValue is not null && property.IsRequired) // a property will not have setter when it is required literal type
            {
                return true;
            }

            if (TypeFactory.IsCollectionType(type))
            {
                // nullable collection should be settable
                // one exception is in the property bag, we never let them to be settable.
                return !property.Type.IsNullable || isPropertyBag;
            }

            // In mixed models required properties are not readonly
            return property.IsRequired && usage.HasFlag(InputModelTypeUsage.Input) && !usage.HasFlag(InputModelTypeUsage.Output);
        }


        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, SourcePropertySerializationMapping? serialization, CSharpType originalType, FormattableString? defaultValue, TypeFactory typeFactory, bool isRequired, bool optionalViaNullability)
        {
            var fieldType = BuilderHelpers.GetTypeFromExisting(existingMember, originalType, typeFactory);
            var fieldModifiers = GetAccessModifiers(existingMember);
            if (IsReadOnly(existingMember))
            {
                fieldModifiers |= ReadOnly;
            }

            var writeAsProperty = existingMember is IPropertySymbol;
            var declaration = new CodeWriterDeclaration(existingMember.Name);
            declaration.SetActualName(existingMember.Name);

            return new FieldDeclaration(
                Description: $"Must be removed by post-generation processing,",
                Modifiers: fieldModifiers,
                Type: fieldType,
                Declaration: declaration,
                DefaultValue: defaultValue,
                IsRequired: isRequired,
                WriteAsProperty: writeAsProperty,
                OptionalViaNullability: optionalViaNullability,
                SerializationMapping: serialization);
        }

        private static FieldModifiers GetAccessModifiers(ISymbol existingMember) => existingMember.DeclaredAccessibility switch
        {
            Accessibility.Public => Public,
            Accessibility.Protected => Protected,
            Accessibility.Internal => Internal,
            Accessibility.Private => Private,
            _ => throw new ArgumentOutOfRangeException(existingMember.Name)
        };

        private static FormattableString? GetPropertyDefaultValue(CSharpType originalType, InputModelProperty inputModelProperty)
            => inputModelProperty.ConstantValue is {} constant && !originalType.IsNullable
                ? BuilderHelpers.ParseConstant(constant.Value, originalType).GetConstantFormattable()
                : null;

        private static bool IsReadOnly(ISymbol existingMember) => existingMember switch
        {
            IPropertySymbol propertySymbol => propertySymbol.SetMethod == null,
            IFieldSymbol fieldSymbol => fieldSymbol.IsReadOnly,
            _ => throw new NotSupportedException($"'{existingMember.ContainingType.Name}.{existingMember.Name}' must be either field or property.")
        };

        private static CSharpType GetPropertyDefaultType(in InputModelTypeUsage usage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var propertyType = typeFactory.CreateType(property.Type);

            if (!usage.HasFlag(InputModelTypeUsage.Input) || property.IsReadOnly)
            {
                propertyType = TypeFactory.GetOutputType(propertyType);
            }

            return propertyType;
        }
    }
}
