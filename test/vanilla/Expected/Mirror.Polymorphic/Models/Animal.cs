// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.MirrorPolymorphic.Models
{
    using Fixtures.MirrorPolymorphic;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Animal
    {
        /// <summary>
        /// Initializes a new instance of the Animal class.
        /// </summary>
        public Animal()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Animal class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="description">Description of a Animal.</param>
        public Animal(string id = default(string), string description = default(string))
        {
            Id = id;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets description of a Animal.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
