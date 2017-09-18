// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Dog : Pet
    {
        /// <summary>
        /// Initializes a new instance of the Dog class.
        /// </summary>
        public Dog()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Dog class.
        /// </summary>
        public Dog(int? id = default(int?), string name = default(string), string food = default(string))
            : base(id, name)
        {
            Food = food;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "food")]
        public string Food { get; set; }

    }
}
