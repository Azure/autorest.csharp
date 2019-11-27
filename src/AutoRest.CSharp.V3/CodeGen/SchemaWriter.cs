// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SchemaWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public SchemaWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteSchema(ClientEntity entity)
        {
            switch (entity)
            {
                case ClientModel.ClientModel objectSchema:
                    WriteObjectSchema(objectSchema);
                    break;
                case ClientEnum e when e.GenerationOptions.IsStringBased:
                    WriteSealedChoiceSchema(e);
                    break;
                case ClientEnum e when !e.GenerationOptions.IsStringBased:
                    WriteChoiceSchema(e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void WriteObjectSchema(ClientModel.ClientModel schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs?.Namespace))
            {
                using (Class(null, "partial", schema.CSharpName()))
                {
                    var propertyInfos = schema.Properties;
                    foreach (var property in propertyInfos)
                    {
                        if (property is ClientModelConstant constant)
                        {
                            //TODO: Determine if type can use 'const' field instead of 'static' property
                            Line($"public static {Pair(_typeFactory.CreateType(constant.Type), property.CSharpName())} {{ get; }} = {constant.Value.ToValueString()};");
                            continue;
                        }
                        AutoProperty("public", _typeFactory.CreateType(property.Type), property.CSharpName(), property.IsMutable);
                    }

                    var requiredProperties = propertyInfos.Where(pi => !pi.IsMutable);
                    var parameters = requiredProperties.Select(rp => Pair(_typeFactory.CreateInputType(rp.Type), rp.CSharpVariableName())).ToArray();
                    using (Method("public", null, schema.CSharpName(), parameters))
                    {
                        foreach (var property in requiredProperties)
                        {
                            var variableName = property.CSharpVariableName();
                            if (NeedsInitialization(property.Type))
                            {
                                Line($"{property.CSharpName()} = new {Type(_typeFactory.CreateConcreteType(property.Type))}({variableName});");
                                continue;
                            }
                            Line($"{property.CSharpName()} = {variableName};");
                        }
                    }
                }
            }
        }

        private bool NeedsInitialization(ClientTypeReference reference)
        {
            if (reference is CollectionTypeReference || reference is DictionaryTypeReference)
            {
                return true;
            }

            return false;
        }

        private void WriteSealedChoiceSchema(ClientEnum schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Enum(null, null, cs.Name))
                {
                    schema.Values.Select(c => c).ForEachLast(ccs => EnumValue(ccs.Value.Value.ToString()), ccs => EnumValue(ccs.Value.Value.ToString(), false));
                }
            }
        }

        private void WriteChoiceSchema(ClientEnum schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (Struct(null, "readonly partial", schema.CSharpName(), Type(implementType)))
                {
                    var stringText = Type(typeof(string));
                    var nullableStringText = Type(typeof(string), true);
                    var csTypeText = Type(cs);

                    Line($"private readonly {Pair(nullableStringText, "_value")};");
                    Line();

                    using (Method("public", null, schema.CSharpName(), Pair(stringText, "value")))
                    {
                        Line($"_value = value ?? throw new {Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    Line();

                    foreach (var choice in schema.Values.Select(c => c))
                    {
                        Line($"private const {Pair(stringText, $"{choice.CSharpName()}Value")} = \"{choice.Value}\";");
                    }
                    Line();

                    foreach (var choice in schema.Values)
                    {
                        Line($"public static {Pair(csTypeText, choice?.CSharpName())} {{ get; }} = new {csTypeText}({choice?.CSharpName()}Value);");
                    }

                    var boolText = Type(typeof(bool));
                    var leftRightParams = new[] {Pair(csTypeText, "left"), Pair(csTypeText, "right")};
                    MethodExpression("public static", boolText, "operator ==", leftRightParams, "left.Equals(right)");
                    MethodExpression("public static", boolText, "operator !=", leftRightParams, "!left.Equals(right)");
                    MethodExpression("public static implicit", null, $"operator {csTypeText}", new[]{Pair(stringText, "value")}, $"new {csTypeText}(value)");
                    Line();

                    var editorBrowsableNever = $"[{AttributeType(typeof(EditorBrowsableAttribute))}({Type(typeof(EditorBrowsableState))}.Never)]";
                    Line(editorBrowsableNever);
                    MethodExpression("public override", boolText, "Equals", new[]{Pair(typeof(object), "obj", true)}, $"obj is {csTypeText} other && Equals(other)");
                    MethodExpression("public", boolText, "Equals", new[] { Pair(csTypeText, "other") }, $"{stringText}.Equals(_value, other._value, {Type(typeof(StringComparison))}.Ordinal)");
                    Line();

                    Line(editorBrowsableNever);
                    MethodExpression("public override", Type(typeof(int)), "GetHashCode", null, "_value?.GetHashCode() ?? 0");
                    MethodExpression("public override", nullableStringText, "ToString", null, "_value");
                }
            }
        }
    }
}
