// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithArrayOfEnum. </summary>
    internal partial class ModelWithArrayOfEnum
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithArrayOfEnum"/>. </summary>
        public ModelWithArrayOfEnum()
        {
            ArrayOfEnum = new ChangeTrackingList<EnumForModelWithArrayOfEnum>();
            ArrayOfEnumCustomizedToNullable = new ChangeTrackingList<EnumForModelWithArrayOfEnum?>();
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithArrayOfEnum"/>. </summary>
        /// <param name="arrayOfEnum"></param>
        /// <param name="arrayOfEnumCustomizedToNullable"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithArrayOfEnum(IReadOnlyList<EnumForModelWithArrayOfEnum> arrayOfEnum, IReadOnlyList<EnumForModelWithArrayOfEnum?> arrayOfEnumCustomizedToNullable, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ArrayOfEnum = arrayOfEnum;
            ArrayOfEnumCustomizedToNullable = arrayOfEnumCustomizedToNullable;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
