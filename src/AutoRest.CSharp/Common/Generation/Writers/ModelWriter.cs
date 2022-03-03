// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ModelWriter
    {
        public void WriteModel(CodeWriter writer, TypeProvider model)
        {
            switch (model)
            {
                case SchemaObjectType objectSchema:
                    WriteObjectSchema(writer, objectSchema);
                    break;
                case EnumType e when e.IsExtendable:
                    WriteChoiceSchema(writer, e);
                    break;
                case EnumType e when !e.IsExtendable:
                    WriteSealedChoiceSchema(writer, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void WriteObjectSchema(CodeWriter writer, SchemaObjectType schema)
        {
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                List<CSharpType> implementsTypes = new List<CSharpType>();
                if (schema.Inherits != null)
                {
                    implementsTypes.Add(schema.Inherits);
                }

                writer.WriteXmlDocumentationSummary($"{schema.Description}");
                AddClassAttributes(writer, schema);

                if (schema.IsStruct)
                {
                    writer.Append($"{schema.Declaration.Accessibility} readonly partial struct {schema.Declaration.Name}");
                }
                else
                {
                    writer.Append($"{schema.Declaration.Accessibility} {GetAbstract(schema)}partial class {schema.Declaration.Name}");
                }

                if (implementsTypes.Any())
                {
                    writer.AppendRaw(" : ");
                    foreach (var type in implementsTypes)
                    {
                        writer.Append($"{type} ,");
                    }
                    writer.RemoveTrailingComma();
                }

                writer.Line();
                using (writer.Scope())
                {
                    WriteConstructor(writer, schema);

                    WriteProperties(writer, schema);
                }
            }
        }

        protected virtual void WriteProperties(CodeWriter writer, ObjectType schema)
        {
            foreach (var property in schema.Properties)
            {
                Stack<ObjectTypeProperty> heiarchyStack = new Stack<ObjectTypeProperty>();
                heiarchyStack.Push(property);
                BuildHeirarchy(property, heiarchyStack);
                if (Configuration.AzureArm && heiarchyStack.Count > 1)
                {
                    var innerProperty = heiarchyStack.Pop();
                    var immediateParentProperty = heiarchyStack.Pop();
                    WriteProperty(writer, property, "internal");

                    string immediateParentPropertyName = GetPropertyName(immediateParentProperty.Declaration);
                    string myPropertyName = GetCombinedPropertyName(immediateParentPropertyName, innerProperty.Declaration);
                    string childPropertyName = property.Equals(immediateParentProperty) ? innerProperty.Declaration.Name : myPropertyName;
                    writer.WriteXmlDocumentationSummary(CreatePropertyDescription(innerProperty, myPropertyName));
                    using (writer.Scope($"{innerProperty.Declaration.Accessibility} {innerProperty.Declaration.Type} {myPropertyName:D}"))
                    {
                        if (!property.IsReadOnly && innerProperty.IsReadOnly)
                        {
                            if (HasDefaultPublicCtor(property))
                            {
                                if (innerProperty.Declaration.Type.Arguments.Length > 0)
                                {
                                    using (writer.Scope($"get"))
                                    {
                                        writer.Line($"if ({property.Declaration.Name:D} is null)");
                                        writer.Line($"{property.Declaration.Name:D} = new {property.Declaration.Type}();");
                                        writer.Line($"return {property.Declaration.Name:D}.{childPropertyName};");
                                    }
                                }
                                else
                                {
                                    writer.Line($"get => {property.Declaration.Name:D} is null ? default({innerProperty.Declaration.Type}) : {property.Declaration.Name:D}.{childPropertyName};");
                                }
                            }
                            else if (HasCtorWithSingleParam(property, innerProperty))
                            {
                                writer.Line($"get => {property.Declaration.Name:D} is null ? default({innerProperty.Declaration.Type}) : {property.Declaration.Name:D}.{childPropertyName};");
                                writer.Line($"set => {property.Declaration.Name:D} = new {property.Declaration.Type}(value);");
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unsupported parameter access combination for {schema.Type.Name}, Property {property.Declaration.Name}, ChildProperty {innerProperty.Declaration.Name}");
                            }
                        }
                        else if (!property.IsReadOnly && !innerProperty.IsReadOnly)
                        {
                            writer.Line($"get => {property.Declaration.Name:D} is null ? default({innerProperty.Declaration.Type}) : {property.Declaration.Name:D}.{childPropertyName};");
                            if (HasDefaultPublicCtor(property))
                            {
                                using (writer.Scope($"set"))
                                {
                                    writer.Line($"if ({property.Declaration.Name:D} is null)");
                                    writer.Line($"{property.Declaration.Name:D} = new {property.Declaration.Type}();");
                                    writer.Line($"{property.Declaration.Name:D}.{childPropertyName} = value;");
                                }
                            }
                            else if (HasCtorWithSingleParam(property, innerProperty))
                            {
                                writer.Line($"set => {property.Declaration.Name:D} = new {property.Declaration.Type}(value);");
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unsupported parameter access combination for {schema.Type.Name}, Property {property.Declaration.Name}, ChildProperty {innerProperty.Declaration.Name}");
                            }
                        }
                        else
                        {
                            writer.Line($"get => {property.Declaration.Name:D}.{childPropertyName};");
                            if (!innerProperty.IsReadOnly)
                                writer.Line($"set => {property.Declaration.Name:D}.{childPropertyName} = value;");
                        }
                    }

                    writer.Line();
                }
                else
                {
                    WriteProperty(writer, property);
                }
            }
        }

        private bool HasCtorWithSingleParam(ObjectTypeProperty property, ObjectTypeProperty innerProperty)
        {
            var type = property.Declaration.Type;
            if (type.IsFrameworkType)
                return false;

            if (type.Implementation is not ObjectType objType)
                return false;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    ctor.Signature.Parameters.Count == 1)
                {
                    var paramType = ctor.Signature.Parameters[0].Type;
                    var propertyType = innerProperty.Declaration.Type;
                    if (paramType.Arguments.Length == 0 && paramType.Equals(propertyType))
                        return true;

                    if (paramType.Arguments.Length == 1 && propertyType.Arguments.Length == 1 && paramType.Arguments[0].Equals(propertyType.Arguments[0]))
                        return true;
                }
            }

            return false;
        }

        private bool HasDefaultPublicCtor(ObjectTypeProperty objectTypeProperty)
        {
            var type = objectTypeProperty.Declaration.Type;
            if (type.IsFrameworkType)
                return true;

            if (type.Implementation is not ObjectType objType)
                return true;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !ctor.Signature.Parameters.Any())
                    return true;
            }

            return false;
        }

        private string GetCombinedPropertyName(string immediateParentPropertyName, MemberDeclarationOptions property)
        {
            string parentName = immediateParentPropertyName;

            if (property.Type.Equals(typeof(bool)) || property.Type.Equals(typeof(bool?)))
            {
                return property.Name.Equals("Enabled", StringComparison.Ordinal) ? $"{parentName}{property.Name}" : property.Name;
            }

            if (property.Name.Equals("Id", StringComparison.Ordinal))
                return $"{parentName}{property.Name}";

            if (immediateParentPropertyName.EndsWith(property.Name, StringComparison.Ordinal))
                return immediateParentPropertyName;

            IEnumerable<string> parentWords = immediateParentPropertyName.SplitByCamelCase();
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
            var nameWords = property.Name.SplitByCamelCase().ToArray();
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
                        return property.Name;
                    }
                }

                //need to depluralize the last word and check
                if (i == nameWords.Length - 1 && parentWordsHash.Contains(lastWord.ToSingular(false)))
                    return property.Name;
            }

            parentName = string.Join("", parentWords);

            return $"{parentName}{property.Name}";
        }

        private string GetPropertyName(MemberDeclarationOptions property)
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

        private void WriteProperty(CodeWriter writer, ObjectTypeProperty property, string? overrideAccessibility = null)
        {
            writer.WriteXmlDocumentationSummary(CreatePropertyDescription(property));
            var accessibility = overrideAccessibility ?? property.Declaration.Accessibility;
            CSharpType propertyType = property.Declaration.Type;
            writer.Append($"{accessibility} {propertyType} {property.Declaration.Name:D}");
            writer.AppendRaw(property.IsReadOnly ? "{ get; }" : "{ get; set; }");

            writer.Line();
        }

        private void BuildHeirarchy(ObjectTypeProperty property, Stack<ObjectTypeProperty> heirarchyStack)
        {
            if (property.IsSinglePropertyObject(out var childProp))
            {
                heirarchyStack.Push(childProp);
                BuildHeirarchy(childProp, heirarchyStack);
            }
        }

        private FormattableString CreatePropertyDescription(ObjectTypeProperty property, string? overrideName = null)
        {
            if (!string.IsNullOrWhiteSpace(property.Description))
            {
                return $"{property.Description}";
            }
            var nameToUse = overrideName ?? property.Declaration.Name;
            String splitDeclarationName = string.Join(" ", StringExtensions.SplitByCamelCase(nameToUse)).ToLower();
            if (property.IsReadOnly)
            {
                return $"Gets the {splitDeclarationName}";
            }
            else
            {
                return $"Gets or sets the {splitDeclarationName}";
            }
        }

        private string GetAbstract(SchemaObjectType schema)
        {
            return schema.IsAbstract ? "abstract " : string.Empty;
        }

        protected virtual void AddClassAttributes(CodeWriter writer, SchemaObjectType schema)
        {
        }

        protected virtual void AddCtorAttribute(CodeWriter writer, ObjectType schema, ObjectTypeConstructor constructor)
        {
        }

        public void WriteConstructor(CodeWriter writer, ObjectType schema)
        {
            foreach (var constructor in schema.Constructors)
            {
                writer.WriteMethodDocumentation(constructor.Signature);
                AddCtorAttribute(writer, schema, constructor);
                using (writer.WriteMethodDeclaration(constructor.Signature))
                {
                    writer.WriteParameterNullChecks(constructor.Signature.Parameters);

                    foreach (var initializer in constructor.Initializers)
                    {
                        writer.Append($"{initializer.Property.Declaration.Name} = ")
                            .WriteReferenceOrConstant(initializer.Value)
                            .WriteConversion(initializer.Value.Type, initializer.Property.Declaration.Type);

                        if (initializer.DefaultValue != null && (!initializer.Value.Type.IsValueType || initializer.Value.Type.IsNullable))
                        {
                            writer.Append($"?? ").WriteReferenceOrConstant(initializer.DefaultValue.Value);
                        }

                        writer.Line($";");
                    }
                }

                writer.Line();
            }
        }

        private void WriteSealedChoiceSchema(CodeWriter writer, EnumType schema)
        {
            if (schema.Declaration.IsUserDefined)
            {
                return;
            }

            using (writer.Namespace(schema.Declaration.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{schema.Description}");

                using (writer.Scope($"{schema.Declaration.Accessibility} enum {schema.Declaration.Name}"))
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary($"{value.Description}");
                        writer.Line($"{value.Declaration.Name},");
                    }
                    writer.RemoveTrailingComma();
                }
            }
        }

        private void WriteChoiceSchema(CodeWriter writer, EnumType schema)
        {
            var cs = schema.Type;
            string name = schema.Declaration.Name;
            var isString = schema.BaseType.FrameworkType == typeof(string);

            using (writer.Namespace(schema.Declaration.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{schema.Description}");

                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (writer.Scope($"{schema.Declaration.Accessibility} readonly partial struct {name}: {implementType}"))
                {
                    writer.Line($"private readonly {schema.BaseType} _value;");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of <see cref=\"{name}\"/>.");

                    if (isString)
                    {
                        writer.WriteXmlDocumentationException(typeof(ArgumentNullException), $"<paramref name=\"value\"/> is null.");
                    }

                    using (writer.Scope($"public {name}({schema.BaseType} value)"))
                    {
                        writer.Append($"_value = value");
                        if (isString)
                        {
                            writer.Append($"?? throw new {typeof(ArgumentNullException)}(nameof(value))");
                        }
                        writer.Line($";");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        var fieldName = GetValueFieldName(name, choice.Declaration.Name, schema.Values);
                        writer.Line($"private const {schema.BaseType} {fieldName} = {choice.Value.Value:L};");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary($"{choice.Description}");
                        var fieldName = GetValueFieldName(name, choice.Declaration.Name, schema.Values);
                        writer.Append($"public static {cs} {choice.Declaration.Name}").AppendRaw("{ get; }").Append($" = new {cs}({fieldName});").Line();
                    }

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are the same.");
                    writer.Line($"public static bool operator ==({cs} left, {cs} right) => left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are not the same.");
                    writer.Line($"public static bool operator !=({cs} left, {cs} right) => !left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Converts a string to a <see cref=\"{name}\"/>.");
                    writer.Line($"public static implicit operator {cs}({schema.BaseType} value) => new {cs}(value);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override bool Equals({typeof(object)} obj) => obj is {cs} other && Equals(other);");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Append($"public bool Equals({cs} other) => ");
                    if (isString)
                    {
                        writer.Line($"{schema.BaseType}.Equals(_value, other._value, {typeof(StringComparison)}.InvariantCultureIgnoreCase);");
                    }
                    else
                    {
                        writer.Line($"{schema.BaseType}.Equals(_value, other._value);");
                    }
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Append($"public override int GetHashCode() => ");
                    if (isString)
                    {
                        writer.Line($"_value?.GetHashCode() ?? 0;");
                    }
                    else
                    {
                        writer.Line($"_value.GetHashCode();");
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Append($"public override {typeof(string)} ToString() => ");

                    if (isString)
                    {
                        writer.Line($"_value;");
                    }
                    else
                    {
                        writer.Line($"_value.ToString({typeof(CultureInfo)}.InvariantCulture);");
                    }
                }
            }
        }

        private string GetValueFieldName(string enumName, string enumValue, IList<EnumTypeValue> enumValues)
        {
            if (enumName != $"{enumValue}Value")
            {
                return $"{enumValue}Value";
            }

            int index = 1;
            foreach (var value in enumValues)
            {
                if (value.Declaration.Name == $"{enumValue}Value{index}")
                {
                    index++;
                }
            }
            return $"{enumValue}Value{index}";
        }

        private void WriteEditorBrowsableFalse(CodeWriter writer)
        {
            writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
        }
    }
}
