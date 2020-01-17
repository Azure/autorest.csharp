﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class ModelWriter
    {
        private readonly TypeFactory _typeFactory;

        public ModelWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

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
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                List<string> implementsTypes = new List<string>();
                if (schema.Inherits != null)
                {
                    implementsTypes.Add(writer.Type(_typeFactory.CreateType(schema.Inherits)));
                }

                if (schema.ImplementsDictionary != null)
                {
                    var dictionaryType = _typeFactory.CreateInputType(schema.ImplementsDictionary);
                    implementsTypes.Add(writer.Type(dictionaryType));
                }

                writer.WriteXmlDocumentationSummary(schema.Description);
                using (writer.Class(null, "partial", schema.Name, implements: string.Join(", ", implementsTypes)))
                {
                    if (schema.Discriminator != null)
                    {
                        writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
                        using (writer.Method("public", null, cs.Name))
                        {
                            writer.Line($"{schema.Discriminator.Property} = {schema.Discriminator.Value:L};");
                        }
                    }

                    foreach (var property in schema.Properties)
                    {
                        writer.WriteXmlDocumentationSummary(property.Description);

                        CSharpType propertyType = _typeFactory.CreateType(property.Type);
                        writer.Append($"public {propertyType} {property.Name:D}");
                        writer.AppendRaw(property.IsReadOnly ? "{ get; internal set; }" : "{ get; set; }");

                        if (property.DefaultValue != null)
                        {
                            writer.Append($" = {property.DefaultValue.Value.Value:L};");
                        }
                        else if (NeedsInitialization(property))
                        {
                            writer.Append($" = new {_typeFactory.CreateConcreteType(property.Type)}();");
                        }

                        writer.Line();
                    }

                    if (schema.ImplementsDictionary != null)
                    {
                        var implementationType = _typeFactory.CreateType(schema.ImplementsDictionary);
                        var fieldType = _typeFactory.CreateConcreteType(schema.ImplementsDictionary);
                        var keyType = _typeFactory.CreateType(schema.ImplementsDictionary.KeyType);
                        var itemType = _typeFactory.CreateType(schema.ImplementsDictionary.ValueType);

                        var keyValuePairType = new CSharpType(typeof(KeyValuePair<,>), keyType, itemType);
                        var iEnumeratorKeyValuePairType = new CSharpType(typeof(IEnumerator<>), keyValuePairType);
                        var iCollectionKeyValuePairType = new CSharpType(typeof(ICollection<>), keyValuePairType);
                        var iCollectionKeyType = new CSharpType(typeof(ICollection<>), keyType);
                        var iCollectionItemType = new CSharpType(typeof(ICollection<>), itemType);
                        var iEnumerator = new CSharpType(typeof(IEnumerator));
                        var iEnumerable = new CSharpType(typeof(IEnumerable));

                        string additionalProperties = "_additionalProperties";
                        writer.Line($"private readonly {implementationType} {additionalProperties} = new {fieldType}();");

                        writer
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iEnumeratorKeyValuePairType} GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"{iEnumerator}  {iEnumerable}.GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iCollectionKeyType} Keys => {additionalProperties}.Keys;")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public {iCollectionItemType} Values => {additionalProperties}.Values;")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public bool TryGetValue(string key, out {itemType} value) => {additionalProperties}.TryGetValue(key, out value);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public void Add({keyType} key, {itemType} value) => {additionalProperties}.Add(key, value);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public bool ContainsKey({keyType} key) => {additionalProperties}.ContainsKey(key);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public bool Remove({keyType} key) => {additionalProperties}.Remove(key);")
                            .WriteXmlDocumentationInheritDoc()
                            .Line($"public int Count => _additionalProperties.Count;")
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

                        using (writer
                            .WriteXmlDocumentationInheritDoc()
                            .Scope($"public {itemType} this[{keyType} key]"))
                        {
                            writer
                                .Line($"get => _additionalProperties[key];")
                                .Line($"set => _additionalProperties[key] = value;");
                        }
                    }
                }
            }
        }

        private bool NeedsInitialization(ObjectTypeProperty property)
        {
            // TODO: This logic shouldn't be base only on type nullability
            if (property.Type.IsNullable)
            {
                return false;
            }

            if (property.Type is CollectionTypeReference || property.Type is DictionaryTypeReference)
            {
                return true;
            }

            if (property.Type is SchemaTypeReference schemaType)
            {
                return _typeFactory.ResolveReference(schemaType) is ObjectType;
            }

            return false;
        }

        private void WriteSealedChoiceSchema(CodeWriter writer, EnumType schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(schema.Description);

                using (writer.Scope($"public enum {cs.Name}"))
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary(value.Description);
                        writer.Line($"{value.Name},");
                    }
                    writer.RemoveTrailingComma();
                }
            }
        }

        private void WriteChoiceSchema(CodeWriter writer, EnumType schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(schema.Description);

                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (writer.Scope($"public readonly partial struct {schema.Name}: {implementType}"))
                {
                    writer.Line($"private readonly string? _value;");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{cs.Name}\"/> values are the same.");
                    using (writer.Scope($"public {schema.Name}(string value)"))
                    {
                        writer.Line($"_value = value ?? throw new {typeof(ArgumentNullException)}(nameof(value));");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.Line($"private const string {choice.Name}Value = {choice.Value.Value:L};");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary(choice.Description);
                        writer.Append($"public static {cs} {choice.Name}").AppendRaw("{ get; }").Append($" = new {cs}({choice.Name}Value);").Line();
                    }

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{cs.Name}\"/> values are the same.");
                    writer.Line($"public static bool operator ==({cs} left, {cs} right) => left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{cs.Name}\"/> values are not the same.");
                    writer.Line($"public static bool operator !=({cs} left, {cs} right) => !left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Converts a string to a <see cref=\"{cs.Name}\"/>.");
                    writer.Line($"public static implicit operator {cs}(string value) => new {cs}(value);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override bool Equals(object? obj) => obj is {cs} other && Equals(other);");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public bool Equals({cs} other) => string.Equals(_value, other._value, {typeof(StringComparison)}.Ordinal);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override int GetHashCode() => _value?.GetHashCode() ?? 0;");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override string? ToString() => _value;");
                }
            }
        }

        private void WriteEditorBrowsableFalse(CodeWriter writer)
        {
            writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
        }
    }
}
