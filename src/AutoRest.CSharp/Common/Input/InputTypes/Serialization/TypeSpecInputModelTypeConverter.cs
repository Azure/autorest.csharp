// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputModelTypeConverter : JsonConverter<IModelType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputModelTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override IModelType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ReadModelType(ref reader, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, IModelType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static IModelType? ReadModelType(ref Utf8JsonReader reader, JsonSerializerOptions options, ReferenceResolver resolver)
            => reader.ReadReferenceAndResolve<IModelType>(resolver) ?? CreateModelType(ref reader, null, null, options, resolver);

        public static IModelType CreateModelType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            var properties = new List<IModelProperty>();
            bool isNullable = false;
            string? ns = null;
            string? accessibility = null;
            string? deprecated = null;
            string? description = null;
            string? usageString = null;
            string? discriminatorPropertyName = null;
            string? discriminatorValue = null;
            IDictionaryType? inheritedDictionaryType = null;
            IModelType? baseModel = null;
            IModelType? model = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(IModelType.Name), ref name)
                    || reader.TryReadBoolean(nameof(IModelType.IsNullable), ref isNullable)
                    || reader.TryReadString(nameof(IModelType.Namespace), ref ns)
                    || reader.TryReadString(nameof(IModelType.Accessibility), ref accessibility)
                    || reader.TryReadString(nameof(IModelType.Deprecated), ref deprecated)
                    || reader.TryReadString(nameof(IModelType.Description), ref description)
                    || reader.TryReadString(nameof(IModelType.Usage), ref usageString)
                    || reader.TryReadString(nameof(IModelType.DiscriminatorPropertyName), ref discriminatorPropertyName)
                    || reader.TryReadString(nameof(IModelType.DiscriminatorValue), ref discriminatorValue)
                    || reader.TryReadWithConverter(nameof(IModelType.InheritedDictionaryType), options, ref inheritedDictionaryType);

                if (isKnownProperty)
                {
                    continue;
                }
                /**
                 * If the model has base model, `BaseModel` and `Properties` should be the last two items in tspCodeModel.
                 * and `BaseModel` should be last but one, and `Properties` should be the last one.
                 */
                if (reader.GetString() == nameof(IModelType.BaseModel))
                {
                    model = CreateInputModelTypeInstance(id, name, ns, accessibility, deprecated, description, usageString, discriminatorValue, discriminatorPropertyName, baseModel, properties, inheritedDictionaryType, isNullable, resolver);
                    reader.TryReadWithConverter(nameof(IModelType.BaseModel), options, ref baseModel);
                    if (baseModel != null)
                    {
                        ((InputModelType)model).BaseModel = baseModel;
                        var baseModelDerived = (List<IModelType>)resolver.ResolveReference($"{baseModel.Name}.{nameof(IModelType.DerivedModels)}");
                        baseModelDerived.Add(model);
                    }
                    continue;
                }
                if (reader.GetString() == nameof(IModelType.Properties))
                {
                    model = model ?? CreateInputModelTypeInstance(id, name, ns, accessibility, deprecated, description, usageString, discriminatorValue, discriminatorPropertyName, baseModel, properties, inheritedDictionaryType, isNullable, resolver);
                    reader.Read();
                    CreateProperties(ref reader, properties, options);
                    if (reader.TokenType != JsonTokenType.EndObject)
                    {
                        throw new JsonException($"{nameof(IModelType)}.{nameof(IModelType.Properties)} must be the last defined property.");
                    }
                }
                else
                {
                    reader.SkipProperty();
                }
            }

            return model ?? CreateInputModelTypeInstance(id, name, ns, accessibility, deprecated, description, usageString, discriminatorValue, discriminatorPropertyName, baseModel, properties, inheritedDictionaryType, isNullable, resolver);
        }

        private static InputModelType CreateInputModelTypeInstance(string? id, string? name, string? ns, string? accessibility, string? deprecated, string? description, string? usageString, string? discriminatorValue, string? discriminatorPropertyValue, IModelType? baseModel, IReadOnlyList<IModelProperty> properties, IDictionaryType? inheritedDictionaryType, bool isNullable, ReferenceResolver resolver)
        {
            name = name ?? throw new JsonException("Model must have name");
            InputModelTypeUsage usage = InputModelTypeUsage.None;
            if (usageString != null)
            {
                Enum.TryParse(usageString, ignoreCase: true, out usage);
            }

            var derivedModels = new List<IModelType>();
            var model = new InputModelType(name, ns, accessibility, deprecated, description, usage, properties, baseModel, derivedModels, discriminatorValue, discriminatorPropertyValue, inheritedDictionaryType, IsNullable: isNullable);

            if (id is not null)
            {
                resolver.AddReference(id, model);
                resolver.AddReference($"{model.Name}.{nameof(IModelType.DerivedModels)}", derivedModels);
            }

            if (baseModel is not null)
            {
                var baseModelDerived = (List<IModelType>)resolver.ResolveReference($"{baseModel.Name}.{nameof(IModelType.DerivedModels)}");
                baseModelDerived.Add(model);
            }

            return model;
        }

        private static void CreateProperties(ref Utf8JsonReader reader, ICollection<IModelProperty> properties, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            reader.Read();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                var property = reader.ReadWithConverter<IModelProperty>(options);
                properties.Add(property ?? throw new JsonException($"null {nameof(IModelProperty)} is not allowed"));
            }
            reader.Read();
        }
    }
}
