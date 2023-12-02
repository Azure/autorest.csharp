// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace body_complex.Models
{
    /// <summary> The SmartSalmon. </summary>
    public partial class SmartSalmon : Salmon
    {
        /// <summary> Initializes a new instance of <see cref="SmartSalmon"/>. </summary>
        /// <param name="length"></param>
        public SmartSalmon(float length) : base(length)
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
            Fishtype = "smart_salmon";
        }

        /// <summary> Initializes a new instance of <see cref="SmartSalmon"/>. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        /// <param name="location"></param>
        /// <param name="iswild"></param>
        /// <param name="collegeDegree"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal SmartSalmon(string fishtype, string species, float length, IList<Fish> siblings, string location, bool? iswild, string collegeDegree, IDictionary<string, object> additionalProperties) : base(fishtype, species, length, siblings, location, iswild)
        {
            CollegeDegree = collegeDegree;
            AdditionalProperties = additionalProperties;
            Fishtype = fishtype ?? "smart_salmon";
        }

        /// <summary> Gets or sets the college degree. </summary>
        public string CollegeDegree { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
