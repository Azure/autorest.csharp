// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace SupersetFlattenInheritance.Models
{
    /// <summary> Normal custom object with flatten properties from CustomModel2. Also marked as azure resource, but it&apos;s not recognized either. </summary>
    public partial class CustomModel2
    {
        /// <summary> Initializes a new instance of <see cref="CustomModel2"/>. </summary>
        public CustomModel2()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomModel2"/>. </summary>
        /// <param name="id"></param>
        /// <param name="bar"></param>
        /// <param name="idPropertiesId"></param>
        /// <param name="foo"></param>
        internal CustomModel2(string id, string bar, string idPropertiesId, string foo)
        {
            Id = id;
            Bar = bar;
            IdPropertiesId = idPropertiesId;
            Foo = foo;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the bar. </summary>
        public string Bar { get; set; }
        /// <summary> Gets or sets the id properties id. </summary>
        public string IdPropertiesId { get; set; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
