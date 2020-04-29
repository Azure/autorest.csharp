// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Shark. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="length"> . </param>
        /// <param name="birthday"> . </param>
        public Shark(float length, DateTimeOffset birthday) : base(length)
        {
            Birthday = birthday;
            Fishtype = "shark";
        }

        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="fishtype"> . </param>
        /// <param name="species"> . </param>
        /// <param name="length"> . </param>
        /// <param name="siblings"> . </param>
        /// <param name="age"> . </param>
        /// <param name="birthday"> . </param>
        internal Shark(string fishtype, string species, float length, IList<Fish> siblings, int? age, DateTimeOffset birthday) : base(fishtype, species, length, siblings)
        {
            Age = age;
            Birthday = birthday;
            Fishtype = fishtype ?? "shark";
        }

        public int? Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
