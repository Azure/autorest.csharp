// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> WritableSubResource WITHOUT flatten properties. </summary>
    public partial class WritableSubResourceModel1
    {
        /// <summary> Initializes a new instance of WritableSubResourceModel1. </summary>
        public WritableSubResourceModel1()
        {
        }

        /// <summary> Initializes a new instance of WritableSubResourceModel1. </summary>
        /// <param name="id"></param>
        /// <param name="foo"></param>
        internal WritableSubResourceModel1(string id, string foo)
        {
            Id = id;
            Foo = foo;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
