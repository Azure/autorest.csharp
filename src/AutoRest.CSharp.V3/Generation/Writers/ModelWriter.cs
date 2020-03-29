// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class ModelWriter
    {
        public void WriteModel(CodeWriter writer, ISchemaType model)
        {
            switch (model)
            {
                case ObjectType objectSchema:
                    WriteObjectSchema(writer, objectSchema);
                    break;
                case EnumType e when e.IsStringBased:
                    WriteChoiceSchema(writer, e);
                    break;
                case EnumType e when !e.IsStringBased:
                    WriteSealedChoiceSchema(writer, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void WriteObjectSchema(CodeWriter writer, ObjectType schema)
        {
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                List<CSharpType> implementsTypes = new List<CSharpType>();
                if (schema.Inherits != null)
                {
                    implementsTypes.Add(schema.Inherits);
                }

                if (schema.ImplementsDictionaryType != null)
                {
                    implementsTypes.Add(schema.ImplementsDictionaryType);
                }

                writer.WriteXmlDocumentationSummary(schema.Description);

                if (schema.IsStruct)
                {
                    writer.Append($"{schema.Declaration.Accessibility} readonly partial struct {schema.Declaration.Name}");
                }
                else
                {
                    writer.Append($"{schema.Declaration.Accessibility} partial class {schema.Declaration.Name}");
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

                    foreach (var property in schema.Properties)
                    {
                        writer.WriteXmlDocumentationSummary(property.Description);

                        CSharpType propertyType = property.Declaration.Type;
                        writer.Append($"{property.Declaration.Accessibility} {propertyType} {property.Declaration.Name:D}");
                        writer.AppendRaw(property.IsReadOnly ? "{ get; }" : "{ get; set; }");

                        writer.Line();
                    }

                    if (schema.AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
                    {
                        var dictionaryType = schema.ImplementsDictionaryType;
                        Debug.Assert(dictionaryType != null);

                        var keyType = typeof(string);
                        var isReadonly = dictionaryType.FrameworkType == typeof(IReadOnlyDictionary<,>);
                        var itemType = dictionaryType.Arguments[1];
                        var keyValuePairType = new CSharpType(typeof(KeyValuePair<,>), keyType, itemType);
                        var iEnumeratorKeyValuePairType = new CSharpType(typeof(IEnumerator<>), keyValuePairType);

                        var collectionType = isReadonly ? typeof(IReadOnlyCollection<>) : typeof(ICollection<>);

                        var iCollectionKeyValuePairType = new CSharpType(collectionType, keyValuePairType);

                        var keyValueCollectionType = isReadonly ? typeof(IEnumerable<>) : typeof(ICollection<>);
                        var iCollectionKeyType = new CSharpType(keyValueCollectionType, keyType);
                        var iCollectionItemType = new CSharpType(keyValueCollectionType, itemType);
                        var iEnumerator = typeof(IEnumerator);
                        var iEnumerable = typeof(IEnumerable);

                        string additionalProperties = additionalPropertiesProperty.Declaration.Name;

                        writer
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iEnumeratorKeyValuePairType} GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"{iEnumerator} {iEnumerable}.GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public bool TryGetValue(string key, out {itemType} value) => {additionalProperties}.TryGetValue(key, out value);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public bool ContainsKey({keyType} key) => {additionalProperties}.ContainsKey(key);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iCollectionKeyType} Keys => {additionalProperties}.Keys;")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iCollectionItemType} Values => {additionalProperties}.Values;")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"int {iCollectionKeyValuePairType}.Count => {additionalProperties}.Count;");

                        if (!isReadonly)
                        {
                            writer
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"public void Add({keyType} key, {itemType} value) => {additionalProperties}.Add(key, value);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"public bool Remove({keyType} key) => {additionalProperties}.Remove(key);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"bool {iCollectionKeyValuePairType}.IsReadOnly => {additionalProperties}.IsReadOnly;")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"void {iCollectionKeyValuePairType}.Add({keyValuePairType} value) => {additionalProperties}.Add(value);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"bool {iCollectionKeyValuePairType}.Remove({keyValuePairType} value) => {additionalProperties}.Remove(value);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"bool {iCollectionKeyValuePairType}.Contains({keyValuePairType} value) => {additionalProperties}.Contains(value);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"void {iCollectionKeyValuePairType}.CopyTo({keyValuePairType}[] destination, int offset) => {additionalProperties}.CopyTo(destination, offset);")
                                .WriteXmlDocumentationInheritDoc()
                                .Line($"void {iCollectionKeyValuePairType}.Clear() => {additionalProperties}.Clear();");
                        }

                        using (writer
                            .WriteXmlDocumentationInheritDoc()
                            .Scope($"public {itemType} this[{keyType} key]"))
                        {
                            writer.Line($"get => {additionalProperties}[key];");
                            if (!isReadonly)
                            {
                                writer.Line($"set => {additionalProperties}[key] = value;");
                            }
                        }
                    }
                }
            }
        }

        private static void WriteConstructor(CodeWriter writer, ObjectType schema)
        {
            foreach (var constructor in schema.Constructors)
            {
                writer.WriteXmlDocumentationSummary($"Initializes a new instance of {schema.Declaration.Name}");
                foreach (var parameter in constructor.Parameters)
                {
                    writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
                }

                writer.Append($"{constructor.Declaration.Accessibility} {schema.Declaration.Name}(");
                foreach (var parameter in constructor.Parameters)
                {
                    writer.WriteParameter(parameter);
                }
                writer.RemoveTrailingComma();
                writer.Append($")");

                if (constructor.BaseConstructor?.Parameters.Length > 0)
                {
                    writer.Append($": base(");
                    foreach (var baseConstructorParameter in constructor.BaseConstructor.Parameters)
                    {
                        writer.Append($"{baseConstructorParameter.Name}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($")");
                }

                writer.Line();

                using (writer.Scope())
                {
                    writer.WriteParameterNullChecks(constructor.Parameters);

                    foreach (var initializer in constructor.Initializers)
                    {
                        writer.Append($"{initializer.Property.Declaration.Name} = ")
                            .WriteReferenceOrConstant(initializer.Value)
                            .WriteConversion(initializer.Value.Type, initializer.Property.Declaration.Type);

                        // Check if the parameter is for discriminator and apply a default
                        if (initializer.Property == schema.Discriminator?.Property &&
                            !initializer.Value.IsConstant)
                        {
                            writer.Append($"?? {schema.Discriminator.Value:L}");
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
                writer.WriteXmlDocumentationSummary(schema.Description);

                using (writer.Scope($"public enum {schema.Declaration.Name}"))
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary(value.Description);
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
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                writer.WriteXmlDocumentationSummary(schema.Description);

                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (writer.Scope($"{schema.Declaration.Accessibility} readonly partial struct {name}: {implementType}"))
                {
                    writer.Line($"private readonly {typeof(string)} _value;");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are the same.");
                    using (writer.Scope($"public {name}(string value)"))
                    {
                        writer.Line($"_value = value ?? throw new {typeof(ArgumentNullException)}(nameof(value));");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.Line($"private const string {choice.Declaration.Name}Value = {choice.Value.Value:L};");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary(choice.Description);
                        writer.Append($"public static {cs} {choice.Declaration.Name}").AppendRaw("{ get; }").Append($" = new {cs}({choice.Declaration.Name}Value);").Line();
                    }

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are the same.");
                    writer.Line($"public static bool operator ==({cs} left, {cs} right) => left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are not the same.");
                    writer.Line($"public static bool operator !=({cs} left, {cs} right) => !left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Converts a string to a <see cref=\"{name}\"/>.");
                    writer.Line($"public static implicit operator {cs}(string value) => new {cs}(value);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override bool Equals({typeof(object)} obj) => obj is {cs} other && Equals(other);");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public bool Equals({cs} other) => string.Equals(_value, other._value, {typeof(StringComparison)}.Ordinal);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override int GetHashCode() => _value?.GetHashCode() ?? 0;");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(string)} ToString() => _value;");
                }
            }
        }

        private void WriteEditorBrowsableFalse(CodeWriter writer)
        {
            writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
        }
    }
}
