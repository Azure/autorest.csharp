// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace ExtensionClientName.Models
{
    /// <summary> The RenamedSchema. </summary>
    public partial class RenamedSchema
    {
        /// <summary> Initializes a new instance of RenamedSchema. </summary>
        internal RenamedSchema()
        {
        }

        /// <summary> Initializes a new instance of RenamedSchema. </summary>
        /// <param name="renamedProperty"> A description about the set of tags. </param>
        /// <param name="renamedPropertyString"> A description about the set of tags. </param>
        internal RenamedSchema(IDictionary<string, string> renamedProperty, string renamedPropertyString)
        {
            RenamedProperty = renamedProperty;
            RenamedPropertyString = renamedPropertyString;
        }

        /// <summary> A description about the set of tags. </summary>
        public IDictionary<string, string> RenamedProperty { get; set; }
        /// <summary> A description about the set of tags. </summary>
        public string RenamedPropertyString { get; set; }
    }
}
