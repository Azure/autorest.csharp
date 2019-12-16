// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Pipeline;
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
                string? implementsType = null;
                if (schema.Inherits != null)
                {
                    implementsType = writer.Type(_typeFactory.CreateType(schema.Inherits));
                }

                using (writer.Class(null, "partial", schema.CSharpName(), implements: implementsType))
                {
                    if (schema.Discriminator != null)
                    {
                        using (writer.Method("public", null, cs.Name))
                        {
                            writer
                                .Append(schema.Discriminator.Property)
                                .Append("=")
                                .Literal(schema.Discriminator.Value)
                                .SemicolonLine();
                        }
                    }

                    foreach (var property in schema.Properties)
                    {
                        var initializer = property.IsRequired && NeedsInitialization(property.Type) ? $" = new {writer.Type(_typeFactory.CreateConcreteType(property.Type))}();" : null;
                        writer.AutoProperty("public", _typeFactory.CreateType(property.Type), property.Name, property.IsReadOnly, initializer);
                    }
                }
            }
        }

        private static bool NeedsInitialization(ClientTypeReference reference) => reference is CollectionTypeReference || reference is DictionaryTypeReference;

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

                    writer.Line($"private readonly {writer.Pair(nullableStringText, "_value")};");
                    writer.Line();

                    using (writer.Method("public", null, schema.CSharpName(), writer.Pair(stringText, "value")))
                    {
                        writer.Line($"_value = value ?? throw new {writer.Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values.Select(c => c))
                    {
                        writer.Line($"private const {writer.Pair(stringText, $"{choice.Name}Value")} = \"{choice.Value.Value}\";");
                    }
                    writer.Line();

                    foreach (var choice in schema.Values)
                    {
                        writer.Line($"public static {writer.Pair(csTypeText, choice.Name)} {{ get; }} = new {csTypeText}({choice.Name}Value);");
                    }

                    var boolText = writer.Type(typeof(bool));
                    var leftRightParams = new[] { writer.Pair(csTypeText, "left"), writer.Pair(csTypeText, "right")};
                    writer.MethodExpression("public static", boolText, "operator ==", leftRightParams, "left.Equals(right)");
                    writer.MethodExpression("public static", boolText, "operator !=", leftRightParams, "!left.Equals(right)");
                    writer.MethodExpression("public static implicit", null, $"operator {csTypeText}", new[]{ writer.Pair(stringText, "value")}, $"new {csTypeText}(value)");
                    writer.Line();

                    var editorBrowsableNever = $"[{writer.AttributeType(typeof(EditorBrowsableAttribute))}({writer.Type(typeof(EditorBrowsableState))}.Never)]";
                    writer.Line(editorBrowsableNever);
                    writer.MethodExpression("public override", boolText, "Equals", new[]{ writer.Pair(typeof(object), "obj", true)}, $"obj is {csTypeText} other && Equals(other)");
                    writer.MethodExpression("public", boolText, "Equals", new[] { writer.Pair(csTypeText, "other") }, $"{stringText}.Equals(_value, other._value, {writer.Type(typeof(StringComparison))}.Ordinal)");
                    writer.Line();

                    writer.Line(editorBrowsableNever);
                    writer.MethodExpression("public override", writer.Type(typeof(int)), "GetHashCode", null, "_value?.GetHashCode() ?? 0");
                    writer.MethodExpression("public override", nullableStringText, "ToString", null, "_value");
                }
            }
        }
    }
}
