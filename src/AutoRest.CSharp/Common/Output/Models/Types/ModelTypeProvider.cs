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
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : ObjectType
    {
        private ModelTypeProviderFields? _fields;
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private InputModelType _inputModel;
        private TypeFactory _typeFactory;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        //public string Description { get; }
        public bool IncludeSerializer { get; }
        public bool IncludeDeserializer { get; }

        public ModelTypeProviderFields Fields => _fields ?? throw new InvalidOperationException($"Model '{Declaration.Name}' is not fully initialized");
        public ConstructorSignature InitializationConstructorSignature => _publicConstructor ?? throw new InvalidOperationException($"Model '{Declaration.Name}' is not fully initialized");
        public ConstructorSignature SerializationConstructorSignature => _serializationConstructor ?? throw new InvalidOperationException($"Model '{Declaration.Name}' is not fully initialized");

        public override ObjectTypeProperty? AdditionalPropertiesProperty => throw new NotImplementedException();

        public ModelTypeProvider(InputModelType inputModel, string defaultNamespace, SourceInputModel? sourceInputModel, TypeFactory typeFactory)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;
            _inputModel = inputModel;
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            //Description = inputModel.Description ?? $"The {inputModel.Name}.";
            IncludeSerializer = inputModel.Usage.HasFlag(InputModelTypeUsage.Input);
            IncludeDeserializer = inputModel.Usage.HasFlag(InputModelTypeUsage.Output);
        }

        protected override string CreateDescription()
        {
            return _inputModel.Accessibility ?? "public";
        }

        public void FinishInitialization(InputModelType inputModelType, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
        {
            if (_fields is not null)
            {
                throw new InvalidOperationException("Model is initialized already");
            }

            _fields = new ModelTypeProviderFields(inputModelType, typeFactory, sourceInputModel?.CreateForModel(ExistingType));
            _publicConstructor = CreatePublicConstructor(Declaration.Name, inputModelType.Usage, Fields.PublicConstructorParameters);
            _serializationConstructor = IncludeDeserializer
                ? CreateSerializationConstructor(Declaration.Name, Fields.PublicConstructorParameters, Fields.SerializationParameters) ?? _publicConstructor
                : _publicConstructor;
        }

        // Serialization uses field and property names that first need to verified for uniqueness
        // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
        public JsonObjectSerialization CreateSerialization() => new(Type, SerializationConstructorSignature, CreatePropertySerializations().ToArray(), null, null, false, true, true);

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            foreach (var parameter in Fields.SerializationParameters)
            {
                var field = Fields.GetFieldByParameter(parameter);
                string name;
                try
                {
                    name = field.Name;
                }
                catch (InvalidOperationException e)
                {
                    throw new InvalidOperationException($"Field with {field.Declaration.RequestedName} isn't written yet to type {Declaration.Name}", e);
                }

                var property = Fields.GetInputByField(field);
                var serializedName = property.SerializedName ?? property.Name;
                var optionalViaNullability = !property.IsRequired && !field.Type.IsNullable && !TypeFactory.IsCollectionType(field.Type);
                var valueType = field.Type;
                var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, valueType);
                yield return new JsonPropertySerialization(parameter.Name, name, serializedName, field.Type, valueType, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static ConstructorSignature? CreateSerializationConstructor(string name, IReadOnlyList<Parameter> publicParameters, IReadOnlyList<Parameter> serializationParameters)
        {
            if (!serializationParameters.Any(p => TypeFactory.IsList(p.Type)) && publicParameters.SequenceEqual(serializationParameters))
            {
                return null;
            }

            return new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal, serializationParameters.Select(CreateSerializationConstructorParameter).ToList());
        }

        private static ConstructorSignature CreatePublicConstructor(string name, InputModelTypeUsage usage, IEnumerable<Parameter> parameters)
        {
            var summary = $"Initializes a new instance of {name}";
            var accessibility = usage == InputModelTypeUsage.Output
                ? MethodSignatureModifiers.Internal
                : MethodSignatureModifiers.Public;

            return new ConstructorSignature(name, summary, null, accessibility, parameters.Select(CreatePublicConstructorParameter).ToList());
        }

        private static Parameter CreatePublicConstructorParameter(Parameter p)
            => TypeFactory.IsList(p.Type) ? p with { Type = new CSharpType(typeof(IEnumerable<>), p.Type.IsNullable, p.Type.Arguments) } : p;

        private static Parameter CreateSerializationConstructorParameter(Parameter p) // we don't validate parameters for serialization constructor
            => p with { Validation = ValidationType.None };

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            return new ObjectTypeConstructor(InitializationConstructorSignature, GetPropertyInitializers());
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            return new ObjectTypeConstructor(SerializationConstructorSignature, GetPropertyInitializers());
        }

        private ObjectPropertyInitializer[] GetPropertyInitializers()
        {
            //List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();
            foreach (var property in Properties)
            {
                // Only required properties that are not discriminators go into default ctor
                // TODO map discriminator into cadl.json
                //if (property == Discriminator?.Property)
                //{
                //    continue;
                //}

                ReferenceOrConstant? initializationValue;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (property.SchemaProperty?.Schema is ConstantSchema constantSchema)
                {
                    // Turn constants into initializers
                    initializationValue = constantSchema.Value.Value != null ?
                        BuilderHelpers.ParseConstant(constantSchema.Value.Value, propertyType) :
                        Constant.NewInstanceOf(propertyType);
                }
                else if (IsStruct || property.SchemaProperty?.IsRequired == true)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    if (property.SchemaProperty?.ClientDefaultValue is object defaultValueObject)
                    {
                        defaultParameterValue = BuilderHelpers.ParseConstant(defaultValueObject, propertyType);
                        defaultInitializationValue = defaultParameterValue;
                    }

                    var inputType = TypeFactory.GetInputType(propertyType);
                    if (defaultParameterValue != null && !TypeFactory.CanBeInitializedInline(property.ValueType, defaultParameterValue))
                    {
                        inputType = inputType.WithNullable(true);
                        defaultParameterValue = Constant.Default(inputType);
                    }

                    var validate = property.SchemaProperty?.Nullable != true && !inputType.IsValueType ? ValidationType.AssertNotNull : ValidationType.None;
                    var defaultCtorParameter = new Parameter(
                        property.Declaration.Name.ToVariableName(),
                        property.Description,
                        inputType,
                        defaultParameterValue,
                        validate,
                        null
                    );

                    initializationValue = defaultCtorParameter;
                }
                else
                {
                    initializationValue = null;// need to get discriminator value from here GetPropertyDefaultValue(property);

                    if (initializationValue == null && TypeFactory.IsCollectionType(propertyType))
                    {
                        initializationValue = Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType));
                    }
                }

                if (initializationValue != null)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, initializationValue.Value, defaultInitializationValue));
                }
            }
            return defaultCtorInitializers.ToArray();
        }

        protected override CSharpType? CreateInheritedType()
        {
            if (_inputModel.BaseModel is not null)
                return new CSharpType(new ModelTypeProvider(_inputModel.BaseModel!, DefaultNamespace, null, _typeFactory));

            return null;
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var property in _inputModel.Properties)
                yield return new ObjectTypeProperty(property, _typeFactory.CreateType(property.Type), DefaultAccessibility, this);
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return BuildInitializationConstructor();
            if (IncludeDeserializer)
                yield return BuildSerializationConstructor();
        }
    }
}
