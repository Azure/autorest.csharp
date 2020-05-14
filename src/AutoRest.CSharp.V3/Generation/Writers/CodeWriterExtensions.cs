// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Requests;
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

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter, bool includeDefaultValue = true)
        {
            writer.Append($"{clientParameter.Type} {clientParameter.Name:D}");
            if (includeDefaultValue &&
                clientParameter.DefaultValue != null)
            {
                if (CanBeInitializedInline(clientParameter))
                {
                    writer.Append($" = {clientParameter.DefaultValue.Value.Value:L}");
                }
                else
                {
                    // initialize with null and set the default later
                    writer.Append($" = null");
                }
            }

            writer.AppendRaw(",");
        }

        public static void WriteParameterNullChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                CSharpType cs = parameter.Type;
                if (parameter.DefaultValue != null &&
                    !CanBeInitializedInline(parameter))
                {
                    writer.Line($"{parameter.Name} ??= new {parameter.Type}({parameter.DefaultValue.Value.Value:L});");
                }
                else if (parameter.IsRequired && (cs.IsNullable || !cs.IsValueType))
                {
                    using (writer.Scope($"if ({parameter.Name:I} == null)"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name:I}));");
                    }
                }
            }

            writer.Line();
        }

        private static bool CanBeInitializedInline(Parameter parameter)
        {
            Debug.Assert(parameter.DefaultValue.HasValue);

            if (parameter.Type.IsFrameworkType && parameter.Type.FrameworkType == typeof(string))
            {
                return true;
            }

            if (!parameter.Type.IsValueType &&
                parameter.DefaultValue.Value.Value != null)
            {
                return false;
            }

            return true;
        }

        public static void WriteConstant(this CodeWriter writer, Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({constant.Type}){null:L}");
                return;
            }

            if (constant.Value == Constant.NewInstanceSentinel)
            {
                writer.Append($"new {constant.Type}()");
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
            Action<CodeWriter, CodeWriterDelegate> valueCallback, string responseVariable)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    writer.WriteDeserializationForMethods(jsonSerialization, async, valueCallback, responseVariable);
                    break;
                case XmlElementSerialization xmlSerialization:
                    writer.WriteDeserializationForMethods(xmlSerialization, valueCallback, responseVariable);
                    break;
                default:
                    throw new NotImplementedException(serialization.ToString());
            }
        }

        public static CodeWriter AppendEnumToString(this CodeWriter writer, EnumType enumType)
        {
            if (!enumType.IsExtendable)
            {
                writer.UseNamespace(enumType.Type.Namespace);
            }
            return writer.AppendRaw(enumType.IsExtendable ? ".ToString()" : ".ToSerialString()");
        }

        public static CodeWriter WriteReferenceOrConstant(this CodeWriter writer, ReferenceOrConstant value)
        {
            if (value.IsConstant)
            {
                writer.WriteConstant(value.Constant);
            }
            else
            {
                var parts = value.Reference.Name.Split(".");

                bool first = true;
                foreach (var part in parts)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        writer.AppendRaw(".");
                    }
                    writer.Identifier(part);
                }
            }

            return writer;
        }

        public static CodeWriter WriteInitialization(this CodeWriter writer, ObjectType objectType, IEnumerable<ObjectPropertyInitializer> initializers)
        {
            ObjectPropertyInitializer? FindInitializerForParameter(ObjectTypeConstructor constructor, Parameter constructorParameter)
            {
                var property = constructor.FindPropertyInitializedByParameter(constructorParameter);
                return initializers.SingleOrDefault(i => i.Property == property);
            }

            // Checks if constructor parameters can be satisfied by the provided initializer list
            List<ObjectPropertyInitializer>? TryGetParameters(ObjectTypeConstructor constructor)
            {
                List<ObjectPropertyInitializer> constructorInitializers = new List<ObjectPropertyInitializer>();
                foreach (var constructorParameter in constructor.Parameters)
                {
                    var objectPropertyInitializer = FindInitializerForParameter(constructor, constructorParameter);
                    if (objectPropertyInitializer == null) return null;

                    constructorInitializers.Add(objectPropertyInitializer);
                }

                return constructorInitializers;
            }

            // Find longest satisfiable ctor
            List<ObjectPropertyInitializer>? selectedCtorInitializers = null;
            foreach (var constructor in objectType.Constructors)
            {
                var newInitializers = TryGetParameters(constructor);
                if (newInitializers != null &&
                    newInitializers.Count > (selectedCtorInitializers?.Count ?? -1))
                {
                    selectedCtorInitializers = newInitializers;
                }
            }

            Debug.Assert(selectedCtorInitializers != null);

            writer.Append($"new {objectType.Type}(");
            foreach (var initializer in selectedCtorInitializers)
            {
                writer.WriteReferenceOrConstant(initializer.Value);
                writer.WriteConversion(initializer.Value.Type, initializer.Property.Declaration.Type);
                writer.Append($", ");
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            // Find properties that would have to be initialized via property initializers
            var restOfInitializers = initializers.Except(selectedCtorInitializers).ToArray();
            if (restOfInitializers.Any())
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach (var propertyInitializer in restOfInitializers)
                    {
                        writer.Append($"{propertyInitializer.Property.Declaration.Name} = ")
                            .WriteReferenceOrConstant(propertyInitializer.Value);

                        writer.WriteConversion(propertyInitializer.Value.Type, propertyInitializer.Property.Declaration.Type);

                        writer.Line($",");
                    }

                    writer.RemoveTrailingComma();
                }
            }

            return writer;
        }

        public static void WriteConversion(this CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (to.IsFrameworkType && from.IsFrameworkType)
            {
                if ((to.FrameworkType == typeof(IList<>) ||
                     to.FrameworkType == typeof(IReadOnlyList<>)) &&
                    from.FrameworkType == typeof(IEnumerable<>))
                {
                    writer.UseNamespace(typeof(Enumerable).Namespace!);
                    writer.Append($".ToArray()");
                }
            }
        }
    }
}
