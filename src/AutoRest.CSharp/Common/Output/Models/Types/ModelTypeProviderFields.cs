// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
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

        public ModelTypeProviderFields(IReadOnlyList<InputModelProperty> properties, string modelName, InputModelTypeUsage inputModelUsage, TypeFactory typeFactory, ModelTypeMapping? modelTypeMapping, InputType? additionalPropertiesValueType, bool isStruct, bool isPropertyBag)
        {
            var fields = new List<FieldDeclaration>();
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            var visitedMembers = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
            foreach (var inputModelProperty in properties)
            {
                var originalFieldName = BuilderHelpers.DisambiguateName(modelName, inputModelProperty.Name.ToCleanName(), "Property");
                var propertyType = GetPropertyDefaultType(inputModelUsage, inputModelProperty, typeFactory);

                // We represent property being optional by making it nullable (when it is a value type)
                // Except in the case of collection where there is a special handling
                var optionalViaNullability = inputModelProperty is { IsRequired: false} && inputModelProperty.Type is not InputNullableType &&
                                             !propertyType.IsCollection;

                var existingMember = modelTypeMapping?.GetMemberByOriginalName(originalFieldName);
                var serializationFormat = SerializationBuilder.GetSerializationFormat(inputModelProperty.Type);
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, propertyType, GetPropertyInitializationValue(propertyType, inputModelProperty), serializationFormat, typeFactory, inputModelProperty.IsRequired, optionalViaNullability)
                    : CreateField(originalFieldName, propertyType, inputModelUsage, inputModelProperty, isStruct, isPropertyBag, optionalViaNullability);

                if (existingMember is not null)
                {
                    visitedMembers.Add(existingMember);
                }

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameterName = field.Name.ToVariableName();
                var parameterValidation = GetParameterValidation(field, inputModelProperty);
                var parameter = new Parameter(
                    Name: parameterName,
                    Description: FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Description)),
                    Type: field.Type,
                    DefaultValue: null,
                    Validation: parameterValidation,
                    Initializer: null);
                parametersToFields[parameter.Name] = field;
                // all properties should be included in the serialization ctor
                serializationParameters.Add(parameter with { Validation = ValidationType.None });

                // for classes, only required + not readonly + not constant + not discriminator could get into the public ctor
                // for structs, all properties must be set in the public ctor
                if (isStruct || inputModelProperty is { IsRequired: true, IsDiscriminator: false, ConstantValue: null })
                {
                    // [TODO]: Provide a flag to add read/write properties to the public model constructor
                    if (Configuration.Generation1ConvenienceClient || !inputModelProperty.IsReadOnly)
                    {
                        publicParameters.Add(parameter with { Type = parameter.Type.InputType });
                    }
                }
            }

            if (additionalPropertiesValueType is not null)
            {
                // We use a $ prefix here as AdditionalProperties comes from a swagger concept
                // and not a swagger model/operation name to disambiguate from a possible property with
                // the same name.
                var existingMember = modelTypeMapping?.GetMemberByOriginalName("$AdditionalProperties");

                var type = CreateAdditionalPropertiesPropertyType(typeFactory, additionalPropertiesValueType);
                if (!inputModelUsage.HasFlag(InputModelTypeUsage.Input))
                {
                    type = type.OutputType;
                }

                var name = existingMember is null ? "AdditionalProperties" : existingMember.Name;
                var declaration = new CodeWriterDeclaration(name);
                declaration.SetActualName(name);

                var accessModifiers = existingMember is null ? Public : GetAccessModifiers(existingMember);

                var additionalPropertiesField = new FieldDeclaration($"Additional Properties", accessModifiers | ReadOnly, type, type, declaration, null, false, SerializationFormat.Default, true);
                var additionalPropertiesParameter = new Parameter(name.ToVariableName(), $"Additional Properties", type, null, ValidationType.None, null);

                // we intentionally do not add this field into the field list to avoid cyclic references
                serializationParameters.Add(additionalPropertiesParameter);
                if (isStruct)
                {
                    publicParameters.Add(additionalPropertiesParameter with { Validation = ValidationType.AssertNotNull });
                }

                parametersToFields[additionalPropertiesParameter.Name] = additionalPropertiesField;

                AdditionalProperties = additionalPropertiesField;
            }

            // adding the leftover members from the source type
            if (modelTypeMapping is not null)
            {
                foreach (var existingMember in modelTypeMapping.GetPropertiesWithSerialization())
                {
                    if (visitedMembers.Contains(existingMember))
                    {
                        continue;
                    }
                    var existingCSharpType = BuilderHelpers.GetTypeFromExisting(existingMember, typeof(object), typeFactory);

                    // since the property doesn't exist in the input type, we use type of existing member both as original and field type
                    // the serialization will be generated for this type and it might has issues if the type is not recognized properly.
                    // but customer could always use the `CodeGenMemberSerializationHooks` attribute to override those incorrect serialization/deserialization code.
                    var field = CreateFieldFromExisting(existingMember, existingCSharpType, null, SerializationFormat.Default, typeFactory, false, false);
                    var parameter = new Parameter(field.Name.ToVariableName(), $"", field.Type, null, ValidationType.None, null);

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

        // TODO -- when we consolidate the schemas into input types, we should remove this method and move it into BuilderHelpers
        private static CSharpType CreateAdditionalPropertiesPropertyType(TypeFactory typeFactory, InputType additionalPropertiesValueType)
        {
            var valueType = typeFactory.CreateType(additionalPropertiesValueType);
            var originalType = new CSharpType(typeof(IDictionary<,>), typeof(string), valueType);

            return BuilderHelpers.CreateAdditionalPropertiesPropertyType(originalType, typeFactory.UnknownType);
        }

        private static ValidationType GetParameterValidation(FieldDeclaration field, InputModelProperty inputModelProperty)
        {
            // we do not validate a parameter when it is a value type (struct or int, etc)
            if (field.Type.IsValueType)
            {
                return ValidationType.None;
            }

            // or it is readonly
            if (inputModelProperty.IsReadOnly)
            {
                return ValidationType.None;
            }

            // or it is optional
            if (!field.IsRequired)
            {
                return ValidationType.None;
            }

            // or it is nullable
            if (field.Type.IsNullable)
            {
                return ValidationType.None;
            }

            return ValidationType.AssertNotNull;
        }

        public FieldDeclaration GetFieldByParameterName(string parameterName) => _parameterNamesToFields[parameterName];
        public bool TryGetFieldByParameter(Parameter parameter, [MaybeNullWhen(false)] out FieldDeclaration fieldDeclaration) => _parameterNamesToFields.TryGetValue(parameter.Name, out fieldDeclaration);
        public InputModelProperty? GetInputByField(FieldDeclaration field) => _fieldsToInputs.TryGetValue(field, out var property) ? property : null;

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

            if (type.IsCollection && !type.IsReadOnlyMemory)
            {
                // nullable collection should be settable
                // one exception is in the property bag, we never let them to be settable.
                return property.Type is not InputNullableType || isPropertyBag;
            }

            // In mixed models required properties are not readonly
            return property.IsRequired && usage.HasFlag(InputModelTypeUsage.Input) && !usage.HasFlag(InputModelTypeUsage.Output);
        }

        private static FieldDeclaration CreateField(string fieldName, CSharpType originalType, InputModelTypeUsage usage, InputModelProperty inputModelProperty, bool isStruct, bool isPropertyBag, bool optionalViaNullability)
        {
            var valueType = originalType;
            if (optionalViaNullability)
            {
                originalType = originalType.WithNullable(true);
            }

            FieldModifiers fieldModifiers;
            FieldModifiers? setterModifiers = null;
            if (inputModelProperty.IsDiscriminator)
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

            CodeWriterDeclaration declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration(
                FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Description)),
                fieldModifiers,
                originalType,
                valueType,
                declaration,
                GetPropertyInitializationValue(originalType, inputModelProperty),
                inputModelProperty.IsRequired,
                SerializationBuilder.GetSerializationFormat(inputModelProperty.Type, valueType),
                OptionalViaNullability: optionalViaNullability,
                IsField: false,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, CSharpType originalType, ValueExpression? initializationValue, SerializationFormat serializationFormat, TypeFactory typeFactory, bool isRequired, bool optionalViaNullability)
        {
            if (optionalViaNullability)
            {
                originalType = originalType.WithNullable(true);
            }
            var fieldType = BuilderHelpers.GetTypeFromExisting(existingMember, originalType, typeFactory);
            var valueType = fieldType;
            if (optionalViaNullability)
            {
                valueType = valueType.WithNullable(false);
            }

            var fieldModifiers = GetAccessModifiers(existingMember);
            if (BuilderHelpers.IsReadOnly(existingMember, fieldType))
            {
                fieldModifiers |= ReadOnly;
            }

            var writeAsProperty = existingMember is IPropertySymbol;
            CodeWriterDeclaration declaration = new CodeWriterDeclaration(existingMember.Name);
            declaration.SetActualName(existingMember.Name);

            return new FieldDeclaration(
                Description: $"Must be removed by post-generation processing,",
                Modifiers: fieldModifiers,
                Type: fieldType,
                ValueType: valueType,
                Declaration: declaration,
                InitializationValue: initializationValue,
                IsRequired: isRequired,
                serializationFormat != SerializationFormat.Default ? serializationFormat : SerializationBuilder.GetDefaultSerializationFormat(valueType),
                IsField: existingMember is IFieldSymbol,
                WriteAsProperty: writeAsProperty,
                OptionalViaNullability: optionalViaNullability);
        }

        private static FieldModifiers GetAccessModifiers(ISymbol symbol) => symbol.DeclaredAccessibility switch
        {
            Accessibility.Public => Public,
            Accessibility.Protected => Protected,
            Accessibility.Internal => Internal,
            Accessibility.Private => Private,
            _ => throw new ArgumentOutOfRangeException()
        };

        private static CSharpType GetPropertyDefaultType(in InputModelTypeUsage usage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var propertyType = typeFactory.CreateType(property.Type);

            if (!usage.HasFlag(InputModelTypeUsage.Input) || property.IsReadOnly)
            {
                propertyType = propertyType.OutputType;
            }

            return propertyType;
        }

        private static ValueExpression? GetPropertyInitializationValue(CSharpType propertyType, InputModelProperty inputModelProperty)
        {
            // if the default value is set somewhere else, we just return it.
            if (inputModelProperty.DefaultValue != null)
            {
                return new FormattableStringToExpression(inputModelProperty.DefaultValue);
            }

            // if it is not set, we check if this property is a literal type, and use the literal type as its default value.
            if (inputModelProperty.ConstantValue is null || !inputModelProperty.IsRequired)
            {
                return null;
            }

            // [TODO]: Consolidate property initializer generation between HLC and DPG
            if (Configuration.Generation1ConvenienceClient)
            {
                return null;
            }

            var constant = inputModelProperty.ConstantValue is { } constantValue && !propertyType.IsNullable
                ? BuilderHelpers.ParseConstant(constantValue.Value, propertyType)
                : Constant.NewInstanceOf(propertyType);

            return new ConstantExpression(constant);
        }
    }
}
