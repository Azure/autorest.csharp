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
    using System.Linq;

    public partial class DurationWrapper
    {
        /// <summary>
        /// Initializes a new instance of the DurationWrapper class.
        /// </summary>
        public DurationWrapper()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DurationWrapper class.
        /// </summary>
        public DurationWrapper(System.TimeSpan? field = default(System.TimeSpan?))
        {
            Field = field;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public System.TimeSpan? Field { get; set; }

    }
}
