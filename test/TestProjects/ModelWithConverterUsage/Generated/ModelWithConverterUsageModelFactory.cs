// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelWithConverterUsage.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ModelWithConverterUsageModelFactory
    {
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="outputModelProperty"> Constant string. </param>
        /// <returns> A new <see cref="Models.OutputModel"/> instance for mocking. </returns>
        public static OutputModel OutputModel(string outputModelProperty = null)
        {
            return new OutputModel(outputModelProperty);
        }
    }
}
