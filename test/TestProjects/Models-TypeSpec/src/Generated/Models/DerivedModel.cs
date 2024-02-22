// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelsTypeSpec.Models
{
    /// <summary> Derived model. </summary>
    public partial class DerivedModel : BaseModel
    {
        /// <summary> Initializes a new instance of <see cref="DerivedModel"/>. </summary>
        /// <param name="requiredList"> Required collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredList"/> is null. </exception>
        public DerivedModel(IEnumerable<CollectionItem> requiredList)
        {
            if (requiredList == null)
            {
                throw new ArgumentNullException(nameof(requiredList));
            }

            RequiredList = requiredList.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModel"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="requiredList"> Required collection. </param>
        internal DerivedModel(IDictionary<string, BinaryData> serializedAdditionalRawData, IList<CollectionItem> requiredList) : base(serializedAdditionalRawData)
        {
            RequiredList = requiredList;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModel"/> for deserialization. </summary>
        internal DerivedModel()
        {
        }

        /// <summary> Required collection. </summary>
        public IList<CollectionItem> RequiredList { get; }
    }
}
