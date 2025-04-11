// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputEnumTypeConverter : JsonConverter<InputEnumType>
    {
        internal const string EnumKind = "enum";

        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputEnumTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputEnumType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputEnumType>(_referenceHandler.CurrentResolver) ?? CreateEnumType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public static InputEnumType CreateEnumType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            string? crossLanguageDefinitionId = null;
            string? access = null;
            string? deprecation = null;
            string? summary = null;
            string? doc = null;
            string? usageString = null;
            bool isFixed = false;
            InputType? valueType = null;
            IReadOnlyList<InputEnumTypeValue>? values = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadString("access", ref access)
                    || reader.TryReadString("deprecation", ref deprecation)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadString("usage", ref usageString)
                    || reader.TryReadBoolean("isFixed", ref isFixed)
                    || reader.TryReadComplexType("valueType", options, ref valueType)
                    || reader.TryReadComplexType("values", options, ref values)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Enum must have name");
            // TODO: roll back to throw JSON error when there is linter on the upstream to check enum without @doc
            //description = description ?? throw new JsonException("Enum must have a description");
            if (doc.IsNullOrEmpty() && summary.IsNullOrEmpty())
            {
                Console.Error.WriteLine($"[Warn]: Enum '{name}' must have either a summary or description");
                summary = string.Empty;
                doc = $"The {name}.";
            }

            if (!Enum.TryParse<InputModelTypeUsage>(usageString, out var usage))
            {
                throw new JsonException($"Cannot parse usage {usageString}");
            }

            if (values == null || values.Count == 0)
            {
                throw new JsonException("Enum must have at least one value");
            }

            if (valueType is not InputPrimitiveType inputValueType)
            {
                throw new JsonException("The ValueType of an EnumType must be a primitive type.");
            }

            var enumType = new InputEnumType(name, crossLanguageDefinitionId ?? string.Empty, access, deprecation, summary!, doc!, usage, inputValueType, values, !isFixed)
            {
                Decorators = decorators ?? []
            };
            if (id != null)
            {
                resolver.AddReference(id, enumType);
            }
            return enumType;
        }

        public override void Write(Utf8JsonWriter writer, InputEnumType value, JsonSerializerOptions options)
        {
            var id = _referenceHandler.CurrentResolver.GetReference(value, out var alreadyExists);
            if (alreadyExists)
            {
                writer.WriteObjectReference(id);
                return;
            }

            // if not exist
            writer.WriteStartObject();

            // the first property should always be the id
            writer.WriteReferenceId(id);
            // then we write the kind
            writer.WriteString("kind", EnumKind);
            // name
            writer.WriteString("name", value.Name);
            // crossLanguageDefinitionId
            writer.WriteString("crossLanguageDefinitionId", value.CrossLanguageDefinitionId);
            // valueType
            writer.WriteObject("valueType", value.ValueType, options);
            // values
            writer.WriteArray("values", value.Values, options);
            // access
            writer.WriteStringIfPresent("access", value.Accessibility);
            // namespace
            writer.WriteString("namespace", string.Empty); // here the writing is a shimming layer from swagger to typespec. Swagger does not have the concept of namespace
            // deprecation
            writer.WriteStringIfPresent("deprecation", value.Deprecated);
            // summary
            writer.WriteStringIfPresent("summary", value.Summary);
            // doc
            writer.WriteStringIfPresent("doc", value.Doc);
            // isFixed
            writer.WriteBoolean("isFixed", !value.IsExtensible);
            // usage
            writer.WriteString("usage", value.Usage.ToString());
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);

            writer.WriteEndObject();
        }
    }
}
