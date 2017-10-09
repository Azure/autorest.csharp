// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyString.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class RefColorConstant
    {
        /// <summary>
        /// Initializes a new instance of the RefColorConstant class.
        /// </summary>
        public RefColorConstant()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RefColorConstant class.
        /// </summary>
        /// <param name="field1">Sample string.</param>
        public RefColorConstant(string field1 = default(string))
        {
            Field1 = field1;
            CustomInit();
        }
        /// <summary>
        /// Static constructor for RefColorConstant class.
        /// </summary>
        static RefColorConstant()
        {
            ColorConstant = "green-color";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets sample string.
        /// </summary>
        [JsonProperty(PropertyName = "field1")]
        public string Field1 { get; set; }

        /// <summary>
        /// Referenced Color Constant Description.
        /// </summary>
        [JsonProperty(PropertyName = "ColorConstant")]
        public static string ColorConstant { get; private set; }

    }
}
