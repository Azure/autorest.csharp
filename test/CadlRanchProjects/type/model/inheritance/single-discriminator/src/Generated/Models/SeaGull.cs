// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> The second level model in polymorphic single level inheritance. </summary>
    public partial class SeaGull : Bird
    {
        /// <summary> Initializes a new instance of SeaGull. </summary>
        /// <param name="wingspan"></param>
        public SeaGull(int wingspan) : base(wingspan)
        {
            Kind = "seagull";
        }

        /// <summary> Initializes a new instance of SeaGull. </summary>
        /// <param name="kind"></param>
        /// <param name="wingspan"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SeaGull(string kind, int wingspan, Dictionary<string, BinaryData> rawData) : base(kind, wingspan, rawData)
        {
        }
    }
}
