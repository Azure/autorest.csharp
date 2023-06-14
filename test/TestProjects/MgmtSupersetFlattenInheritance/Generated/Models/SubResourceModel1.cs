// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> SubResource WITHOUT flatten properties. </summary>
    public partial class SubResourceModel1
    {
        /// <summary> Initializes a new instance of SubResourceModel1. </summary>
        public SubResourceModel1()
        {
        }

        /// <summary> Initializes a new instance of SubResourceModel1. </summary>
        /// <param name="id"></param>
        /// <param name="foo"></param>
        internal SubResourceModel1(string id, string foo)
        {
            Id = id;
            Foo = foo;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
