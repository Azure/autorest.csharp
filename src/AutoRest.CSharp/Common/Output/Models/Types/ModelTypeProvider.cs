// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public string Description { get; }
        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public ConstructorSignature PublicConstructor { get; }
        public ConstructorSignature SerializationConstructor { get; }
        public bool IncludeSerializer { get; }
        public bool IncludeDeserializer { get; }

        private readonly IReadOnlyDictionary<FieldDeclaration, InputModelProperty> _fieldsToInputs;
        // parameter name should be unique since it's bound to field property
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            Description = inputModel.Description ?? $"The {inputModel.Name}.";
            IncludeSerializer = inputModel.Usage.HasFlag(InputModelTypeUsage.Input);
            IncludeDeserializer = inputModel.Usage.HasFlag(InputModelTypeUsage.Output);

            (_fieldsToInputs, var publicParameters, var serializationParameters, _parameterNamesToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory, sourceInputModel?.CreateForModel(ExistingType));

            Fields = _fieldsToInputs.Keys.ToList();
            (PublicConstructor, SerializationConstructor) = BuildConstructors(Declaration.Name, inputModel.Usage, publicParameters, serializationParameters);
        }

        // Serialization uses field and property names that first need to verified for uniqueness
        // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
        public JsonObjectSerialization CreateSerialization() => new(Type, SerializationConstructor, CreatePropertySerializations().ToArray(), null, null, false, true, true);

        public FieldDeclaration GetFieldByParameterName(string name) => _parameterNamesToFields[name];

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            foreach (var (parameterName, field) in _parameterNamesToFields)
            {
                string name;
                try
                {
                    name = field.Name;
                }
                catch (InvalidOperationException e)
                {
                    throw new InvalidOperationException($"Field with {field.Declaration.RequestedName} isn't written yet to type {Declaration.Name}", e);
                }

                var property = _fieldsToInputs[field];
                var serializedName = property.SerializedName ?? property.Name;
                var optionalViaNullability = !property.IsRequired && !field.Type.IsNullable && !TypeFactory.IsCollectionType(field.Type);
                var valueType = field.Type;
                var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, valueType);
                yield return new JsonPropertySerialization(parameterName, name, serializedName, field.Type, valueType, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static (IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs, IReadOnlyList<Parameter> PublicParameters, IReadOnlyList<Parameter> SerializationParameters, IReadOnlyDictionary<string, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory, ModelTypeMapping? sourceTypeMapping)
        {
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var originalFieldName = inputModelProperty.Name.FirstCharToUpperCase();
                var originalFieldType = GetDefaultPropertyType(inputModel.Usage, inputModelProperty, typeFactory);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, originalFieldType, inputModelProperty.IsRequired, typeFactory)
                    : CreateField(originalFieldName, originalFieldType, inputModel, inputModelProperty);
                fieldsToInputs[field] = inputModelProperty;

                var parameter = Parameter.FromModelProperty(inputModelProperty, field.Type);
                parametersToFields[parameter.Name] = field;
                serializationParameters.Add(parameter);
                if (inputModelProperty.IsRequired && !inputModelProperty.IsReadOnly)
                {
                    publicParameters.Add(parameter);
                }
            }

            return (fieldsToInputs, publicParameters, serializationParameters, parametersToFields);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, CSharpType originalType, bool isRequired, TypeFactory typeFactory)
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

            return new FieldDeclaration($"Must be removed by post-generation processing,", fieldModifiers, fieldType, existingMember.Name, GetPropertyDefaultValue(originalType, isRequired), writeAsProperty: writeAsProperty);
        }

        private static FieldDeclaration CreateField(string fieldName, CSharpType fieldType, InputModelType inputModel, InputModelProperty inputModelProperty)
        {
            var propertyIsCollection = inputModelProperty.Type is InputDictionaryType or InputListType;
            var propertyIsRequiredInNonRoundTripModel = inputModel.Usage is InputModelTypeUsage.Input or InputModelTypeUsage.Output && inputModelProperty.IsRequired;
            var propertyIsOptionalInOutputModel = inputModel.Usage is InputModelTypeUsage.Output && !inputModelProperty.IsRequired;
            var propertyIsReadOnly = inputModelProperty.IsReadOnly || propertyIsCollection || propertyIsRequiredInNonRoundTripModel || propertyIsOptionalInOutputModel;

            var fieldModifiers = propertyIsReadOnly ? Public | ReadOnly : Public;

            return new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, fieldType, fieldName, GetPropertyDefaultValue(fieldType, inputModelProperty.IsRequired), writeAsProperty: true);
        }

        private static CSharpType GetDefaultPropertyType(in InputModelTypeUsage modelUsage, in InputModelProperty property, TypeFactory typeFactory)
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

        private static FormattableString? GetPropertyDefaultValue(CSharpType propertyType, bool isRequired)
        {
            // TODO: Add Dictionary support
            if (TypeFactory.IsList(propertyType))
            {
                if (TypeFactory.IsReadOnlyList(propertyType))
                {
                    return $"Array.Empty<{propertyType.Arguments[0]}>()";
                }
                if (!isRequired)
                {
                    return Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType)).GetConstantFormattable();
                }
            }
            return null;
        }

        private static (ConstructorSignature PublicConstructor, ConstructorSignature SerializationConstructor) BuildConstructors(string name, in InputModelTypeUsage usage, IReadOnlyList<Parameter> publicParameters, IReadOnlyList<Parameter> serializationParameters)
        {
            ConstructorSignature publicConstructor;
            ConstructorSignature serializationConstructor;

            if (usage == InputModelTypeUsage.Input)
            {
                publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public,
                    publicParameters.Select(CreatePublicConstructorParameter).ToList());
                serializationConstructor = publicConstructor;
            }
            else
            {
                var publicConstructorAccessbility = (usage == InputModelTypeUsage.Output ? MethodSignatureModifiers.Internal : MethodSignatureModifiers.Public);
                if (serializationParameters.Any(p => TypeFactory.IsList(p.Type)) || !publicParameters.SequenceEqual(serializationParameters))
                {
                    publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, publicConstructorAccessbility,
                        publicParameters.Select(CreatePublicConstructorParameter).ToList());
                    serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal,
                        serializationParameters.Select(p => p with { Validation = ValidationType.None }).ToList()); // we don't validate parameters for serialization constructor
                }
                else
                {
                    publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, publicConstructorAccessbility, publicParameters);
                    serializationConstructor = publicConstructor;
                }
            }

            return (publicConstructor, serializationConstructor);
        }

        private static Parameter CreatePublicConstructorParameter(Parameter p)
            => TypeFactory.IsList(p.Type) ? p with { Type = new CSharpType(typeof(IEnumerable<>), p.Type.IsNullable, p.Type.Arguments) } : p;
    }
}
