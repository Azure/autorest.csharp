// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> WritableSubResource with flatten properties. </summary>
    public partial class WritableSubResourceModel2
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="WritableSubResourceModel2"/>. </summary>
        public WritableSubResourceModel2()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResourceModel2"/>. </summary>
        /// <param name="id"></param>
        /// <param name="idPropertiesId"></param>
        /// <param name="foo"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal WritableSubResourceModel2(string id, string idPropertiesId, string foo, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            IdPropertiesId = idPropertiesId;
            Foo = foo;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the id properties id. </summary>
        public string IdPropertiesId { get; set; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
