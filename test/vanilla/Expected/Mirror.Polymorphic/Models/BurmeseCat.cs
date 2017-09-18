// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.MirrorPolymorphic.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class BurmeseCat : SiameseCat
    {
        /// <summary>
        /// Initializes a new instance of the BurmeseCat class.
        /// </summary>
        public BurmeseCat()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BurmeseCat class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="description">Description of a Animal.</param>
        /// <param name="color">cat color</param>
        /// <param name="length">cat length</param>
        /// <param name="nickName">cat nick name</param>
        public BurmeseCat(string id = default(string), string description = default(string), string color = default(string), int? length = default(int?), int? nickName = default(int?))
            : base(id, description, color, length)
        {
            NickName = nickName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets cat nick name
        /// </summary>
        [JsonProperty(PropertyName = "nickName")]
        public int? NickName { get; set; }

    }
}
