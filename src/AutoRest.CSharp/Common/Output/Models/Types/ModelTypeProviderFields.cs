// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
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

        public ModelTypeProviderFields(InputModelType inputModel, TypeFactory typeFactory, ModelTypeMapping? sourceTypeMapping, bool isStruct)
        {
            var fields = new List<FieldDeclaration>();
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            var visitedMembers = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
            foreach (var inputModelProperty in inputModel.Properties)
            {
                var originalFieldName = Configuration.Generation1ConvenienceClient
                    ? inputModelProperty.Name == "null" ? "NullProperty" : inputModelProperty.Name.ToCleanName()
                    : inputModelProperty.Name.ToCleanName();

                var propertyType = GetPropertyDefaultType(inputModel.Usage, inputModelProperty, typeFactory);

                // We represent property being optional by making it nullable (when it is a value type)
                // Except in the case of collection where there is a special handling
                var optionalViaNullability = !inputModelProperty.IsRequired &&
                                             !inputModelProperty.Type.IsNullable &&
                                             !TypeFactory.IsCollectionType(propertyType);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var serialization = sourceTypeMapping?.GetForMemberSerialization(existingMember);
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, serialization, propertyType, inputModelProperty, typeFactory, optionalViaNullability)
                    : CreateField(originalFieldName, propertyType, inputModel, inputModelProperty, optionalViaNullability);

                if (existingMember is not null)
                {
                    visitedMembers.Add(existingMember);
                }

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameter = Parameter.FromModelProperty(inputModelProperty, existingMember is IFieldSymbol ? inputModelProperty.Name.ToVariableName() : field.Name.ToVariableName(), field.Type);
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

            if (inputModel.InheritedDictionaryType is {} additionalPropertiesType)
            {
                // We use a $ prefix here as AdditionalProperties comes from a swagger concept
                // and not a swagger model/operation name to disambiguate from a possible property with
                // the same name.
                var existingMember = sourceTypeMapping?.GetForMember("$AdditionalProperties")?.ExistingMember;

                var type = typeFactory.CreateType(additionalPropertiesType);
                if (!inputModel.Usage.HasFlag(InputModelTypeUsage.Input))
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
                    var isReadOnly = IsReadOnly(serializationMapping.ExistingMember);
                    var name = serializationMapping.ExistingMember.Name;
                    var inputModelProperty = new InputModelProperty(name, serializationMapping.SerializationPath?.Last() ?? name, "to be removed by post process", InputPrimitiveType.Object, null, false, isReadOnly, false);
                    // we put the original type typeof(object) here as fallback. We do not really care about what type we get here, just to ensure there is a type generated
                    // therefore the top type here is reasonable
                    // the serialization will be generated for this type and it might has issues if the type is not recognized properly.
                    // but customer could always use the `CodeGenMemberSerializationHooks` attribute to override those incorrect serialization/deserialization code.
                    var field = CreateFieldFromExisting(serializationMapping.ExistingMember, serializationMapping, typeof(object), inputModelProperty, typeFactory, false);
                    fields.Add(field);
                    fieldsToInputs[field] = inputModelProperty;
                    serializationParameters.Add(Parameter.FromModelProperty(inputModelProperty, field.Name.FirstCharToLowerCase(), field.Type));
                }
            }

            _fields = fields;
            _fieldsToInputs = fieldsToInputs;
            _parameterNamesToFields = parametersToFields;

            PublicConstructorParameters = publicParameters;
            SerializationParameters = serializationParameters;
        }

        public FieldDeclaration? GetFieldByParameterName(string name) => _parameterNamesToFields.TryGetValue(name, out var fieldDeclaration) ? fieldDeclaration : null;
        public InputModelProperty? GetInputByField(FieldDeclaration field) => _fieldsToInputs.TryGetValue(field, out var property) ? property : null;

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static FieldDeclaration CreateField(string fieldName, CSharpType originalType, InputModelType inputModel, InputModelProperty inputModelProperty, bool optionalViaNullability)
        {
            var propertyIsCollection = inputModelProperty.Type is InputDictionaryType or InputListType or
                // This is a temporary work around as we don't convert collection type to InputListType or InputDictionaryType in MPG for now
                CodeModelType { Schema: ArraySchema or DictionarySchema };

            var propertyIsRequiredInNonRoundTripModel = inputModel.Usage is InputModelTypeUsage.Input or InputModelTypeUsage.Output && inputModelProperty.IsRequired;
            var propertyIsOptionalInOutputModel = inputModel.Usage is InputModelTypeUsage.Output && !inputModelProperty.IsRequired;
            var propertyIsConstant = inputModelProperty.ConstantValue is not null;
            var propertyIsDiscriminator = inputModelProperty.IsDiscriminator;

            var propertyShouldOmitSetter = !propertyIsDiscriminator && // if a property is a discriminator, it should always has its setter
                (inputModelProperty.IsReadOnly || // a property will not have setter when it is readonly
                (!inputModel.Usage.HasFlag(InputModelTypeUsage.Input) && Configuration.Generation1ConvenienceClient) || // In Legacy DataPlane, non-input models have read-only properties
                (propertyIsConstant && inputModelProperty.IsRequired) || // a property will not have setter when it is required literal type
                propertyIsCollection || // a property will not have setter when it is a collection
                propertyIsRequiredInNonRoundTripModel || // a property will explicitly omit its setter when it is useless
                propertyIsOptionalInOutputModel); // a property will explicitly omit its setter when it is useless

            if (optionalViaNullability)
            {
                originalType = originalType.WithNullable(true);
            }

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

            if (propertyShouldOmitSetter)
            {
                fieldModifiers |= ReadOnly;
            }

            var declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration(
                $"{BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Description)}",
                fieldModifiers,
                originalType,
                declaration,
                GetPropertyDefaultValue(originalType, inputModelProperty),
                inputModelProperty.IsRequired,
                OptionalViaNullability: optionalViaNullability,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, SourcePropertySerializationMapping? serialization, CSharpType originalType, InputModelProperty inputModelProperty, TypeFactory typeFactory, bool optionalViaNullability)
        {
            if (optionalViaNullability)
            {
                originalType = originalType.WithNullable(true);
            }

            var fieldType = BuilderHelpers.GetTypeFromExisting(existingMember, originalType, typeFactory);
            var fieldModifiers = GetAccessModifiers(existingMember);

            var writeAsProperty = existingMember is IPropertySymbol;
            var declaration = new CodeWriterDeclaration(existingMember.Name);
            declaration.SetActualName(existingMember.Name);

            return new FieldDeclaration(
                Description: $"Must be removed by post-generation processing,",
                Modifiers: fieldModifiers,
                Type: fieldType,
                Declaration: declaration,
                DefaultValue: GetPropertyDefaultValue(originalType, inputModelProperty),
                IsRequired: inputModelProperty.IsRequired,
                WriteAsProperty: writeAsProperty,
                OptionalViaNullability: optionalViaNullability,
                SerializationMapping: serialization);
        }

        private static FieldModifiers GetAccessModifiers(ISymbol existingMember) => existingMember.DeclaredAccessibility switch
        {
            Accessibility.Public => Public,
            Accessibility.Internal => Internal,
            Accessibility.Private => Private,
            _ => throw new ArgumentOutOfRangeException()
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
