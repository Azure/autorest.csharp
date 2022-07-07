﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(MemberDeclarationOptions declaration, string description, bool isReadOnly, Property? schemaProperty, CSharpType? valueType = null, bool optionalViaNullability = false)
        {
            Description = description;
            IsReadOnly = isReadOnly;
            SchemaProperty = schemaProperty;
            OptionalViaNullability = optionalViaNullability;
            ValueType = valueType ?? declaration.Type;
            Declaration = declaration;
        }

        public MemberDeclarationOptions Declaration { get; }
        public string Description { get; }
        public Property? SchemaProperty { get; }

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

        private bool IsDiscriminator() => SchemaProperty?.IsDiscriminator is true;

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
    }
}
