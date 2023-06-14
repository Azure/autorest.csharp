// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Base information about the shared gallery resource in pir. </summary>
    public partial class PirSharedGalleryResource : PirResource
    {
        /// <summary> Initializes a new instance of PirSharedGalleryResource. </summary>
        internal PirSharedGalleryResource()
        {
        }

        /// <summary> Initializes a new instance of PirSharedGalleryResource. </summary>
        /// <param name="name"> Resource name. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="uniqueId"> The unique id of this shared gallery. </param>
        internal PirSharedGalleryResource(string name, string location, string uniqueId) : base(name, location)
        {
            UniqueId = uniqueId;
        }

        /// <summary> The unique id of this shared gallery. </summary>
        public string UniqueId { get; }
    }
}
