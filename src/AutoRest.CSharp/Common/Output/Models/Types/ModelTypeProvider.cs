// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
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

        // adopt lazy initialization for fields related properties
        public IReadOnlyList<FieldDeclaration> Fields
        {
            get
            {
                if (_fields != null)
                {
                    return _fields;
                }

                _fieldsInitializer();
                return _fields!;
            }
        }
        public ConstructorSignature PublicConstructor
        {
            get
            {
                if (_publicConstructor != null)
                {
                    return _publicConstructor;
                }

                _fieldsInitializer();
                return _publicConstructor!;
            }
        }
        public ConstructorSignature SerializationConstructor
        {
            get
            {
                if (_serializationConstructor != null)
                {
                    return _serializationConstructor;
                }

                _fieldsInitializer();
                return _serializationConstructor!;
            }
        }

        private IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs
        {
            get
            {
                if (_fieldsToInputs != null)
                {
                    return _fieldsToInputs;
                }

                _fieldsInitializer();
                return _fieldsToInputs!;
            }
        }
        // parameter name should be unique since it's bound to field property
        private IReadOnlyDictionary<string, FieldDeclaration> ParameterNamesToFields
        {
            get
            {
                if (_parameterNamesToFields != null)
                {
                    return _parameterNamesToFields;
                }

                _fieldsInitializer();
                return _parameterNamesToFields!;
            }
        }

        // lazy envaluation
        private readonly Action _fieldsInitializer;
        private IReadOnlyList<FieldDeclaration>? _fields;
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private IReadOnlyDictionary<FieldDeclaration, InputModelProperty>? _fieldsToInputs;
        // parameter name should be unique since it's bound to field property
        private IReadOnlyDictionary<string, FieldDeclaration>? _parameterNamesToFields;

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";

            _fieldsInitializer = delegate()
            {
                (_fieldsToInputs, var serializationParameters, _parameterNamesToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory);

                _fields = _fieldsToInputs.Keys.ToList();
                (_publicConstructor, _serializationConstructor) = BuildConstructors(Declaration.Name, serializationParameters);
            };
        }

        // Serialization uses field and property names that first need to verified for uniqueness
        // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
        public JsonObjectSerialization CreateSerialization() => new(Type, SerializationConstructor, CreatePropertySerializations().ToArray(), null, null, false, true, true);

        public FieldDeclaration GetFieldByParameterName(string name) => ParameterNamesToFields[name];

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            foreach (var (parameterName, field) in ParameterNamesToFields)
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

                var property = FieldsToInputs[field];
                var serializedName = property.SerializedName ?? property.Name;
                var optionalViaNullability = !property.IsRequired && !field.Type.IsNullable && !TypeFactory.IsCollectionType(field.Type);
                var valueType = field.Type;
                var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, valueType);
                yield return new JsonPropertySerialization(parameterName, name, serializedName, field.Type, valueType, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static (IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs, IReadOnlyList<Parameter> SerializationParameters, IReadOnlyDictionary<string, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory)
        {
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var serializatoinParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

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
                    parametersToFields[parameter.Name] = field;
                    serializatoinParameters.Add(parameter);
                }
            }

            return (fieldsToInputs, serializatoinParameters, parametersToFields);
        }

        private static (ConstructorSignature PublicConstructor, ConstructorSignature SerializationConstructor) BuildConstructors(string name, IReadOnlyList<Parameter> serializationParameters)
        {
            ConstructorSignature publicConstructor;
            ConstructorSignature serializationConstructor;
            if (serializationParameters.Where(IsIList).Any())
            {
                serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal, serializationParameters);
                publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public,
                    serializationParameters.Select(p => IsIList(p) ? FromIListToIEnumerable(p) : p).ToList());
            }
            else
            {
                serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public, serializationParameters);
                publicConstructor = serializationConstructor;

            }
            return (publicConstructor, serializationConstructor);
        }

        private static bool IsIList(Parameter p) => p.Type.IsFrameworkType && p.Type.FrameworkType == typeof(IList<>);

        private static Parameter FromIListToIEnumerable(Parameter p) => new Parameter(p.Name, p.Description, new CSharpType(typeof(IEnumerable<>), p.Type.IsNullable, p.Type.Arguments), p.DefaultValue, p.Validation, p.Initializer);
    }
}
