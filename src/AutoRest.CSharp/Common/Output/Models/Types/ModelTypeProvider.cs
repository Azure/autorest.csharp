// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public ConstructorSignature PublicConstructor { get; }
        public ConstructorSignature SerializationConstructor { get; }

        private readonly IReadOnlyDictionary<FieldDeclaration, InputModelProperty> _fieldsToInputs;
        private readonly IReadOnlyDictionary<Parameter, FieldDeclaration> _parametersToFields;

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";

            (_fieldsToInputs, _parametersToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory);

            Fields = _fieldsToInputs.Keys.ToList();
            PublicConstructor = BuildPublicConstructor(Declaration.Name, _parametersToFields.Keys.ToList());

            // Since we consider all models roundtrip for now, use the same constructor for serialization
            SerializationConstructor = PublicConstructor;
        }

        // Serialization uses field and property names that first need to verified for uniqueness
        // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
        public JsonObjectSerialization CreateSerialization() => new(Type, SerializationConstructor, CreatePropertySerializations().ToArray(), null, null, false, true, true);

        public FieldDeclaration GetFieldByParameter(Parameter parameter) => _parametersToFields[parameter];

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            var dictionary = new Dictionary<Parameter, JsonPropertySerialization>();
            foreach (var (parameter, field) in _parametersToFields)
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
                var valueSerialization = new JsonValueSerialization(field.Type, SerializationBuilder.GetSerializationFormat(property.Type), field.Type.IsNullable);
                yield return new JsonPropertySerialization(parameter.Name, name, serializedName, field.Type, field.Type, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static (IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs, IReadOnlyDictionary<Parameter, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory)
        {
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var parametersToFields = new Dictionary<Parameter, FieldDeclaration>();

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var fieldModifiers = inputModelProperty.IsReadOnly || inputModelProperty.Type is InputDictionaryType or InputListType
                    ? Public | ReadOnly
                    : Public;

                var field = new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, typeFactory.CreateType(inputModelProperty.Type), inputModelProperty.Name.FirstCharToUpperCase(), writeAsProperty: true);
                fieldsToInputs[field] = inputModelProperty;
                if (inputModelProperty.IsRequired)
                {
                    var parameter = Parameter.FromModelProperty(inputModelProperty, typeFactory);
                    parametersToFields[parameter] = field;
                }
            }

            return (fieldsToInputs, parametersToFields);
        }

        private static ConstructorSignature BuildPublicConstructor(string name, IReadOnlyList<Parameter> parameters)
        {
            return new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public, parameters);
        }
    }
}
