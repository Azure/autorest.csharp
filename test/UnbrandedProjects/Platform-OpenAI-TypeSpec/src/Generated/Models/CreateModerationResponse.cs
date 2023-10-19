// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.ClientModel.Internal;

namespace OpenAI.Models
{
    /// <summary> The CreateModerationResponse. </summary>
    public partial class CreateModerationResponse
    {
        /// <summary> Initializes a new instance of CreateModerationResponse. </summary>
        /// <param name="id"> The unique identifier for the moderation request. </param>
        /// <param name="model"> The model used to generate the moderation results. </param>
        /// <param name="results"> A list of moderation objects. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="model"/> or <paramref name="results"/> is null. </exception>
        internal CreateModerationResponse(string id, string model, IEnumerable<CreateResult> results)
        {
            ClientUtilities.AssertNotNull(id, nameof(id));
            ClientUtilities.AssertNotNull(model, nameof(model));
            ClientUtilities.AssertNotNull(results, nameof(results));

            Id = id;
            Model = model;
            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of CreateModerationResponse. </summary>
        /// <param name="id"> The unique identifier for the moderation request. </param>
        /// <param name="model"> The model used to generate the moderation results. </param>
        /// <param name="results"> A list of moderation objects. </param>
        internal CreateModerationResponse(string id, string model, IReadOnlyList<CreateResult> results)
        {
            Id = id;
            Model = model;
            Results = results;
        }

        /// <summary> The unique identifier for the moderation request. </summary>
        public string Id { get; }
        /// <summary> The model used to generate the moderation results. </summary>
        public string Model { get; }
        /// <summary> A list of moderation objects. </summary>
        public IReadOnlyList<CreateResult> Results { get; }
    }
}
