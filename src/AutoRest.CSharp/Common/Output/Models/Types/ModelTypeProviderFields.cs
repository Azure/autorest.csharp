// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
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

            var visitedMembers = new HashSet<ISymbol>(SymbolEqualityComparer.Default);

            foreach (var inputModelProperty in inputModel.Properties)
            {
                var originalFieldName = inputModelProperty.Name.ToCleanName();
                var propertyType = GetPropertyDefaultType(inputModel.Usage, inputModelProperty, typeFactory);

                // We represent property being optional by making it nullable (when it is a value type)
                // Except in the case of collection where there is a special handling
                var optionalViaNullability = !inputModelProperty.IsRequired &&
                                             !inputModelProperty.Type.IsNullable &&
                                             !TypeFactory.IsCollectionType(propertyType);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var serialization = sourceTypeMapping?.GetForMemberSerialization(existingMember);
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, serialization, propertyType, inputModel, inputModelProperty, typeFactory, optionalViaNullability)
                    : CreateField(originalFieldName, propertyType, inputModel, inputModelProperty, optionalViaNullability);

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
                // only required + not readonly + not literal property + not discriminator could get into the public ctor
                if (inputModelProperty.IsRequired &&
                    !inputModelProperty.IsReadOnly &&
                    !inputModelProperty.IsDiscriminator &&
                    inputModelProperty.Type is not InputLiteralType)
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
                    var isReadOnly = IsReadOnly(serializationMapping.ExistingMember);
                    var inputModelProperty = new InputModelProperty(serializationMapping.ExistingMember.Name, serializationMapping.SerializationPath?.Last(), "to be removed by post process", InputPrimitiveType.Object, false, isReadOnly, false);
                    // we put the original type typeof(object) here as fallback. We do not really care about what type we get here, just to ensure there is a type generated
                    // therefore the top type here is reasonable
                    // the serialization will be generated for this type and it might has issues if the type is not recognized properly.
                    // but customer could always use the `CodeGenMemberSerializationHooks` attribute to override those incorrect serialization/deserialization code.
                    var field = CreateFieldFromExisting(serializationMapping.ExistingMember, serializationMapping, typeof(object), inputModel, inputModelProperty, typeFactory, false);
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

        private static bool ShouldPropertyOmitSetter(InputModelType inputModel, InputModelProperty property, CSharpType type)
        {
            if (property.IsDiscriminator)
            {
                // discriminator properties should be writeable because we need to set values to the discriminators in the public ctor of derived classes.
                return false;
            }
            if (property.Type is InputLiteralType && property.IsRequired)
            {
                // we should remove the setter of required constant
                return true;
            }

            var propertyShouldOmitSetter = !inputModel.Usage.HasFlag(InputModelTypeUsage.Input) || property.IsReadOnly;

            if (TypeFactory.IsCollectionType(type))
            {
                // nullable collection should be settable
                // one exception is in the property bag, we never let them to be settable.
                propertyShouldOmitSetter |= !property.Type.IsNullable || inputModel.IsPropertyBag;
            }
            else
            {
                // In mixed models required properties are not readonly
                propertyShouldOmitSetter |= property.IsRequired &&
                                inputModel.Usage.HasFlag(InputModelTypeUsage.Input) &&
                                !inputModel.Usage.HasFlag(InputModelTypeUsage.Output);
            }

            return propertyShouldOmitSetter;
        }

        private static FieldDeclaration CreateField(string fieldName, CSharpType originalType, InputModelType inputModel, InputModelProperty inputModelProperty, bool optionalViaNullability)
        {
            var propertyShouldOmitSetter = ShouldPropertyOmitSetter(inputModel, inputModelProperty, originalType);

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
            if (propertyShouldOmitSetter)
                fieldModifiers |= ReadOnly;

            CodeWriterDeclaration declaration = new CodeWriterDeclaration(fieldName);
            declaration.SetActualName(fieldName);
            return new FieldDeclaration(
                $"{inputModelProperty.Description}",
                fieldModifiers,
                originalType,
                valueType,
                declaration,
                GetPropertyDefaultValue(originalType, inputModelProperty),
                inputModelProperty.IsRequired,
                SerializationBuilder.GetSerializationFormat(inputModelProperty.Type, valueType),
                OptionalViaNullability: optionalViaNullability,
                IsField: false,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, SourcePropertySerializationMapping? serialization, CSharpType originalType, InputModelType inputModel, InputModelProperty inputModelProperty, TypeFactory typeFactory, bool optionalViaNullability)
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

            return new FieldDeclaration(
                Description: $"Must be removed by post-generation processing,",
                Modifiers: fieldModifiers,
                Type: fieldType,
                ValueType: valueType,
                Declaration: declaration,
                DefaultValue: GetPropertyDefaultValue(originalType, inputModelProperty),
                IsRequired: inputModelProperty.IsRequired,
                SerializationBuilder.GetSerializationFormat(inputModelProperty.Type, valueType),
                IsField: existingMember is IFieldSymbol,
                WriteAsProperty: writeAsProperty,
                OptionalViaNullability: optionalViaNullability,
                SerializationMapping: serialization);
        }

        private static bool IsReadOnly(ISymbol existingMember) => existingMember switch
        {
            IPropertySymbol propertySymbol => propertySymbol.SetMethod == null,
            IFieldSymbol fieldSymbol => fieldSymbol.IsReadOnly,
            _ => throw new NotSupportedException($"'{existingMember.ContainingType.Name}.{existingMember.Name}' must be either field or property.")
        };

        private static CSharpType GetPropertyDefaultType(in InputModelTypeUsage usage, in InputModelProperty property, TypeFactory typeFactory)
        {
            var propertyType = typeFactory.CreateType(property.Type);

            if (!usage.HasFlag(InputModelTypeUsage.Input) ||
                property.IsReadOnly)
            {
                propertyType = TypeFactory.GetOutputType(propertyType);
            }

            return propertyType;
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

            var constant = literalType.Value.Value != null ?
                        BuilderHelpers.ParseConstant(literalType.Value.Value, propertyType) :
                        Constant.NewInstanceOf(propertyType);

            return constant.GetConstantFormattable();
        }
    }
}
