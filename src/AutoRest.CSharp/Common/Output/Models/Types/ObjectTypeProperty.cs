// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Serialization;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(FieldDeclaration field, InputModelProperty inputModelProperty, ObjectType enclosingType, SerializationFormat serializationFormat)
            : this(declaration: new MemberDeclarationOptions(field.Accessibility, field.Name, field.Type),
                  parameterDescription: field.Description?.ToString() ?? string.Empty,
                  isReadOnly: field.Modifiers.HasFlag(FieldModifiers.ReadOnly),
                  schemaProperty: null,
                  isRequired: field.IsRequired,
                  inputModelProperty: inputModelProperty,
                  getterModifiers: field.GetterModifiers,
                  setterModifiers: field.SetterModifiers,
                  serializationFormat: serializationFormat,
                  serializationMapping: field.SerializationMapping)
        {
            InitializationValue = field.DefaultValue;
        }

        public ObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, Property? schemaProperty, CSharpType? valueType = null, bool optionalViaNullability = false)
            : this(declaration, parameterDescription, isReadOnly, schemaProperty, schemaProperty?.IsRequired ?? false, valueType, optionalViaNullability)
        {
        }

        private ObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, Property? schemaProperty, bool isRequired, CSharpType? valueType = null, bool optionalViaNullability = false, InputModelProperty? inputModelProperty = null, bool isFlattenedProperty = false, FieldModifiers? getterModifiers = null, FieldModifiers? setterModifiers = null, SerializationFormat serializationFormat = SerializationFormat.Default, SourcePropertySerializationMapping? serializationMapping = null)
        {
            IsReadOnly = isReadOnly;
            SchemaProperty = schemaProperty;
            OptionalViaNullability = optionalViaNullability;
            ValueType = valueType ?? declaration.Type;
            Declaration = declaration;
            IsRequired = isRequired;
            InputModelProperty = inputModelProperty;
            _baseParameterDescription = parameterDescription;
            Description = string.IsNullOrEmpty(parameterDescription) ? CreateDefaultPropertyDescription(Declaration.Name, isReadOnly).ToString() : parameterDescription;
            IsFlattenedProperty = isFlattenedProperty;
            GetterModifiers = getterModifiers;
            SetterModifiers = setterModifiers;
            SerializationFormat = serializationFormat;
            SerializationMapping = serializationMapping;
        }

        public ObjectTypeProperty MarkFlatten()
        {
            var newDeclaration = new MemberDeclarationOptions("internal", Declaration.Name, Declaration.Type);

            return new ObjectTypeProperty(
                newDeclaration,
                _baseParameterDescription,
                IsReadOnly,
                SchemaProperty,
                IsRequired,
                valueType: ValueType,
                optionalViaNullability: OptionalViaNullability,
                inputModelProperty: InputModelProperty,
                isFlattenedProperty: true);
        }

        public SerializationFormat SerializationFormat { get; }

        public FormattableString? InitializationValue { get; }

        private bool IsFlattenedProperty { get; }

        private FlattenedObjectTypeProperty? _flattenedProperty;
        public FlattenedObjectTypeProperty? FlattenedProperty => EnsureFlattenedProperty();

        private FlattenedObjectTypeProperty? EnsureFlattenedProperty()
        {
            if (IsFlattenedProperty && _flattenedProperty == null)
            {
                var hierarchyStack = FlattenedObjectTypeProperty.GetHierarchyStack(this);
                // we can only get in this method when the property has a single property type, therefore the hierarchy stack here is guaranteed to have at least two values
                var innerProperty = hierarchyStack.Pop();
                var immediateParentProperty = hierarchyStack.Pop();

                var myPropertyName = FlattenedObjectTypeProperty.GetCombinedPropertyName(innerProperty, immediateParentProperty);
                var childPropertyName = this.Equals(immediateParentProperty) ? innerProperty.Declaration.Name : myPropertyName;

                var propertyType = innerProperty.Declaration.Type;

                var isOverriddenValueType = innerProperty.Declaration.Type.IsValueType && !innerProperty.Declaration.Type.IsNullable;
                if (isOverriddenValueType)
                    propertyType = propertyType.WithNullable(isOverriddenValueType);

                var declaration = new MemberDeclarationOptions(innerProperty.Declaration.Accessibility, myPropertyName, propertyType);

                // determines whether this property should has a setter
                var (isReadOnly, includeGetterNullCheck, includeSetterNullCheck) = FlattenedObjectTypeProperty.GetFlags(this, innerProperty);

                _flattenedProperty = new FlattenedObjectTypeProperty(declaration, innerProperty._baseParameterDescription, this, isReadOnly, includeGetterNullCheck, includeSetterNullCheck, childPropertyName, isOverriddenValueType);
            }

            return _flattenedProperty;
        }

        public virtual Stack<ObjectTypeProperty> BuildHierarchyStack()
        {
            if (FlattenedProperty != null)
                return FlattenedProperty.BuildHierarchyStack();

            var stack = new Stack<ObjectTypeProperty>();
            stack.Push(this);

            return stack;
        }

        public static FormattableString CreateDefaultPropertyDescription(string nameToUse, bool isReadOnly)
        {
            String splitDeclarationName = string.Join(" ", Utilities.StringExtensions.SplitByCamelCase(nameToUse)).ToLower();
            if (isReadOnly)
            {
                return $"Gets the {splitDeclarationName}";
            }
            else
            {
                return $"Gets or sets the {splitDeclarationName}";
            }
        }

        public bool IsRequired { get; }
        public MemberDeclarationOptions Declaration { get; }
        public string Description { get; }
        private string? _propertyDescription;
        public string PropertyDescription => _propertyDescription ??= Description + CreateExtraPropertyDiscriminatorSummary(ValueType);
        public Property? SchemaProperty { get; }
        public InputModelProperty? InputModelProperty { get; }
        private string? _parameterDescription;
        private string _baseParameterDescription; // inherited type "FlattenedObjectTypeProperty" need to pass this value into the base constructor so that some appended information will not be appended again in the flattened property
        public string ParameterDescription => _parameterDescription ??= _baseParameterDescription + CreateExtraPropertyDiscriminatorSummary(ValueType);

        /// <summary>
        /// Gets or sets the value indicating whether nullable type of this property represents optionality of the value.
        /// </summary>
        public bool OptionalViaNullability { get; }

        /// <summary>
        /// When property is not required we transform the type to be able to express "omitted" value.
        /// For example we turn int type into int?.
        /// ValueType property contains the original type the property had before the transformation was applied to it.
        /// </summary>
        public CSharpType ValueType { get; }
        public bool IsReadOnly { get; }

        public FieldModifiers? GetterModifiers { get; }
        public FieldModifiers? SetterModifiers { get; }

        public SourcePropertySerializationMapping? SerializationMapping { get; }

        internal string CreateExtraDescriptionWithManagedServiceIdentity()
        {
            var extraDescription = string.Empty;
            var originalObjSchema = SchemaProperty?.Schema as ObjectSchema;
            var identityTypeSchema = originalObjSchema?.GetAllProperties()!.FirstOrDefault(p => p.SerializedName == "type")!.Schema;
            if (identityTypeSchema != null)
            {
                var supportedTypesToShow = new List<string>();
                var commonMsiSupportedTypeCount = typeof(ManagedServiceIdentityType).GetProperties().Length;
                // unwrap constant schema if it is
                if (identityTypeSchema is ConstantSchema constantIdentitySchema && constantIdentitySchema.ValueType is ChoiceSchema identityTypeChoiceSchema)
                    identityTypeSchema = identityTypeChoiceSchema;

                if (identityTypeSchema is ChoiceSchema choiceSchema && choiceSchema.Choices.Count < commonMsiSupportedTypeCount)
                {
                    supportedTypesToShow = choiceSchema.Choices.Select(c => c.Value).ToList();
                }
                else if (identityTypeSchema is SealedChoiceSchema sealedChoiceSchema && sealedChoiceSchema.Choices.Count < commonMsiSupportedTypeCount)
                {
                    supportedTypesToShow = sealedChoiceSchema.Choices.Select(c => c.Value).ToList();
                }
                if (supportedTypesToShow.Count > 0)
                {
                    extraDescription = $"Current supported identity types: {string.Join(", ", supportedTypesToShow)}";
                }
            }
            return extraDescription;
        }

        private static string CreateExtraPropertyDiscriminatorSummary(CSharpType valueType)
        {
            string updatedDescription = string.Empty;
            if (valueType.IsFrameworkType)
            {
                if (TypeFactory.IsList(valueType))
                {
                    if (!valueType.Arguments.First().IsFrameworkType && valueType.Arguments.First().Implementation is ObjectType objectType)
                    {
                        updatedDescription = objectType.CreateExtraDescriptionWithDiscriminator();
                    }
                }
                else if (TypeFactory.IsDictionary(valueType))
                {
                    var objectTypes = valueType.Arguments.Where(arg => !arg.IsFrameworkType && arg.Implementation is ObjectType);
                    if (objectTypes.Count() > 0)
                    {
                        var subDescription = objectTypes.Select(o => ((ObjectType)o.Implementation).CreateExtraDescriptionWithDiscriminator());
                        updatedDescription = string.Join("", subDescription);
                    }
                }
            }
            else if (valueType.Implementation is ObjectType objectType)
            {
                updatedDescription = objectType.CreateExtraDescriptionWithDiscriminator();
            }
            return updatedDescription;
        }
    }
}
