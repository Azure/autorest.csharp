// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> WritableSubResource WITHOUT flatten properties. </summary>
    public partial class WritableSubResourceModel1
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="WritableSubResourceModel1"/>. </summary>
        public WritableSubResourceModel1()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResourceModel1"/>. </summary>
        /// <param name="id"></param>
        /// <param name="foo"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal WritableSubResourceModel1(string id, string foo, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Foo = foo;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
