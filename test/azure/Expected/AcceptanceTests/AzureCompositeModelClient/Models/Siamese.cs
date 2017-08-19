// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Fixtures.AcceptanceTestsAzureCompositeModelClient;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Siamese : Cat
    {
        /// <summary>
        /// Initializes a new instance of the Siamese class.
        /// </summary>
        public Siamese()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Siamese class.
        /// </summary>
        public Siamese(int? id = default(int?), string name = default(string), string color = default(string), IList<Dog> hates = default(IList<Dog>), string breed = default(string))
            : base(id, name, color, hates)
        {
            Breed = breed;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "breed")]
        public string Breed { get; set; }

    }
}
