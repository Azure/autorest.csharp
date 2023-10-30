// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(FieldDeclaration field, InputModelProperty inputModelProperty, ObjectType enclosingType)
            : this(declaration: new MemberDeclarationOptions(field.Accessibility, field.Name, field.Type),
                  parameterDescription: field.Description?.ToString() ?? string.Empty,
                  isReadOnly: field.Modifiers.HasFlag(FieldModifiers.ReadOnly),
                  schemaProperty: null,
                  isRequired: field.IsRequired,
                  valueType: field.ValueType,
                  inputModelProperty: inputModelProperty,
                  optionalViaNullability: field.OptionalViaNullability,
                  getterModifiers: field.GetterModifiers,
                  setterModifiers: field.SetterModifiers,
                  serializationFormat: field.SerializationFormat,
                  serializationMapping: field.SerializationMapping)
        {
            InitializationValue = field.DefaultValue;
        }

        public ObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, Property? schemaProperty, CSharpType? valueType = null, bool optionalViaNullability = false, SourcePropertySerializationMapping? serializationMapping = null)
            : this(declaration, parameterDescription, isReadOnly, schemaProperty, schemaProperty?.IsRequired ?? false, valueType: valueType, optionalViaNullability: optionalViaNullability, serializationMapping: serializationMapping)
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
            SerializationFormat = serializationFormat;
            SerializationMapping = serializationMapping;
            Description = CreatePropertyDescription(parameterDescription, isReadOnly).ToString();
            IsFlattenedProperty = isFlattenedProperty;
            GetterModifiers = getterModifiers;
            SetterModifiers = setterModifiers;
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
        private FormattableString? _propertyDescription;
        public FormattableString PropertyDescription => _propertyDescription ??= $"{Description}{CreateExtraPropertyDiscriminatorSummary(ValueType)}";
        public Property? SchemaProperty { get; }
        public InputModelProperty? InputModelProperty { get; }
        private FormattableString? _parameterDescription;
        private string _baseParameterDescription; // inherited type "FlattenedObjectTypeProperty" need to pass this value into the base constructor so that some appended information will not be appended again in the flattened property
        public FormattableString ParameterDescription => _parameterDescription ??= $"{_baseParameterDescription}{CreateExtraPropertyDiscriminatorSummary(ValueType)}";

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

        /// <summary>
        /// This method attempts to retrieve the description for each of the union type items
        /// by attempting to convert each of the union type items to a CSharpType and then getting
        /// the friendly name of the type. If the friendly name cannot be retrieved, or the union item cannot
        /// be converted to a CSharpType, then the name of the type is used to construct the description.
        /// </summary>
        /// <param name="unionItems">the list of union type items.</param>
        /// <returns>A list of strings representing the description of each union item and their corresponding
        /// CSharp type name.
        /// </returns>
        public static IReadOnlyList<string> GetUnionTypesDescriptions(IReadOnlyList<InputType> unionItems)
        {
            var values = new List<string>();

            foreach (InputType item in unionItems)
            {
                if (item != null)
                {
                    var friendlyTypeName = string.Empty;
                    try
                    {
                        CSharpType? csharpType = TypeFactory.CreateSimpleType(item);
                        if (csharpType != null)
                        {
                            friendlyTypeName = csharpType.TryGetCSharpFriendlyName(out var keywordName) ? keywordName : csharpType.Name;
                        }
                    }
                    catch
                    {
                        friendlyTypeName = item.Name;
                    }

                    if (!friendlyTypeName.IsNullOrEmpty())
                    {
                        var description = $"{friendlyTypeName}";

                        if (item is InputLiteralType)
                        {
                            description = $"{friendlyTypeName} literal";
                        }
                        else if (item is InputListType listItemType)
                        {
                            var nestedDescription = BuilderHelpers.EscapeXmlDocDescription(ConstructTypeStringForNestedProp(listItemType));
                            description = $"{nestedDescription}";
                        }

                        values.Add(description);
                    }
                }
            }

            return values.Distinct().ToList();
        }

        /// <summary>
        /// Constructs the type string for a property. If the property is a list, then the type string is constructed
        /// recursively by calling this method again with the list item type.
        /// </summary>
        /// <param name="input">The input property.</param>
        /// <returns>The constructed type string for the property.</returns>
        public static string ConstructTypeStringForNestedProp(InputType input)
        {
            string itemName = input.Name;
            // try to get the friendly name of the item
            try
            {
                CSharpType? itemCsharpType = TypeFactory.CreateSimpleType(input);
                if (itemCsharpType != null)
                {
                    var itemFriendlyName = itemCsharpType.TryGetCSharpFriendlyName(out var elementKeywordName) ? elementKeywordName : itemCsharpType.Name;
                    itemName = !string.IsNullOrEmpty(itemFriendlyName) ? itemFriendlyName : itemName;
                }
            }
            catch
            {
                itemName = input.Name;
            }

            var typeDescription = $"{itemName}";
            InputType? elementType = null;

            if (input is InputListType listItemType)
            {
                elementType = listItemType.ElementType;
            }

            // validate if the item contains an element type
            if (elementType != null)
            {
                if (elementType is InputListType elementItemType)
                {
                    typeDescription += $"<{ConstructTypeStringForNestedProp(elementItemType)}>";
                }
                else
                {
                    typeDescription += $"<{ConstructTypeStringForNestedProp(elementType)}>";
                }
            }

            return typeDescription;
        }

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

        /// <summary>
        /// This method is used to create the description for the property. It will append the extra description for the property if it is a binary data property.
        /// </summary>
        /// <param name="parameterDescription">The parameter description.</param>
        /// <param name="isPropReadOnly">Flag to determine if a property is read only.</param>
        /// <returns>The formatted property description string.</returns>
        internal FormattableString CreatePropertyDescription(string parameterDescription, bool isPropReadOnly)
        {
            FormattableString description;
            if (string.IsNullOrEmpty(parameterDescription))
            {
                description = CreateDefaultPropertyDescription(Declaration.Name, isPropReadOnly);
            }
            else
            {
                description = $"{parameterDescription}";
            }

            FormattableString binaryDataExtraDescription = CreateBinaryDataExtraDescription(InputModelProperty, Declaration.Type, SerializationFormat);
            description = $"{description}{binaryDataExtraDescription}";

            return description;
        }

        /// <summary>
        /// This method will construct an additional description for properties that are binary data. For properties whose values are union types,
        /// the description will include the types of values that are allowed.
        /// </summary>
        /// <param name="inputModelProp">The InputModelProperty of the property.</param>
        /// <param name="type">The CSharpType of the property.</param>
        /// <param name="serializationFormat">The serialization format of the property.</param>
        /// <returns>The formatted description string for the property.</returns>
        private FormattableString CreateBinaryDataExtraDescription(InputModelProperty? inputModelProp, CSharpType type, SerializationFormat serializationFormat)
        {
            if (type.IsFrameworkType)
            {
                string typeSpecificDesc;
                IReadOnlyList<string> unionTypeDescriptions = Array.Empty<string>();

                if (inputModelProp != null)
                {
                    InputType? inputType = inputModelProp.Type;
                    if (inputType != null && inputType is InputUnionType union)
                    {
                        // get the union types, if any
                        IReadOnlyList<InputType> items = union.UnionItemTypes;
                        unionTypeDescriptions = GetUnionTypesDescriptions(items);

                    }
                }

                if (type.FrameworkType == typeof(BinaryData))
                {
                    typeSpecificDesc = "this property";
                    return ConstructBinaryDataDescription(typeSpecificDesc, serializationFormat, unionTypeDescriptions);
                }
                if (TypeFactory.IsList(type) &&
                    type.Arguments[0].IsFrameworkType &&
                    type.Arguments[0].FrameworkType == typeof(BinaryData))
                {
                    typeSpecificDesc = "the element of this property";
                    return ConstructBinaryDataDescription(typeSpecificDesc, serializationFormat, unionTypeDescriptions);
                }
                if (TypeFactory.IsDictionary(type) &&
                    type.Arguments[1].IsFrameworkType &&
                    type.Arguments[1].FrameworkType == typeof(BinaryData))
                {
                    typeSpecificDesc = "the value of this property";
                    return ConstructBinaryDataDescription(typeSpecificDesc, serializationFormat, unionTypeDescriptions);
                }
            }
            return $"";
        }

        private FormattableString ConstructBinaryDataDescription(string typeSpecificDesc, SerializationFormat serializationFormat, IReadOnlyList<string> unionTypeDescriptions)
        {
            string unionTypesAdditionalDescription = string.Empty;

            if (unionTypeDescriptions.Count > 0)
            {
                unionTypesAdditionalDescription = $"\n<remarks>\nThe following types are supported by this property:\n<list type=\"bullet\">\n";
                foreach (string unionTypeDescription in unionTypeDescriptions)
                {
                    unionTypesAdditionalDescription += $"<item>\n{unionTypeDescription}\n</item>\n";
                }
                unionTypesAdditionalDescription += "</list>\n</remarks>";
            }
            switch (serializationFormat)
            {
                case SerializationFormat.Bytes_Base64Url: //intentional fall through
                case SerializationFormat.Bytes_Base64:
                    return $@"
<para>
To assign a byte[] to {typeSpecificDesc} use <see cref=""{typeof(BinaryData)}.FromBytes(byte[])""/>.
The byte[] will be serialized to a Base64 encoded string.
</para>
<para>{unionTypesAdditionalDescription}
Examples:
<list type=""bullet"">
<item>
<term>BinaryData.FromBytes(new byte[] {{ 1, 2, 3 }})</term>
<description>Creates a payload of ""AQID"".</description>
</item>
</list>
</para>";

                default:
                    return $@"
<para>
To assign an object to {typeSpecificDesc} use <see cref=""{typeof(BinaryData)}.FromObjectAsJson{{T}}(T, System.Text.Json.JsonSerializerOptions?)""/>.
</para>
<para>
To assign an already formatted json string to this property use <see cref=""{typeof(BinaryData)}.FromString(string)""/>.
</para>
<para>{unionTypesAdditionalDescription}
Examples:
<list type=""bullet"">
<item>
<term>BinaryData.FromObjectAsJson(""foo"")</term>
<description>Creates a payload of ""foo"".</description>
</item>
<item>
<term>BinaryData.FromString(""\""foo\"""")</term>
<description>Creates a payload of ""foo"".</description>
</item>
<item>
<term>BinaryData.FromObjectAsJson(new {{ key = ""value"" }})</term>
<description>Creates a payload of {{ ""key"": ""value"" }}.</description>
</item>
<item>
<term>BinaryData.FromString(""{{\""key\"": \""value\""}}"")</term>
<description>Creates a payload of {{ ""key"": ""value"" }}.</description>
</item>
</list>
</para>";
            }
        }

        private static FormattableString CreateExtraPropertyDiscriminatorSummary(CSharpType valueType)
        {
            FormattableString? updatedDescription = null;
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
                        var subDescription = objectTypes.Select(o => ((ObjectType)o.Implementation).CreateExtraDescriptionWithDiscriminator()).ToArray();
                        updatedDescription = subDescription.Join("");
                    }
                }
            }
            else if (valueType.Implementation is ObjectType objectType)
            {
                updatedDescription = objectType.CreateExtraDescriptionWithDiscriminator();
            }
            return updatedDescription ?? $"";
        }

        public override string ToString()
        {
            return $"ObjectTypeProperty {{Name: {Declaration.Name}, Type: {Declaration.Type}}}";
        }
    }
}
