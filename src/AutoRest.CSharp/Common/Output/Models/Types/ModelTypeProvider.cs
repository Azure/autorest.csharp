// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
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
        // parameter name should be unique since it's bound to field property
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";

            (_fieldsToInputs, var publicParameters, var serializationParameters, _parameterNamesToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory);

            Fields = _fieldsToInputs.Keys.ToList();
            (PublicConstructor, SerializationConstructor) = BuildConstructors(Declaration.Name, publicParameters, serializationParameters);
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

        private static (IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs, IReadOnlyList<Parameter> PublicParameters, IReadOnlyList<Parameter> SerializationParameters, IReadOnlyDictionary<string, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory)
        {
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializatoinParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var fieldModifiers = inputModelProperty.IsReadOnly || inputModelProperty.Type is InputDictionaryType or InputListType
                    ? Public | ReadOnly
                    : Public;
                var fieldType = GetDefaultPropertyType(inputModelProperty, typeFactory);

                var field = new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, fieldType, inputModelProperty.Name.FirstCharToUpperCase(), writeAsProperty: true);
                fieldsToInputs[field] = inputModelProperty;
                if (inputModelProperty.IsRequired)
                {
                    var parameter = Parameter.FromModelProperty(inputModelProperty, fieldType);
                    parametersToFields[parameter.Name] = field;
                    serializatoinParameters.Add(parameter);
                    if (!inputModelProperty.IsReadOnly)
                    {
                        publicParameters.Add(parameter);
                    }
                }
            }

            return (fieldsToInputs, publicParameters, serializatoinParameters, parametersToFields);
        }

        private static CSharpType GetDefaultPropertyType(in InputModelProperty property, TypeFactory typeFactory)
        {
            var valueType = typeFactory.CreateType(property.Type);

            if (//!_usage.HasFlag(SchemaTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            return valueType;
        }

        private static (ConstructorSignature PublicConstructor, ConstructorSignature SerializationConstructor) BuildConstructors(string name, IReadOnlyList<Parameter> publicParameters, IReadOnlyList<Parameter> serializationParameters)
        {
            ConstructorSignature publicConstructor;
            ConstructorSignature serializationConstructor;
            if (!publicParameters.SequenceEqual(serializationParameters) || serializationParameters.Any(p => TypeFactory.IsList(p.Type)))
            {
                serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal, serializationParameters);
                publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public,
                    publicParameters.Select(p => TypeFactory.IsReadWriteList(p.Type) ? FromIListToIEnumerable(p) : p).ToList());
            }
            else
            {
                serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public, serializationParameters);
                publicConstructor = serializationConstructor;

            }
            return (publicConstructor, serializationConstructor);
        }

        private static Parameter FromIListToIEnumerable(Parameter p) => new Parameter(p.Name, p.Description, new CSharpType(typeof(IEnumerable<>), p.Type.IsNullable, p.Type.Arguments), p.DefaultValue, p.Validation, p.Initializer);
    }
}
