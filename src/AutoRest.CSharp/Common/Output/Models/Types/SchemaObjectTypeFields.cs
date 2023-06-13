// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class SchemaObjectTypeFields : IObjectTypeFields<Property>
    {
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<FieldDeclaration, Property> _fieldsToInputs;
        // parameter name should be unique since it's bound to field property
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public IReadOnlyList<Parameter> PublicConstructorParameters { get; }
        public IReadOnlyList<Parameter> SerializationParameters { get; }
        public int Count => _fields.Count;

        public SchemaObjectTypeFields(CSharpType enclosingType, ObjectSchema inputModel, IEnumerable<Property> inputModelProperties, SchemaTypeUsage usage, TypeFactory typeFactory, ModelTypeMapping? sourceTypeMapping)
        {
            var fields = new List<FieldDeclaration>();
            var fieldsToInputs = new Dictionary<FieldDeclaration, Property>();
            var publicParameters = new List<Parameter>();
            var serializationParameters = new List<Parameter>();
            var parametersToFields = new Dictionary<string, FieldDeclaration>();

            // finding the discriminator, and create a property for it
            // we should skip this in SchemaObjectType because we already have a property for that
            //string? discriminator = inputModel.DiscriminatorPropertyName;
            //if (discriminator is not null)
            //{
            //    var originalFieldName = discriminator.ToCleanName();
            //    var inputModelProperty = new InputModelProperty(discriminator, discriminator, "Discriminator", InputPrimitiveType.String, true, false, true);
            //    var field = CreateField(originalFieldName, typeof(string), inputModel, inputModelProperty);
            //    fields.Add(field);
            //    fieldsToInputs[field] = inputModelProperty;
            //    var parameter = Parameter.FromModelProperty(inputModelProperty, field.Name.ToVariableName(), field.Type);
            //    parametersToFields[parameter.Name] = field;
            //    serializationParameters.Add(parameter);
            //}

            foreach (var inputModelProperty in inputModelProperties)
            {
                var originalFieldName = BuilderHelpers.DisambiguateName(enclosingType, inputModelProperty.CSharpName());
                var propertyType = GetPropertyDefaultType(usage, inputModelProperty, typeFactory);
                // We represent property being optional by making it nullable (when it is a value type)
                // Except in the case of collection where there is a special handling
                var optionalViaNullability = !inputModelProperty.IsRequired &&
                                             !inputModelProperty.IsNullable &&
                                             !TypeFactory.IsCollectionType(propertyType);

                var existingMember = sourceTypeMapping?.GetForMember(originalFieldName)?.ExistingMember;
                var serialization = sourceTypeMapping?.GetForMemberSerialization(existingMember);
                var field = existingMember is not null
                    ? CreateFieldFromExisting(existingMember, serialization, propertyType, inputModelProperty, typeFactory, optionalViaNullability)
                    : CreateField(originalFieldName, propertyType, usage, inputModelProperty, optionalViaNullability);

                // TODO -- enable this
                // if (existingMember is not null)
                // {
                //     visitedMembers.Add(existingMember);
                // }

                fields.Add(field);
                fieldsToInputs[field] = inputModelProperty;

                var parameter = Parameter.FromSchemaProperty(inputModelProperty, existingMember is IFieldSymbol ? inputModelProperty.CSharpName().ToVariableName() : field.Name.ToVariableName(), field.Type);
                parametersToFields[parameter.Name] = field;
                // all properties should be included in the serialization ctor
                serializationParameters.Add(parameter);
                // only required + not readonly + not literal property could get into the public ctor
                if (inputModelProperty.IsRequired && !inputModelProperty.IsReadOnly && inputModelProperty.Schema is not ConstantSchema)
                {
                    publicParameters.Add(parameter);
                }
            }

            // TODO -- adding the AdditionalProperties property

            // TODO -- adding the leftover members from the source type
            _fields = fields;
            _fieldsToInputs = fieldsToInputs;
            _parameterNamesToFields = parametersToFields;

            PublicConstructorParameters = publicParameters;
            SerializationParameters = serializationParameters;
        }

        public FieldDeclaration GetFieldByParameter(Parameter parameter) => _parameterNamesToFields[parameter.Name];
        public bool TryGetFieldByParameter(Parameter parameter, [MaybeNullWhen(false)] out FieldDeclaration fieldDeclaration) => _parameterNamesToFields.TryGetValue(parameter.Name, out fieldDeclaration);
        public Property GetInputByField(FieldDeclaration field) => _fieldsToInputs[field];
        public ObjectTypeProperty? AdditionalPropertiesProperty => null;

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static FieldDeclaration CreateField(string fieldName, CSharpType originalType, SchemaTypeUsage usage, Property inputModelProperty, bool optionalViaNullability)
        {
            var propertyIsCollection = inputModelProperty.Schema is ArraySchema or DictionarySchema;
            var propertyIsRequiredInNonRoundTripModel = !usage.HasFlag(SchemaTypeUsage.RoundTrip) && inputModelProperty.IsRequired;
            var propertyIsOptionalInOutputModel = !usage.HasFlag(SchemaTypeUsage.Input) && !inputModelProperty.IsRequired;
            var propertyIsLiteralType = inputModelProperty.Schema is ConstantSchema;
            var propertyIsDiscriminator = inputModelProperty.IsDiscriminator ?? false;
            var propertyIsNullable = inputModelProperty.IsNullable;
            var isPropertyBag = false; // SchemaObjectType is never a property bag
            var propertyShouldOmitSetter = !propertyIsDiscriminator && // if a property is a discriminator, it should always has its setter
                (inputModelProperty.IsReadOnly || // a property will not have setter when it is readonly
                (propertyIsLiteralType && inputModelProperty.IsRequired) || // a property will not have setter when it is required literal type
                (propertyIsCollection && (!propertyIsNullable || isPropertyBag)) || // a property will not have setter when it is a non-nullable collection, in other words, a collection property only has setter when it is nullable
                propertyIsRequiredInNonRoundTripModel || // a property will explicitly omit its setter when it is useless
                propertyIsOptionalInOutputModel); // a property will explicitly omit its setter when it is useless

            var valueType = originalType;
            if (optionalViaNullability)
            {
                originalType = originalType.WithNullable(true);
            }

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
                $"{BuilderHelpers.EscapeXmlDocDescription(inputModelProperty.Language.Default.Description)}",
                fieldModifiers,
                originalType,
                valueType,
                declaration,
                GetPropertyDefaultValue(originalType, inputModelProperty),
                inputModelProperty.IsRequired,
                GetSerializationFormat(inputModelProperty),
                OptionalViaNullability: optionalViaNullability,
                IsField: false,
                WriteAsProperty: true,
                SetterModifiers: setterModifiers);
        }

        private static FieldDeclaration CreateFieldFromExisting(ISymbol existingMember, SourcePropertySerializationMapping? serialization, CSharpType originalType, Property inputModelProperty, TypeFactory typeFactory, bool optionalViaNullability)
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
                SerializationFormat: GetSerializationFormat(inputModelProperty),
                IsField: existingMember is IFieldSymbol,
                WriteAsProperty: writeAsProperty,
                OptionalViaNullability: optionalViaNullability,
                SerializationMapping: serialization);
        }

        // TODO -- this is temporarily unused.
        private static bool IsReadOnly(ISymbol existingMember) => existingMember switch
        {
            IPropertySymbol propertySymbol => propertySymbol.SetMethod == null,
            IFieldSymbol fieldSymbol => fieldSymbol.IsReadOnly,
            _ => throw new NotSupportedException($"'{existingMember.ContainingType.Name}.{existingMember.Name}' must be either field or property.")
        };

        private static CSharpType GetPropertyDefaultType(in SchemaTypeUsage usage, in Property property, TypeFactory typeFactory)
        {
            var propertyType = typeFactory.CreateType(property.Schema, property.IsNullable, property.Schema is AnyObjectSchema ? property.Extensions?.Format : property.Schema.Extensions?.Format, property: property);

            if (!usage.HasFlag(SchemaTypeUsage.Input) ||
                property.IsReadOnly)
            {
                propertyType = TypeFactory.GetOutputType(propertyType);
            }

            return propertyType;
        }

        private static FormattableString? GetPropertyDefaultValue(CSharpType propertyType, Property inputModelProperty)
        {
            // The Property of SchemaObjectType never handles default values

            // we check if this property is a literal type, and use the literal type as its default value.
            if (inputModelProperty.Schema is not ConstantSchema constantSchema || !inputModelProperty.IsRequired)
            {
                return null;
            }

            var constant = constantSchema.Value.Value != null ?
                        BuilderHelpers.ParseConstant(constantSchema.Value.Value, propertyType) :
                        Constant.NewInstanceOf(propertyType);

            return constant.GetConstantFormattable();
        }

        // TODO -- SchemaObject does not have SerializationFormat for properties yet.
        private static SerializationFormat GetSerializationFormat(Property property) => SerializationFormat.Default;
    }
}
