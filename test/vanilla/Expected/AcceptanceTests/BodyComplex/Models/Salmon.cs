// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsBodyComplex.Models
{
    using Fixtures.AcceptanceTestsBodyComplex;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("salmon")]
    public partial class Salmon : Fish
    {
        /// <summary>
        /// Initializes a new instance of the Salmon class.
        /// </summary>
        public Salmon()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Salmon class.
        /// </summary>
        public Salmon(double length, string species = default(string), IList<Fish> siblings = default(IList<Fish>), string location = default(string), bool? iswild = default(bool?))
            : base(length, species, siblings)
        {
            Location = location;
            Iswild = iswild;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "iswild")]
        public bool? Iswild { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
