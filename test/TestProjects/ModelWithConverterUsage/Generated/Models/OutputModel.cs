// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelWithConverterUsage.Models
{
    /// <summary> The product documentation. </summary>
    public partial class OutputModel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::ModelWithConverterUsage.Models.OutputModel
        ///
        /// </summary>
        internal OutputModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::ModelWithConverterUsage.Models.OutputModel
        ///
        /// </summary>
        /// <param name="outputModelProperty"> Constant string. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OutputModel(string outputModelProperty, Dictionary<string, BinaryData> rawData)
        {
            OutputModelProperty = outputModelProperty;
            _rawData = rawData;
        }

        /// <summary> Constant string. </summary>
        public string OutputModelProperty { get; }
    }
}
