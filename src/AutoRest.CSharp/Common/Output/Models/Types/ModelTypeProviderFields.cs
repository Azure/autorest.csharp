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
    internal sealed class ModelTypeProviderFields : IObjectTypeFields<InputModelProperty>
    {
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<FieldDeclaration, InputModelProperty> _fieldsToInputs;
        // parameter name should be unique since it's bound to field property
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public IReadOnlyList<Parameter> PublicConstructorParameters { get; }
        public IReadOnlyList<Parameter> SerializationParameters { get; }
        public int Count => _fields.Count;

        public ModelTypeProviderFields(InputModelType inputModel, TypeFactory typeFactory, ModelTypeMapping? sourceTypeMapping)
        {
            var fields = new List<FieldDeclaration>();
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            string? discriminator = inputModel.DiscriminatorPropertyName;
            if (discriminator is not null)
            {
                var originalFieldName = discriminator.ToCleanName();
                var inputModelProperty = new InputModelProperty(discriminator, discriminator, "Discriminator", InputPrimitiveType.String, true, false, true);
                var field = CreateField(originalFieldName, typeof(string), typeof(string), inputModel, inputModelProperty);
                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;
                var parameter = Parameter.FromModelProperty(inputModelProperty, field.Name.ToVariableName(), field.Type);
                parametersToFields[parameter.Name] = field;
                serializationParameters.Add(parameter);
            }

            var visitedMembers = new HashSet<ISymbol>(SymbolEqualityComparer.Default);

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var originalFieldName = inputModelProperty.Name.ToCleanName();
                var (originalFieldType, fieldValueType) = GetPropertyDefaultType(inputModel.Usage, inputModelProperty, typeFactory);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var serialization = sourceTypeMapping?.GetForMemberSerialization(existingMember);
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, serialization, originalFieldType, inputModel, inputModelProperty, typeFactory)
                    : CreateField(originalFieldName, originalFieldType, fieldValueType, inputModel, inputModelProperty);

                if (existingMember is not null)
                {
                    visitedMembers.Add(existingMember);
                }

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameter = Parameter.FromModelProperty(inputModelProperty, existingMember is IFieldSymbol ? inputModelProperty.Name.ToVariableName() : field.Name.ToVariableName(), field.Type);
                parametersToFields[parameter.Name] = field;
                // all properties should be included in the serialization ctor
                serializationParameters.Add(parameter);
                // only required + not readonly + not literal property could get into the public ctor
                if (inputModelProperty.IsRequired && !inputModelProperty.IsReadOnly && inputModelProperty.Type is not InputLiteralType)
                {
                    publicParameters.Add(parameter);
                }
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
                    var inputModelProperty = new InputModelProperty(serializationMapping.ExistingMember.Name, serializationMapping.SerializationPath?.Last(), "to be removed by post process", new InputPrimitiveType(InputTypeKind.String), false, false, false);
                    // we put the original type typeof(string) here as place holder. It always meets the condition of replacing the type with the type of existing member
                    var field = CreateFieldFromExisting(serializationMapping.ExistingMember, serializationMapping, typeof(string), inputModel, inputModelProperty, typeFactory);
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

        public FieldDeclaration GetFieldByParameter(Parameter parameter) => _parameterNamesToFields[parameter.Name];
        public bool TryGetFieldByParameter(Parameter parameter, [MaybeNullWhen(false)] out FieldDeclaration fieldDeclaration) => _parameterNamesToFields.TryGetValue(parameter.Name, out fieldDeclaration);
        public InputModelProperty GetInputByField(FieldDeclaration field) => _fieldsToInputs[field];

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static FieldDeclaration CreateField(string fieldName, CSharpType fieldType, CSharpType fieldValueType, InputModelType inputModel, InputModelProperty inputModelProperty)
        {
            var propertyIsCollection = inputModelProperty.Type is InputDictionaryType or InputListType ||
                // This is a temporary work around as we don't convert collection type to InputListType or InputDictionaryType in MPG for now
                inputModelProperty.Type is CodeModelType type && (type.Schema is ArraySchema or DictionarySchema);
            var propertyIsRequiredInNonRoundTripModel = inputModel.Usage is InputModelTypeUsage.Input or InputModelTypeUsage.Output && inputModelProperty.IsRequired;
            var propertyIsOptionalInOutputModel = inputModel.Usage is InputModelTypeUsage.Output && !inputModelProperty.IsRequired;
            var propertyIsLiteralType = inputModelProperty.Type is InputLiteralType;
            var propertyIsDiscriminator = inputModelProperty.IsDiscriminator;
            var propertyShouldOmitSetter = !propertyIsDiscriminator && // if a property is a discriminator, it should always has its setter
                (inputModelProperty.IsReadOnly || // a property will not have setter when it is readonly
                (propertyIsLiteralType && inputModelProperty.IsRequired) || // a property will not have setter when it is required literal type
                propertyIsCollection || // a property will not have setter when it is a collection
                propertyIsRequiredInNonRoundTripModel || // a property will explicitly omit its setter when it is useless
                propertyIsOptionalInOutputModel); // a property will explicitly omit its setter when it is useless

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
                fieldModifiers |= ReadOnly;

            CodeWriterDeclaration declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration(
                $"{inputModelProperty.Description}",
                fieldModifiers,
                fieldType,
                fieldValueType,
                declaration,
                GetPropertyDefaultValue(fieldType, inputModelProperty),
                inputModelProperty.IsRequired,
                inputModelProperty.SerializationFormat,
                IsField: false,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, SourcePropertySerializationMapping? serialization, CSharpType originalType, InputModelType inputModel, InputModelProperty inputModelProperty, TypeFactory typeFactory)
        {
            var existingMemberTypeSymbol = existingMember switch
            {
                IPropertySymbol propertySymbol => (INamedTypeSymbol)propertySymbol.Type,
                IFieldSymbol propertySymbol => (INamedTypeSymbol)propertySymbol.Type,
                _ => throw new NotSupportedException($"'{existingMember.ContainingType.Name}.{existingMember.Name}' must be either field or property.")
            };

            // Changing of model types is not supported
            var fieldType = originalType.IsFrameworkType ? existingMemberTypeSymbol.GetCSharpType() : originalType;

            var fieldModifiers = existingMember.DeclaredAccessibility switch
            {
                Accessibility.Public => Public,
                Accessibility.Internal => Internal,
                Accessibility.Private => Private,
                _ => throw new ArgumentOutOfRangeException()
            };

            var writeAsProperty = existingMember is IPropertySymbol;
            CodeWriterDeclaration declaration = new CodeWriterDeclaration(existingMember.Name);
            declaration.SetActualName(existingMember.Name);

            // TODO -- come up a way to get the value type from customized code
            // when creating field from existing member (customized code), here we use the same type as its value type.
            // for 2 reasons:
            // 1. it works
            // 2. we do not really have an efficiant way to get the value type of a property because we really cannot relying on the information in the schema when you have to do a customization, and from the csharp code, there is a lot of information we cannot get.
            return new FieldDeclaration($"Must be removed by post-generation processing,", fieldModifiers, fieldType, fieldType, declaration, GetPropertyDefaultValue(originalType, inputModelProperty), inputModelProperty.IsRequired, inputModelProperty.SerializationFormat, existingMember is IFieldSymbol, writeAsProperty, SerializationMapping: serialization);
        }

        private static (CSharpType PropertyType, CSharpType ValueType) GetPropertyDefaultType(in InputModelTypeUsage modelUsage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var propertyType = typeFactory.CreateType(property.Type);

            if (modelUsage == InputModelTypeUsage.Output ||
                property.IsReadOnly)
            {
                propertyType = TypeFactory.GetOutputType(propertyType);
            }

            var valueType = propertyType;
            if (propertyType.IsValueType && !property.IsRequired)
            {
                propertyType = propertyType.WithNullable(true);
            }

            return (propertyType, valueType);
        }

        private static FormattableString? GetPropertyDefaultValue(CSharpType propertyType, InputModelProperty inputModelProperty)
        {
            // if the default value is set somewhere else, we just return it.
            if (inputModelProperty.DefaultValue != null)
                return inputModelProperty.DefaultValue;

            // if it is not set, we check if this property is a literal type, and use the literal type as its default value.
            if (inputModelProperty.Type is not InputLiteralType literalType || !inputModelProperty.IsRequired)
            {
                return null;
            }

            var constant = literalType.Value != null ?
                        BuilderHelpers.ParseConstant(literalType.Value, propertyType) :
                        Constant.NewInstanceOf(propertyType);

            return constant.GetConstantFormattable();
        }
    }
}
