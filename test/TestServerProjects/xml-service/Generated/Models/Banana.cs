// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> A banana. </summary>
    public partial class Banana
    {
        /// <summary> Initializes a new instance of Banana. </summary>
        internal Banana()
        {
        }
        /// <summary> Initializes a new instance of Banana. </summary>
        /// <param name="name"> . </param>
        /// <param name="flavor"> . </param>
        /// <param name="expiration"> The time at which you should reconsider eating this banana. </param>
        internal Banana(string name, string flavor, DateTimeOffset? expiration)
        {
            Name = name;
            Flavor = flavor;
            Expiration = expiration;
        }
        public string Name { get; set; }
        public string Flavor { get; set; }
        /// <summary> The time at which you should reconsider eating this banana. </summary>
        public DateTimeOffset? Expiration { get; set; }
    }
}
