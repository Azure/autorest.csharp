// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendNullableValue(this CodeWriter writer, CSharpType type)
        {
            if (type.IsNullable && type.IsValueType)
            {
                writer.Append($".Value");
            }

            return writer;
        }

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter)
        {
            writer.Append($"{clientParameter.Type} {clientParameter.Name:D}");
            if (clientParameter.DefaultValue != null)
            {
                writer.Append($" = {clientParameter.DefaultValue.Value.Value:L}");
            }

            writer.AppendRaw(",");
        }

        public static void WriteParameterNullChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                CSharpType cs = parameter.Type;
                if (parameter.IsRequired && (cs.IsNullable || !cs.IsValueType))
                {
                    using (writer.Scope($"if ({parameter.Name} == null)"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name}));");
                    }
                }
            }

            if (parameters.Any())
            {
                writer.Line();
            }
        }

        public static void WriteConstant(this CodeWriter writer, Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({constant.Type}){null:L}");
                return;
            }

            Type frameworkType = constant.Type.FrameworkType;
            if (frameworkType == typeof(DateTimeOffset))
            {
                var d = (DateTimeOffset) constant.Value;
                d = d.ToUniversalTime();
                writer.Append($"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})");
            }
            else if (frameworkType == typeof(byte[]))
            {
                var value = (byte[]) constant.Value;
                writer.Append($"new byte[] {{");
                foreach (byte b in value)
                {
                    writer.Append($"{b}, ");
                }

                writer.Append($"}}");
            }
            else
            {
                writer.Literal(constant.Value);
            }
        }

        public static void WriteDeserializationForMethods(this CodeWriter writer, ObjectSerialization serialization, bool async,
            ref string valueVariable, string responseVariable)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    writer.WriteDeserializationForMethods(jsonSerialization, async, ref valueVariable, responseVariable);
                    break;
                case XmlElementSerialization xmlSerialization:
                    writer.WriteDeserializationForMethods(xmlSerialization, ref valueVariable, responseVariable);
                    break;
                default:
                    throw new NotImplementedException(serialization.ToString());
            }
        }

        public static CodeWriter AppendEnumToString(this CodeWriter writer, EnumType enumType)
        {
            if (!enumType.IsStringBased)
            {
                writer.UseNamespace(enumType.Type.Namespace);
            }
            return writer.AppendRaw(enumType.IsStringBased ? ".ToString()" : ".ToSerialString()");
        }
    }
}
