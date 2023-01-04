// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
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
                var originalFieldName = discriminator.FirstCharToUpperCase();
                var inputModelProperty = new InputModelProperty(originalFieldName, discriminator, "Discriminator", InputPrimitiveType.String, true, true, true);
                var field = CreateField(originalFieldName, typeof(string), inputModel, inputModelProperty);
                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;
                var parameter = Parameter.FromModelProperty(inputModelProperty, field.Name.FirstCharToLowerCase(), field.Type);
                parametersToFields[parameter.Name] = field;
                serializationParameters.Add(parameter);
                publicParameters.Add(parameter);
            }

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var originalFieldName = inputModelProperty.Name.FirstCharToUpperCase();
                var originalFieldType = GetPropertyDefaultType(inputModel.Usage, inputModelProperty, typeFactory);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, originalFieldType, inputModelProperty, typeFactory)
                    : CreateField(originalFieldName, originalFieldType, inputModel, inputModelProperty);

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameter = Parameter.FromModelProperty(inputModelProperty, existingMember is IFieldSymbol ? inputModelProperty.Name.ToVariableName() : field.Name.FirstCharToLowerCase(), field.Type);
                parametersToFields[parameter.Name] = field;
                serializationParameters.Add(parameter);
                if (inputModelProperty.IsRequired && !inputModelProperty.IsReadOnly)
                {
                    publicParameters.Add(parameter);
                }
            }

            _fields = fields;
            _fieldsToInputs = fieldsToInputs;
            _parameterNamesToFields = parametersToFields;

            PublicConstructorParameters = publicParameters;
            SerializationParameters = serializationParameters;
        }

        public FieldDeclaration GetFieldByParameter(Parameter parameter) => _parameterNamesToFields[parameter.Name];
        public bool TryGetFieldByParameter(Parameter parameter, [MaybeNullWhen(false)]out FieldDeclaration fieldDeclaration) => _parameterNamesToFields.TryGetValue(parameter.Name, out fieldDeclaration);
        public InputModelProperty GetInputByField(FieldDeclaration field) => _fieldsToInputs[field];

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static FieldDeclaration CreateField(string fieldName, CSharpType fieldType, InputModelType inputModel, InputModelProperty inputModelProperty)
        {
            var propertyIsCollection = inputModelProperty.Type is InputDictionaryType or InputListType;
            var propertyIsRequiredInNonRoundTripModel = inputModel.Usage is InputModelTypeUsage.Input or InputModelTypeUsage.Output && inputModelProperty.IsRequired;
            var propertyIsOptionalInOutputModel = inputModel.Usage is InputModelTypeUsage.Output && !inputModelProperty.IsRequired;
            var propertyIsReadOnly = inputModelProperty.IsReadOnly || propertyIsCollection || propertyIsRequiredInNonRoundTripModel || propertyIsOptionalInOutputModel;

            var fieldModifiers = propertyIsReadOnly ? Public | ReadOnly : Public;

            CodeWriterDeclaration declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, fieldType, declaration, GetPropertyDefaultValue(fieldType, inputModelProperty), inputModelProperty.IsRequired, false, true);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, CSharpType originalType, InputModelProperty inputModelProperty, TypeFactory typeFactory)
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

            return new FieldDeclaration($"Must be removed by post-generation processing,", fieldModifiers, fieldType, declaration, GetPropertyDefaultValue(originalType, inputModelProperty), inputModelProperty.IsRequired, existingMember is IFieldSymbol, writeAsProperty);
        }

        private static CSharpType GetPropertyDefaultType(in InputModelTypeUsage modelUsage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var valueType = typeFactory.CreateType(property.Type);

            if (modelUsage == InputModelTypeUsage.Output ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            if (valueType.IsValueType && !property.IsRequired)
            {
                valueType = valueType.WithNullable(true);
            }

            return valueType;
        }

        private static FormattableString? GetPropertyDefaultValue(CSharpType propertyType, InputModelProperty inputModelProperty)
        {
            if (inputModelProperty.DefaultValue != null)
            {
                return inputModelProperty.DefaultValue;
            }
            if (TypeFactory.IsCollectionType(propertyType))
            {
                if (TypeFactory.IsReadOnlyList(propertyType))
                {
                    return $"{typeof(Array)}.Empty<{propertyType.Arguments[0]}>()";
                }
                if (TypeFactory.IsReadOnlyDictionary(propertyType))
                {
                    return $"new {new CSharpType(typeof(ReadOnlyDictionary<,>), propertyType.Arguments)}(new {new CSharpType(typeof(Dictionary<,>), propertyType.Arguments)}(0))";
                }
                if (!inputModelProperty.IsRequired)
                {
                    return Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType)).GetConstantFormattable();
                }
            }
            return null;
        }
    }
}
