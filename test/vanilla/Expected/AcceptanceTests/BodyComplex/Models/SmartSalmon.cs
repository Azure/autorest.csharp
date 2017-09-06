// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyComplex.Models
{
    using Fixtures.AcceptanceTestsBodyComplex;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("smart_salmon")]
    public partial class SmartSalmon : Salmon
    {
        /// <summary>
        /// Initializes a new instance of the SmartSalmon class.
        /// </summary>
        public SmartSalmon()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SmartSalmon class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        public SmartSalmon(double length, string species = default(string), IList<Fish> siblings = default(IList<Fish>), string location = default(string), bool? iswild = default(bool?), IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string collegeDegree = default(string))
            : base(length, species, siblings, location, iswild)
        {
            AdditionalProperties = additionalProperties;
            CollegeDegree = collegeDegree;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "college_degree")]
        public string CollegeDegree { get; set; }

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
