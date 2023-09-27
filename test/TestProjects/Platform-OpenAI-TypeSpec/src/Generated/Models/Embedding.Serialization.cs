// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.ServiceModel.Rest.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class Embedding
    {
        internal static Embedding DeserializeEmbedding(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long index = default;
            EmbeddingObject @object = default;
            IReadOnlyList<double> embeddings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new EmbeddingObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("embeddings"u8))
                {
                    List<double> array = new List<double>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetDouble());
                    }
                    embeddings = array;
                    continue;
                }
            }
            return new Embedding(index, @object, embeddings);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static Embedding FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeEmbedding(document.RootElement);
        }
    }
}
