// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            (_fieldsToInputs, var publicParameters, var serializationParameters, _parameterNamesToFields) = CreateParametersAndFieldsForRoundTripModel(inputModel, typeFactory);

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

        private static (IReadOnlyDictionary<FieldDeclaration, InputModelProperty> FieldsToInputs, IReadOnlyList<Parameter> PublicParameters, IReadOnlyList<Parameter> SerializationParameters, IReadOnlyDictionary<string, FieldDeclaration> ParametersToFields) CreateParametersAndFieldsForRoundTripModel(InputModelType inputModel, TypeFactory typeFactory)
        {
            var fieldsToInputs = new Dictionary<FieldDeclaration, InputModelProperty>();
            var publicParameters = new List<Parameter>();
            var serializatoinParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            foreach (var inputModelProperty in inputModel.Properties)
            {
                // property is read-only if:
                // * model is read-only
                // * property is a collection
                // * property is required and model is either input only or output only
                var fieldModifiers = inputModelProperty.IsReadOnly || inputModelProperty.Type is InputDictionaryType or InputListType ||
                    ((inputModel.Usage == InputModelTypeUsage.Input || inputModel.Usage == InputModelTypeUsage.Output) && inputModelProperty.IsRequired)
                    ? Public | ReadOnly
                    : Public;
                var fieldType = GetDefaultPropertyType(inputModel.Usage, inputModelProperty, typeFactory);

                var field = new FieldDeclaration($"{inputModelProperty.Description}", fieldModifiers, fieldType, inputModelProperty.Name.FirstCharToUpperCase(), writeAsProperty: true);
                fieldsToInputs[field] = inputModelProperty;
                if (inputModelProperty.IsRequired)
                {
                    var parameter = Parameter.FromModelProperty(inputModelProperty, fieldType);
                    parametersToFields[parameter.Name] = field;
                    serializatoinParameters.Add(parameter with { Validation = ValidationType.None });
                    if (!inputModelProperty.IsReadOnly)
                    {
                        publicParameters.Add(parameter);
                    }
                }
            }

            return (fieldsToInputs, publicParameters, serializatoinParameters, parametersToFields);
        }

        private static CSharpType GetDefaultPropertyType(in InputModelTypeUsage modelUsage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var valueType = typeFactory.CreateType(property.Type);

            if (modelUsage == InputModelTypeUsage.Output ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            return valueType;
        }

        private static (ConstructorSignature PublicConstructor, ConstructorSignature SerializationConstructor) BuildConstructors(string name, in InputModelTypeUsage usage, IReadOnlyList<Parameter> publicParameters, IReadOnlyList<Parameter> serializationParameters)
        {
            ConstructorSignature publicConstructor;
            ConstructorSignature serializationConstructor;

            if (usage == InputModelTypeUsage.Input)
            {
                publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Public,
                    publicParameters.Select(p => CreatePublicConstructorParameter(p)).ToList());
                serializationConstructor = publicConstructor;
            }
            else
            {
                var publicConstructorAccessbility = (usage == InputModelTypeUsage.Output ? MethodSignatureModifiers.Internal : MethodSignatureModifiers.Public);
                if (serializationParameters.Any(p => TypeFactory.IsList(p.Type)) || !publicParameters.SequenceEqual(serializationParameters, new ParameterComparer()))
                {
                    serializationConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal, serializationParameters);
                    publicConstructor = new ConstructorSignature(name, $"Initializes a new instance of {name}", null, publicConstructorAccessbility,
                        publicParameters.Select(p => CreatePublicConstructorParameter(p)).ToList());
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

        /// <summary>
        /// Compare the parameters ignoring "Validation" property.
        /// </summary>
        private class ParameterComparer : IEqualityComparer<Parameter>
        {
            public bool Equals([AllowNull] Parameter x, [AllowNull] Parameter y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return (x with { Validation = ValidationType.None }).Equals(y with { Validation = ValidationType.None });
            }

            public int GetHashCode([DisallowNull] Parameter obj)
            {
                return (obj with { Validation = ValidationType.None }).GetHashCode();
            }
        }
    }
}
