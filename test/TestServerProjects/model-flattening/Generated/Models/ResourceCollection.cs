// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace model_flattening.Models
{
    /// <summary> The ResourceCollection. </summary>
    public partial class ResourceCollection
    {
        /// <summary> Initializes a new instance of ResourceCollection. </summary>
        public ResourceCollection()
        {
            Arrayofresources = new ChangeTrackingList<FlattenedProduct>();
            Dictionaryofresources = new ChangeTrackingDictionary<string, FlattenedProduct>();
        }

        /// <summary> Initializes a new instance of ResourceCollection. </summary>
        /// <param name="productresource"> Flattened product. </param>
        /// <param name="arrayofresources"></param>
        /// <param name="dictionaryofresources"> Dictionary of &lt;FlattenedProduct&gt;. </param>
        internal ResourceCollection(FlattenedProduct productresource, IList<FlattenedProduct> arrayofresources, IDictionary<string, FlattenedProduct> dictionaryofresources)
        {
            Productresource = productresource;
            Arrayofresources = arrayofresources;
            Dictionaryofresources = dictionaryofresources;
        }

        /// <summary> Flattened product. </summary>
        public FlattenedProduct Productresource { get; set; }
        /// <summary> Gets the arrayofresources. </summary>
        public IList<FlattenedProduct> Arrayofresources { get; }
        /// <summary> Dictionary of &lt;FlattenedProduct&gt;. </summary>
        public IDictionary<string, FlattenedProduct> Dictionaryofresources { get; }
    }
}
