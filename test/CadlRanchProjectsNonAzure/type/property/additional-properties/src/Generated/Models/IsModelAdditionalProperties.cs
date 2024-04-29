// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    /// <summary> The model is from Record&lt;ModelForRecord&gt; type. </summary>
    public partial class IsModelAdditionalProperties
    {
        /// <summary> Initializes a new instance of <see cref="IsModelAdditionalProperties"/>. </summary>
        /// <param name="knownProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="knownProp"/> is null. </exception>
        public IsModelAdditionalProperties(ModelForRecord knownProp)
        {
            Argument.AssertNotNull(knownProp, nameof(knownProp));

            KnownProp = knownProp;
            AdditionalProperties = new ChangeTrackingDictionary<string, ModelForRecord>();
        }

        /// <summary> Initializes a new instance of <see cref="IsModelAdditionalProperties"/>. </summary>
        /// <param name="knownProp"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal IsModelAdditionalProperties(ModelForRecord knownProp, IDictionary<string, ModelForRecord> additionalProperties)
        {
            KnownProp = knownProp;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Initializes a new instance of <see cref="IsModelAdditionalProperties"/> for deserialization. </summary>
        internal IsModelAdditionalProperties()
        {
        }

        /// <summary> Gets or sets the known prop. </summary>
        public ModelForRecord KnownProp { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, ModelForRecord> AdditionalProperties { get; }
    }
}
