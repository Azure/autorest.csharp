// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputParameterConverter : JsonConverter<InputParameter>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputParameterConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputParameter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => ReadInputParameter(ref reader, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputParameter value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputParameter? ReadInputParameter(ref Utf8JsonReader reader, JsonSerializerOptions options, ReferenceResolver resolver)
            => reader.ReadReferenceAndResolve<InputParameter>(resolver) ?? CreateInputParameter(ref reader, null, null, options, resolver);

        public static InputParameter CreateInputParameter(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            string? nameInRequest = null;
            string? summary = null;
            string? doc = null;
            InputType? parameterType = null;
            string? location = null;
            InputConstant? defaultValue = null;
            InputParameter? groupBy = null;
            string? kind = null;
            bool isRequired = false;
            bool isApiVersion = false;
            bool isResourceParameter = false;
            bool isContentType = false;
            bool isEndpoint = false;
            bool skipUrlEncoding = false;
            bool explode = false;
            string? arraySerializationDelimiter = null;
            string? headerCollectionPrefix = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("nameInRequest", ref nameInRequest)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("type", options, ref parameterType)
                    || reader.TryReadString("location", ref location)
                    || reader.TryReadComplexType("defaultValue", options, ref defaultValue)
                    || reader.TryReadComplexType("groupedBy", options, ref groupBy)
                    || reader.TryReadString("kind", ref kind)
                    || reader.TryReadBoolean("isRequired", ref isRequired)
                    || reader.TryReadBoolean("isApiVersion", ref isApiVersion)
                    || reader.TryReadBoolean("isResourceParameter", ref isResourceParameter) // TODO - this should be removed
                    || reader.TryReadBoolean("isContentType", ref isContentType)
                    || reader.TryReadBoolean("isEndpoint", ref isEndpoint)
                    || reader.TryReadBoolean("skipUrlEncoding", ref skipUrlEncoding)
                    || reader.TryReadBoolean("explode", ref explode)
                    || reader.TryReadString("arraySerializationDelimiter", ref arraySerializationDelimiter)
                    || reader.TryReadString("headerCollectionPrefix", ref headerCollectionPrefix);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Parameter must have name");
            nameInRequest = nameInRequest ?? throw new JsonException("Parameter must have nameInRequest");
            parameterType = parameterType ?? throw new JsonException("Parameter must have type");

            if (location == null)
            {
                throw new JsonException("Parameter must have location");
            }
            Enum.TryParse<RequestLocation>(location, ignoreCase: true, out var requestLocation);

            if (kind == null)
            {
                throw new JsonException("Parameter must have kind");
            }
            Enum.TryParse<InputOperationParameterKind>(kind, ignoreCase: true, out var parameterKind);

            var parameter = new InputParameter(
                Name: name,
                NameInRequest: nameInRequest,
                Summary: summary,
                Doc: doc,
                Type: parameterType,
                Location: requestLocation,
                DefaultValue: defaultValue,
                GroupedBy: groupBy,
                FlattenedBodyProperty: null,
                Kind: parameterKind,
                IsRequired: isRequired,
                IsApiVersion: isApiVersion,
                IsResourceParameter: isResourceParameter,
                IsContentType: isContentType,
                IsEndpoint: isEndpoint,
                SkipUrlEncoding: skipUrlEncoding,
                Explode: explode,
                ArraySerializationDelimiter: arraySerializationDelimiter,
                HeaderCollectionPrefix: headerCollectionPrefix);

            if (id != null)
            {
                resolver.AddReference(id, parameter);
            }

            return parameter;
        }
    }
}
