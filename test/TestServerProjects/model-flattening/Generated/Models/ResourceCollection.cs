// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> The ResourceCollection. </summary>
    public partial class ResourceCollection
    {
        /// <summary> Flattened product. </summary>
        public FlattenedProduct Productresource { get; set; }
        public ICollection<FlattenedProduct> Arrayofresources { get; set; }
        /// <summary> Dictionary of &lt;FlattenedProduct&gt;. </summary>
        public IDictionary<string, FlattenedProduct> Dictionaryofresources { get; set; }
    }
}
