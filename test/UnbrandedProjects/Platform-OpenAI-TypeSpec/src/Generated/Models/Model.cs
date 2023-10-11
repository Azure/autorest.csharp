// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Internal;

namespace OpenAI.Models
{
    /// <summary> Describes an OpenAI model offering that can be used with the API. </summary>
    public partial class Model
    {
        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="id"> The model identifier, which can be referenced in the API endpoints. </param>
        /// <param name="created"> The Unix timestamp (in seconds) when the model was created. </param>
        /// <param name="ownedBy"> The organization that owns the model. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="ownedBy"/> is null. </exception>
        internal Model(string id, DateTimeOffset created, string ownedBy)
        {
            ClientUtilities.AssertNotNull(id, nameof(id));
            ClientUtilities.AssertNotNull(ownedBy, nameof(ownedBy));

            Id = id;
            Created = created;
            OwnedBy = ownedBy;
        }

        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="id"> The model identifier, which can be referenced in the API endpoints. </param>
        /// <param name="object"> The object type, which is always "model". </param>
        /// <param name="created"> The Unix timestamp (in seconds) when the model was created. </param>
        /// <param name="ownedBy"> The organization that owns the model. </param>
        internal Model(string id, ModelObject @object, DateTimeOffset created, string ownedBy)
        {
            Id = id;
            Object = @object;
            Created = created;
            OwnedBy = ownedBy;
        }

        /// <summary> The model identifier, which can be referenced in the API endpoints. </summary>
        public string Id { get; }
        /// <summary> The object type, which is always "model". </summary>
        public ModelObject Object { get; } = ModelObject.Model;

        /// <summary> The Unix timestamp (in seconds) when the model was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The organization that owns the model. </summary>
        public string OwnedBy { get; }
    }
}
