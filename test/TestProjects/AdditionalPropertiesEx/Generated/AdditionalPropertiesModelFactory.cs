// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using AdditionalPropertiesEx.Models;

namespace AdditionalPropertiesEx
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class AdditionalPropertiesModelFactory
    {
        /// <summary> Initializes a new instance of OutputAdditionalPropertiesModel. </summary>
        /// <param name="id"> . </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.OutputAdditionalPropertiesModel"/> instance for mocking. </returns>
        public static OutputAdditionalPropertiesModel OutputAdditionalPropertiesModel(int id = default, IReadOnlyDictionary<string, string> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, string>();

            return new OutputAdditionalPropertiesModel(id, additionalProperties);
        }

        /// <summary> Initializes a new instance of OutputAdditionalPropertiesModelStruct. </summary>
        /// <param name="id"> . </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.OutputAdditionalPropertiesModelStruct"/> instance for mocking. </returns>
        public static OutputAdditionalPropertiesModelStruct OutputAdditionalPropertiesModelStruct(int id = default, IReadOnlyDictionary<string, string> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, string>();

            return new OutputAdditionalPropertiesModelStruct(id, additionalProperties);
        }
    }
}
