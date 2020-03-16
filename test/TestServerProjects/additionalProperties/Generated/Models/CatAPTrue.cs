// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace additionalProperties.Models
{
    /// <summary> The CatAPTrue. </summary>
    public partial class CatAPTrue : PetAPTrue
    {
        /// <summary> Initializes a new instance of CatAPTrue. </summary>
        internal CatAPTrue()
        {
        }

        /// <summary> Initializes a new instance of CatAPTrue. </summary>
        /// <param name="friendly"> . </param>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        internal CatAPTrue(bool? friendly, int id, string name, bool? status) : base(id, name, status)
        {
            Friendly = friendly;
        }

        public bool? Friendly { get; set; }
    }
}
