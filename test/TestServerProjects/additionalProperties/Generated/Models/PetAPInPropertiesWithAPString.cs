// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace additionalProperties.Models
{
    /// <summary> The PetAPInPropertiesWithAPString. </summary>
    public partial class PetAPInPropertiesWithAPString
    {
        /// <summary> Initializes a new instance of PetAPInPropertiesWithAPString. </summary>
        /// <param name="id"></param>
        /// <param name="odataLocation"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="odataLocation"/> is null. </exception>
        public PetAPInPropertiesWithAPString(int id, string odataLocation)
        {
            Argument.AssertNotNull(odataLocation, nameof(odataLocation));

            Id = id;
            OdataLocation = odataLocation;
            AdditionalProperties = new ChangeTrackingDictionary<string, float>();
            MoreAdditionalProperties = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of PetAPInPropertiesWithAPString. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="odataLocation"></param>
        /// <param name="additionalProperties"> Dictionary of &lt;number&gt;. </param>
        /// <param name="moreAdditionalProperties"> Additional Properties. </param>
        internal PetAPInPropertiesWithAPString(int id, string name, bool? status, string odataLocation, IDictionary<string, float> additionalProperties, IDictionary<string, string> moreAdditionalProperties)
        {
            Id = id;
            Name = name;
            Status = status;
            OdataLocation = odataLocation;
            AdditionalProperties = additionalProperties;
            MoreAdditionalProperties = moreAdditionalProperties;
        }

        /// <summary> Gets or sets the id. </summary>
        public int Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets the status. </summary>
        public bool? Status { get; }
        /// <summary> Gets or sets the odata location. </summary>
        public string OdataLocation { get; set; }
        /// <summary> Dictionary of &lt;number&gt;. </summary>
        public IDictionary<string, float> AdditionalProperties { get; }
    }
}
