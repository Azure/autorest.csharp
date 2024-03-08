// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using ModelsTypeSpec;

namespace ModelsTypeSpec.Models
{
    /// <summary> Record item model. </summary>
    public partial class RecordItem : DerivedModel
    {
        /// <summary> Initializes a new instance of <see cref="RecordItem"/>. </summary>
        /// <param name="requiredList"> Required collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredList"/> is null. </exception>
        public RecordItem(IEnumerable<CollectionItem> requiredList) : base(requiredList)
        {
            Argument.AssertNotNull(requiredList, nameof(requiredList));
        }

        /// <summary> Initializes a new instance of <see cref="RecordItem"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="requiredList"> Required collection. </param>
        internal RecordItem(IDictionary<string, BinaryData> serializedAdditionalRawData, IList<CollectionItem> requiredList) : base(serializedAdditionalRawData, requiredList)
        {
        }

        /// <summary> Initializes a new instance of <see cref="RecordItem"/> for deserialization. </summary>
        internal RecordItem()
        {
        }
    }
}
