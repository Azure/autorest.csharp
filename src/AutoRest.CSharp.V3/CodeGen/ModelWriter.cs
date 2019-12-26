// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ModelWriter
    {
        private readonly TypeFactory _typeFactory;

        public ModelWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteModel(CodeWriter writer, ClientModel model)
        {
            switch (model)
            {
                case ClientObject objectSchema:
                    WriteObjectSchema(writer, objectSchema);
                    break;
                case ClientEnum e when e.IsStringBased:
                    WriteChoiceSchema(writer, e);
                    break;
                case ClientEnum e when !e.IsStringBased:
                    WriteSealedChoiceSchema(writer, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void WriteObjectSchema(CodeWriter writer, ClientObject schema)
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


                using (writer.Class(null, "partial", schema.CSharpName(), implements: string.Join(", ", implementsTypes)))
                {
                    if (schema.Discriminator != null)
                    {
                        using (writer.Method("public", null, cs.Name))
                        {
                            writer.Line($"{schema.Discriminator.Property} = {schema.Discriminator.Value:L};");
                        }
                    }

                    foreach (var property in schema.Properties)
                    {
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

                        writer.Line($"public {iEnumeratorKeyValuePairType} GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .Line($"{iEnumerator}  {iEnumerable}.GetEnumerator() => {additionalProperties}.GetEnumerator();")
                            .Line($"public {iCollectionKeyType} Keys => {additionalProperties}.Keys;")
                            .Line($"public {iCollectionItemType} Values => {additionalProperties}.Values;")
                            .Line($"public bool TryGetValue(string key, out {itemType} value) => {additionalProperties}.TryGetValue(key, out value);")
                            .Line($"public void Add({keyType} key, {itemType} value) => {additionalProperties}.Add(key, value);")
                            .Line($"public bool ContainsKey({keyType} key) => {additionalProperties}.ContainsKey(key);")
                            .Line($"public bool Remove({keyType} key) => {additionalProperties}.Remove(key);")
                            .Line($"public int Count => _additionalProperties.Count;")
                            .Line($"bool {iCollectionKeyValuePairType}.IsReadOnly => {additionalProperties}.IsReadOnly;")
                            .Line($"void {iCollectionKeyValuePairType}.Add({keyValuePairType} value) => {additionalProperties}.Add(value);")
                            .Line($"bool {iCollectionKeyValuePairType}.Remove({keyValuePairType} value) => {additionalProperties}.Remove(value);")
                            .Line($"bool {iCollectionKeyValuePairType}.Contains({keyValuePairType} value) => {additionalProperties}.Contains(value);")
                            .Line($"void {iCollectionKeyValuePairType}.CopyTo({keyValuePairType}[] destination, int offset) => {additionalProperties}.CopyTo(destination, offset);")
                            .Line($"void {iCollectionKeyValuePairType}.Clear() => {additionalProperties}.Clear();");

                        using (writer.Append($"public {itemType} this[{keyType} key]").Scope())
                        {
                            writer
                                .Line($"get => _additionalProperties[key];")
                                .Line($"set => _additionalProperties[key] = value;");
                        }
                    }
                }
            }
        }

        private bool NeedsInitialization(ClientObjectProperty property)
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
                return _typeFactory.ResolveReference(schemaType) is ClientObject;
            }

            return false;
        }

        private void WriteSealedChoiceSchema(CodeWriter writer, ClientEnum schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Enum(null, null, cs.Name))
                {
                    schema.Values.Select(c => c).ForEachLast(ccs => writer.EnumValue(ccs.Name), ccs => writer.EnumValue(ccs.Name, false));
                }
            }
        }

        private void WriteChoiceSchema(CodeWriter writer, ClientEnum schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (writer.Struct(null, "readonly partial", schema.CSharpName(), writer.Type(implementType)))
                {
                    var stringText = writer.Type(typeof(string));
                    var nullableStringText = writer.Type(typeof(string), true);
                    var csTypeText = writer.Type(cs);

                    writer.LineRaw($"private readonly {writer.Pair(nullableStringText, "_value")};");
                    writer.Line();

                    using (writer.Method("public", null, schema.CSharpName(), writer.Pair(stringText, "value")))
                    {
                        writer.LineRaw($"_value = value ?? throw new {writer.Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values.Select(c => c))
                    {
                        writer.LineRaw($"private const {writer.Pair(stringText, $"{choice.Name}Value")} = \"{choice.Value.Value}\";");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.LineRaw($"public static {writer.Pair(csTypeText, choice.Name)} {{ get; }} = new {csTypeText}({choice.Name}Value);");
                    }

                    var boolText = writer.Type(typeof(bool));
                    var leftRightParams = new[] { writer.Pair(csTypeText, "left"), writer.Pair(csTypeText, "right")};
                    writer.MethodExpression("public static", boolText, "operator ==", leftRightParams, "left.Equals(right)");
                    writer.MethodExpression("public static", boolText, "operator !=", leftRightParams, "!left.Equals(right)");
                    writer.MethodExpression("public static implicit", null, $"operator {csTypeText}", new[]{ writer.Pair(stringText, "value")}, $"new {csTypeText}(value)");
                    writer.Line();

                    var editorBrowsableNever = $"[{writer.AttributeType(typeof(EditorBrowsableAttribute))}({writer.Type(typeof(EditorBrowsableState))}.Never)]";
                    writer.LineRaw(editorBrowsableNever);
                    writer.MethodExpression("public override", boolText, "Equals", new[]{ writer.Pair(typeof(object), "obj", true)}, $"obj is {csTypeText} other && Equals(other)");
                    writer.MethodExpression("public", boolText, "Equals", new[] { writer.Pair(csTypeText, "other") }, $"{stringText}.Equals(_value, other._value, {writer.Type(typeof(StringComparison))}.Ordinal)");
                    writer.Line();

                    writer.LineRaw(editorBrowsableNever);
                    writer.MethodExpression("public override", writer.Type(typeof(int)), "GetHashCode", null, "_value?.GetHashCode() ?? 0");
                    writer.MethodExpression("public override", nullableStringText, "ToString", null, "_value");
                }
            }
        }
    }
}
