// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> Normal custom object with flatten properties from CustomModel2. Also marked as azure resource, but it's not recognized either. </summary>
    public partial class CustomModel2
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CustomModel2"/>. </summary>
        public CustomModel2()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomModel2"/>. </summary>
        /// <param name="id"></param>
        /// <param name="bar"></param>
        /// <param name="idPropertiesId"></param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CustomModel2(string id, string bar, string idPropertiesId, string foo, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Bar = bar;
            IdPropertiesId = idPropertiesId;
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
