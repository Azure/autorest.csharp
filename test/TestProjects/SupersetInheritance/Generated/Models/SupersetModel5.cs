// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using SupersetInheritance;

namespace SupersetInheritance.Models
{
    /// <summary> The SupersetModel5. </summary>
    public partial class SupersetModel5 : SupersetModel4Data
    {
        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        public SupersetModel5()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="new"></param>
        /// <param name="foo"></param>
        internal SupersetModel5(string id, string name, string type, string location, IDictionary<string, string> tags, string @new, string foo) : base(id, name, type, location, tags, @new)
        {
            Foo = foo;
        }

        public string Foo { get; set; }
    }
}
