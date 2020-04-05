// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Cookiecuttershark. </summary>
    public partial class Cookiecuttershark : Shark
    {
        /// <summary> Initializes a new instance of Cookiecuttershark. </summary>
        /// <param name="length"> . </param>
        /// <param name="birthday"> . </param>
        public Cookiecuttershark(float length, DateTimeOffset birthday) : base(length, birthday)
        {
            Fishtype = "cookiecuttershark";
        }

        /// <summary> Initializes a new instance of Cookiecuttershark. </summary>
        /// <param name="fishtype"> . </param>
        /// <param name="species"> . </param>
        /// <param name="length"> . </param>
        /// <param name="siblings"> . </param>
        /// <param name="age"> . </param>
        /// <param name="birthday"> . </param>
        internal Cookiecuttershark(string fishtype, string species, float length, IList<Fish> siblings, int? age, DateTimeOffset birthday) : base(fishtype, species, length, siblings, age, birthday)
        {
        }
    }
}
