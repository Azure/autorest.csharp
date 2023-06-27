// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> SubResource with flatten properties. </summary>
    public partial class SubResourceModel2
    {
        /// <summary> Initializes a new instance of SubResourceModel2. </summary>
        public SubResourceModel2()
        {
        }

        /// <summary> Initializes a new instance of SubResourceModel2. </summary>
        /// <param name="id"></param>
        /// <param name="idPropertiesId"></param>
        /// <param name="foo"></param>
        internal SubResourceModel2(string id, string idPropertiesId, string foo)
        {
            Id = id;
            IdPropertiesId = idPropertiesId;
            Foo = foo;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets or sets the id properties id. </summary>
        public string IdPropertiesId { get; set; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
