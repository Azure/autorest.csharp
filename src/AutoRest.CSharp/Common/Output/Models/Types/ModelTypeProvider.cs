// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : TypeProvider
    {
        private readonly TypeFactory _typeFactory;
        private readonly InputModelType _inputModel;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public ConstructorSignature PublicConstructor { get; }
        public ConstructorSignature SerializationConstructor { get; }

        private readonly IReadOnlyDictionary<InputModelProperty, FieldDeclaration> _inputsToFields;
        private readonly IReadOnlyDictionary<Parameter, FieldDeclaration> _parametersToFields;

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            _inputModel = inputModel;
            _typeFactory = typeFactory;

            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";

            (_inputsToFields, _parametersToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory);

            Fields = _inputsToFields.Values.ToList();
            PublicConstructor = BuildPublicConstructor(Declaration.Name, _parametersToFields.Keys.ToList());

            // Since we consider all models roundtrip for now, use the same constructor for serialization
            SerializationConstructor = PublicConstructor;
        }

        // Serialization uses field and property names that first need to verified for uniqueness
        // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
        public JsonObjectSerialization CreateSerialization() => new(new CSharpType(this), CreatePropertySerializations(_inputsToFields).ToArray(), null, false);

        public FieldDeclaration GetFieldByParameter(Parameter parameter) => _parametersToFields[parameter];

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations(IReadOnlyDictionary<InputModelProperty, FieldDeclaration> inputsToFields)
        {
            foreach (var (property, field) in inputsToFields)
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

                var serializedName = property.SerializedName ?? property.Name;
                var optionalViaNullability = !property.IsRequired && !field.Type.IsNullable && !TypeFactory.IsCollectionType(field.Type);
                var valueSerialization = new JsonValueSerialization(field.Type, SerializationFormat.Default, field.Type.IsNullable);

                yield return new JsonPropertySerialization(name, serializedName, field.Type, field.Type, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static (IReadOnlyDictionary<InputModelProperty, FieldDeclaration> InputsToFields, IReadOnlyDictionary<Parameter, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory)
        {
            var inputsToFields = new Dictionary<InputModelProperty, FieldDeclaration>();
            var parametersToFields = new Dictionary<Parameter, FieldDeclaration>();

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var fieldModifiers = inputModelProperty.IsReadOnly || inputModelProperty.Type is InputDictionaryType or InputListType
                    ? Public | ReadOnly
                    : Public;

                var field = new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, typeFactory.CreateType(inputModelProperty.Type), inputModelProperty.Name.FirstCharToUpperCase(), writeAsProperty: true);
                inputsToFields[inputModelProperty] = field;
                if (inputModelProperty.IsRequired)
                {
                    var parameter = Parameter.FromModelProperty(inputModelProperty, typeFactory);
                    parametersToFields[parameter] = field;
                }
            }

            return (inputsToFields, parametersToFields);
        }

        private static ConstructorSignature BuildPublicConstructor(string name, IReadOnlyList<Parameter> parameters)
        {
            return new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public, parameters);
        }
    }
}
