// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Plugins;
using Azure.Core;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SerializationWriter
    {
        private readonly TypeFactory _typeFactory;

        public SerializationWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteSerialization(CodeWriter writer, ClientModel schema)
        {
            switch (schema)
            {
                case ClientObject objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case ClientEnum sealedChoiceSchema when !sealedChoiceSchema.IsStringBased:
                    WriteSealedChoiceSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }


        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private void WriteObjectSerialization(CodeWriter writer, ClientObject model)
        {
            var cs = _typeFactory.CreateType(model);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Class(null, "partial", model.Name, writer.Type(typeof(IUtf8JsonSerializable))))
                {
                    WriteSerialize(writer, model);

                    WriteDeserialize(writer, model, cs);
                }
            }
        }

        private void WriteDeserialize(CodeWriter writer, ClientObject model, CSharpType cs)
        {
            var typeText = writer.Type(cs);
            using (writer.Method("internal static", typeText, "Deserialize"+cs.Name, writer.Pair(typeof(JsonElement), "element")))
            {
                if (model.Discriminator?.HasDescendants == true)
                {
                    using (writer.If($"element.TryGetProperty(\"{model.Discriminator.SerializedName}\", out {writer.Type(typeof(JsonElement))} discriminator)"))
                    {
                        writer.Line($"switch (discriminator.GetString())");
                        using (writer.Scope())
                        {
                            foreach (var implementation in model.Discriminator.Implementations)
                            {
                                writer
                                    .Append($"case {implementation.Key:L}: return ")
                                    .ToDeserializeCall(implementation.Type, _typeFactory, w => w.Append($"element"));
                                writer.Line($";");
                            }
                        }
                    }
                }

                var resultVariable = "result";
                writer.ToDeserializeCall(model.Serialization, _typeFactory, w=>w.AppendRaw("element"), ref resultVariable);
                writer.Line($"return {resultVariable};");
            }
        }

        private void WriteSerialize(CodeWriter writer, ClientObject model)
        {
            writer.Append($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer)");
            using (writer.Scope())
            {
                writer.ToSerializeCall(model.Serialization, _typeFactory, w => w.AppendRaw("this"));
            }
        }

        private void WriteSealedChoiceSerialization(CodeWriter writer, ClientEnum schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Class("internal", "static", $"{schema.CSharpName()}Extensions"))
                {
                    var stringText = writer.Type(typeof(string));
                    var csTypeText = writer.Type(cs);
                    var nameMap = schema.Values.Select(c => (Choice: $"{csTypeText}.{c.Name}", Serial: $"\"{c.Value.Value}\"")).ToArray();
                    var exceptionEntry = $"_ => throw new {writer.Type(typeof(ArgumentOutOfRangeException))}(nameof(value), value, \"Unknown {cs.Name} value.\")";

                    var toSerialString = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Choice} => {nm.Serial},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    writer.MethodExpression("public static", stringText, "ToSerialString", new[] { writer.Pair($"this {csTypeText}", "value") }, toSerialString);
                    writer.Line();

                    var toChoiceType = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Serial} => {nm.Choice},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    writer.MethodExpression("public static", csTypeText, $"To{schema.CSharpName()}", new[] { writer.Pair($"this {stringText}", "value") }, toChoiceType);
                }
            }
        }
    }
}
