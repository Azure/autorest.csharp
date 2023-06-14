// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> Normal custom object, although marked as azure resource, but it's not recognized by autorest. </summary>
    public partial class CustomModel1
    {
        /// <summary> Initializes a new instance of CustomModel1. </summary>
        public CustomModel1()
        {
        }

        /// <summary> Initializes a new instance of CustomModel1. </summary>
        /// <param name="id"></param>
        /// <param name="foo"></param>
        internal CustomModel1(string id, string foo)
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
