// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsInCadl.Models
{
    /// <summary> Collection item model. </summary>
    public partial class CollectionItem
    {
        /// <summary> Initializes a new instance of CollectionItem. </summary>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredModelRecord"/> is null. </exception>
        public CollectionItem(IDictionary<string, RecordItem> requiredModelRecord)
        {
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));

            RequiredModelRecord = requiredModelRecord;
        }

        /// <summary> Required model record. </summary>
        public IDictionary<string, RecordItem> RequiredModelRecord { get; }
    }
}
