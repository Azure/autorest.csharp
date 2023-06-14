// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Base model. </summary>
    public partial class NoUseBase
    {
        /// <summary> Initializes a new instance of NoUseBase. </summary>
        /// <param name="baseModelProp"> base model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="baseModelProp"/> is null. </exception>
        internal NoUseBase(string baseModelProp)
        {
            Argument.AssertNotNull(baseModelProp, nameof(baseModelProp));

            BaseModelProp = baseModelProp;
        }

        /// <summary> base model property. </summary>
        public string BaseModelProp { get; set; }
    }
}
