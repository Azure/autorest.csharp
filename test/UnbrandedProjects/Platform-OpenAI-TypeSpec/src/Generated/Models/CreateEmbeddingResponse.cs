// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Rest.Internal;

namespace OpenAI.Models
{
    /// <summary> The CreateEmbeddingResponse. </summary>
    public partial class CreateEmbeddingResponse
    {
        /// <summary> Initializes a new instance of CreateEmbeddingResponse. </summary>
        /// <param name="model"> The name of the model used to generate the embedding. </param>
        /// <param name="data"> The list of embeddings generated by the model. </param>
        /// <param name="usage"> The usage information for the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/>, <paramref name="data"/> or <paramref name="usage"/> is null. </exception>
        internal CreateEmbeddingResponse(string model, IEnumerable<Embedding> data, CreateEmbeddingUsage usage)
        {
            ClientUtilities.AssertNotNull(model, nameof(model));
            ClientUtilities.AssertNotNull(data, nameof(data));
            ClientUtilities.AssertNotNull(usage, nameof(usage));

            Model = model;
            Data = data.ToList();
            Usage = usage;
        }

        /// <summary> Initializes a new instance of CreateEmbeddingResponse. </summary>
        /// <param name="object"> The object type, which is always "embedding". </param>
        /// <param name="model"> The name of the model used to generate the embedding. </param>
        /// <param name="data"> The list of embeddings generated by the model. </param>
        /// <param name="usage"> The usage information for the request. </param>
        internal CreateEmbeddingResponse(CreateEmbeddingResponseObject @object, string model, IReadOnlyList<Embedding> data, CreateEmbeddingUsage usage)
        {
            Object = @object;
            Model = model;
            Data = data;
            Usage = usage;
        }

        /// <summary> The object type, which is always "embedding". </summary>
        public CreateEmbeddingResponseObject Object { get; } = CreateEmbeddingResponseObject.Embedding;

        /// <summary> The name of the model used to generate the embedding. </summary>
        public string Model { get; }
        /// <summary> The list of embeddings generated by the model. </summary>
        public IReadOnlyList<Embedding> Data { get; }
        /// <summary> The usage information for the request. </summary>
        public CreateEmbeddingUsage Usage { get; }
    }
}
