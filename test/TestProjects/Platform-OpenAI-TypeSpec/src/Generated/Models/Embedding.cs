// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Rest.Experimental;

namespace OpenAI.Models
{
    /// <summary> Represents an embedding vector returned by embedding endpoint. </summary>
    public partial class Embedding
    {
        /// <summary> Initializes a new instance of Embedding. </summary>
        /// <param name="index"> The index of the embedding in the list of embeddings. </param>
        /// <param name="embeddings">
        /// The embedding vector, which is a list of floats. The length of vector depends on the model as\
        /// listed in the [embedding guide](/docs/guides/embeddings).
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddings"/> is null. </exception>
        internal Embedding(long index, IEnumerable<double> embeddings)
        {
            ClientUtilities.AssertNotNull(embeddings, nameof(embeddings));

            Index = index;
            Embeddings = embeddings.ToList();
        }

        /// <summary> Initializes a new instance of Embedding. </summary>
        /// <param name="index"> The index of the embedding in the list of embeddings. </param>
        /// <param name="object"> The object type, which is always "embedding". </param>
        /// <param name="embeddings">
        /// The embedding vector, which is a list of floats. The length of vector depends on the model as\
        /// listed in the [embedding guide](/docs/guides/embeddings).
        /// </param>
        internal Embedding(long index, EmbeddingObject @object, IReadOnlyList<double> embeddings)
        {
            Index = index;
            Object = @object;
            Embeddings = embeddings;
        }

        /// <summary> The index of the embedding in the list of embeddings. </summary>
        public long Index { get; }
        /// <summary> The object type, which is always "embedding". </summary>
        public EmbeddingObject Object { get; } = EmbeddingObject.Embedding;

        /// <summary>
        /// The embedding vector, which is a list of floats. The length of vector depends on the model as\
        /// listed in the [embedding guide](/docs/guides/embeddings).
        /// </summary>
        public IReadOnlyList<double> Embeddings { get; }
    }
}
