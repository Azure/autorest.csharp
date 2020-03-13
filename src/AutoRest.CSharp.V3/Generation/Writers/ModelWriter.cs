// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Types;

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

                if (schema.ImplementsDictionaryElementType != null)
                {
                    var elementType = schema.ImplementsDictionaryElementType;
                    implementsTypes.Add(new CSharpType(typeof(IDictionary<,>), new CSharpType(typeof(string)), elementType));
                }

                writer.WriteXmlDocumentationSummary(schema.Description);

                writer.Append($"{schema.Declaration.Accessibility} partial class {schema.Declaration.Name}");
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
                    if (schema.Discriminator != null)
                    {
                        writer.WriteXmlDocumentationSummary($"Initializes a new instance of {schema.Declaration.Name}");
                        using (writer.Scope($"public {schema.Declaration.Name}()"))
                        {
                            writer.Line($"{schema.Discriminator.Property} = {schema.Discriminator.Value:L};");
                        }
                    }

                    foreach (var property in schema.Properties)
                    {
                        if (property.DeclarationOptions.IsUserDefined)
                        {
                            continue;
                        }

                        writer.WriteXmlDocumentationSummary(property.Description);

                        CSharpType propertyType = property.DeclarationOptions.Type;
                        writer.Append($"{property.DeclarationOptions.Accessibility} {propertyType} {property.DeclarationOptions.Name:D}");
                        writer.AppendRaw(property.IsReadOnly ? "{ get; internal set; }" : "{ get; set; }");

                        if (property.DefaultValue != null)
                        {
                            writer.Append($" = {property.DefaultValue.Value.Value:L};");
                        }
                        else if (property.ImplementationType != null)
                        {
                            writer.Append($" = new {property.ImplementationType}();");
                        }

                        writer.Line();
                    }

                    if (schema.ImplementsDictionaryElementType is CSharpType itemType)
                    {
                        var dictionaryType = new CSharpType(typeof(IDictionary<,>), new CSharpType(typeof(string)), itemType);
                        var implementation = new CSharpType(typeof(Dictionary<,>), new CSharpType(typeof(string)), itemType);

                        Debug.Assert(dictionaryType.Arguments.Length == 2);
                        var keyType = typeof(string);

                        var keyValuePairType = new CSharpType(typeof(KeyValuePair<,>), keyType, itemType);
                        var iEnumeratorKeyValuePairType = new CSharpType(typeof(IEnumerator<>), keyValuePairType);
                        var iCollectionKeyValuePairType = new CSharpType(typeof(ICollection<>), keyValuePairType);
                        var iCollectionKeyType = new CSharpType(typeof(ICollection<>), keyType);
                        var iCollectionItemType = new CSharpType(typeof(ICollection<>), itemType);
                        var iEnumerator = typeof(IEnumerator);
                        var iEnumerable = typeof(IEnumerable);

                        string additionalProperties = "_additionalProperties";
                        writer.Line($"private readonly {dictionaryType} {additionalProperties} = new {implementation}();");

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
                            .Line($"int {iCollectionKeyValuePairType}.Count => _additionalProperties.Count;")
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
                        if (value.Declaration.IsUserDefined)
                        {
                            continue;
                        }
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
                    writer.Line($"private readonly string? _value;");
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
                        if (choice.Declaration.IsUserDefined)
                        {
                            continue;
                        }
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
