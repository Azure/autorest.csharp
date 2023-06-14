// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The product URL. </summary>
    internal partial class ProductUrl : GenericUrl
    {
        /// <summary> Initializes a new instance of ProductUrl. </summary>
        internal ProductUrl()
        {
        }

        /// <summary> URL value. </summary>
        public string OdataValue { get; }
    }
}
