// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(FieldDeclaration field, InputModelProperty inputModelProperty, ObjectType enclosingType)
            : this(new MemberDeclarationOptions(field.Accessibility, field.Name, field.Type), field.Description?.ToString() ?? String.Empty, field.Modifiers.HasFlag(FieldModifiers.ReadOnly), null, field.IsRequired, inputModelProperty: inputModelProperty)
        {
        }

        public ObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, Property? schemaProperty, CSharpType? valueType = null, bool optionalViaNullability = false)
            :this(declaration, parameterDescription, isReadOnly, schemaProperty, (schemaProperty is null ? false : schemaProperty.IsRequired), valueType, optionalViaNullability)
        {
        }

        private ObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, Property? schemaProperty, bool isRequired, CSharpType? valueType = null, bool optionalViaNullability = false, InputModelProperty? inputModelProperty = null)
        {
            IsReadOnly = isReadOnly;
            SchemaProperty = schemaProperty;
            OptionalViaNullability = optionalViaNullability;
            ValueType = valueType ?? declaration.Type;
            Declaration = declaration;
            IsRequired = isRequired;
            InputModelProperty = inputModelProperty;
            _baseParameterDescription = parameterDescription;
            Description = string.IsNullOrEmpty(parameterDescription) ? CreateDefaultPropertyDescription(Declaration.Name, IsReadOnly).ToString() : parameterDescription;
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
        private string _baseParameterDescription;
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

        private bool IsDiscriminator() => SchemaProperty?.IsDiscriminator is true || InputModelProperty?.IsDiscriminator is true;

        public bool IsSinglePropertyObject([MaybeNullWhen(false)] out ObjectTypeProperty innerProperty)
        {
            innerProperty = null;

            if (this.ValueType.IsFrameworkType)
                return false;

            if (this.ValueType.Implementation is not ObjectType objType)
                return false;

            var properties = objType.EnumerateHierarchy().SelectMany(obj => obj.Properties);
            bool isSingleProperty = properties.Count() == 1 && !properties.First().IsDiscriminator();

            if (isSingleProperty)
                innerProperty = properties.First();

            return isSingleProperty;
        }

        internal string GetCombinedPropertyName(ObjectTypeProperty immediateParentProperty)
        {
            var immediateParentPropertyName = GetPropertyName(immediateParentProperty.Declaration);

            if (Declaration.Type.Equals(typeof(bool)) || Declaration.Type.Equals(typeof(bool?)))
            {
                return Declaration.Name.Equals("Enabled", StringComparison.Ordinal) ? $"{immediateParentPropertyName}{Declaration.Name}" : Declaration.Name;
            }

            if (Declaration.Name.Equals("Id", StringComparison.Ordinal))
                return $"{immediateParentPropertyName}{Declaration.Name}";

            if (immediateParentPropertyName.EndsWith(Declaration.Name, StringComparison.Ordinal))
                return immediateParentPropertyName;

            var parentWords = immediateParentPropertyName.SplitByCamelCase();
            if (immediateParentPropertyName.EndsWith("Profile", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Policy", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Configuration", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Properties", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Settings", StringComparison.Ordinal))
            {
                parentWords = parentWords.Take(parentWords.Count() - 1);
            }

            var parentWordArray = parentWords.ToArray();
            var parentWordsHash = new HashSet<string>(parentWordArray);
            var nameWords = Declaration.Name.SplitByCamelCase().ToArray();
            var lastWord = string.Empty;
            for (int i = 0; i < nameWords.Length; i++)
            {
                var word = nameWords[i];
                lastWord = word;
                if (parentWordsHash.Contains(word))
                {
                    if (i == nameWords.Length - 2 && parentWordArray.Length >= 2 && word.Equals(parentWordArray[parentWordArray.Length - 2], StringComparison.Ordinal))
                    {
                        parentWords = parentWords.Take(parentWords.Count() - 2);
                        break;
                    }
                    {
                        return Declaration.Name;
                    }
                }

                //need to depluralize the last word and check
                if (i == nameWords.Length - 1 && parentWordsHash.Contains(lastWord.ToSingular(false)))
                    return Declaration.Name;
            }

            immediateParentPropertyName = string.Join("", parentWords);

            return $"{immediateParentPropertyName}{Declaration.Name}";
        }

        internal static string GetPropertyName(MemberDeclarationOptions property)
        {
            const string properties = "Properties";
            if (property.Name.Equals(properties, StringComparison.Ordinal))
            {
                string typeName = property.Type.Name;
                int index = typeName.IndexOf(properties);
                if (index > -1 && index + properties.Length == typeName.Length)
                    return typeName.Substring(0, index);

                return typeName;
            }
            return property.Name;
        }

        internal string CreateExtraDescriptionWithManagedServiceIdentity()
        {
            var extraDescription = string.Empty;
            var originalObjSchema = SchemaProperty?.Schema as ObjectSchema;
            var identityTypeSchema = originalObjSchema?.GetAllProperties()?.FirstOrDefault(p => p.SerializedName == "type")?.Schema;
            if (identityTypeSchema != null)
            {
                var supportedTypesToShow = new List<string>();
                var commonMsiSupportedTypeCount = typeof(ManagedServiceIdentityType).GetProperties().Length;
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

        public Stack<ObjectTypeProperty> GetHeirarchyStack()
        {
            var heirarchyStack = new Stack<ObjectTypeProperty>();
            heirarchyStack.Push(this);
            BuildHeirarchy(this, heirarchyStack);
            return heirarchyStack;
        }

        private static void BuildHeirarchy(ObjectTypeProperty property, Stack<ObjectTypeProperty> heirarchyStack)
        {
            //if we get back the same property exit early since this means we have a single property type which references itself
            if (property.IsSinglePropertyObject(out var childProp) && !property.Equals(childProp))
            {
                heirarchyStack.Push(childProp);
                BuildHeirarchy(childProp, heirarchyStack);
            }
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
