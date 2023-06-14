// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> A banana. </summary>
    public partial class Banana
    {
        /// <summary> Initializes a new instance of Banana. </summary>
        public Banana()
        {
        }

        /// <summary> Initializes a new instance of Banana. </summary>
        /// <param name="name"></param>
        /// <param name="flavor"></param>
        /// <param name="expiration"> The time at which you should reconsider eating this banana. </param>
        internal Banana(string name, string flavor, DateTimeOffset? expiration)
        {
            Name = name;
            Flavor = flavor;
            Expiration = expiration;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the flavor. </summary>
        public string Flavor { get; set; }
        /// <summary> The time at which you should reconsider eating this banana. </summary>
        public DateTimeOffset? Expiration { get; set; }
    }
}
