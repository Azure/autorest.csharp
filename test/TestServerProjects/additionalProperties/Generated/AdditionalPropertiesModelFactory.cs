// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using additionalProperties.Models;

namespace additionalProperties
{
    /// <summary> Model factory for AdditionalProperties read-only models. </summary>
    public static class AdditionalPropertiesModelFactory
    {
        /// <summary> Initializes new instance of PetAPTrue class. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="additionalProperties"> . </param>
        /// <returns> A new <see cref="Models.PetAPTrue"/> instance for mocking. </returns>
        public static PetAPTrue PetAPTrue(int id = default, string name = default, bool? status = default, IDictionary<string, object> additionalProperties = default)
        {
            additionalProperties ??= new Dictionary<string, object>();
            return new PetAPTrue(id, name, status, additionalProperties);
        }

        /// <summary> Initializes new instance of PetAPObject class. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="additionalProperties"> . </param>
        /// <returns> A new <see cref="Models.PetAPObject"/> instance for mocking. </returns>
        public static PetAPObject PetAPObject(int id = default, string name = default, bool? status = default, IDictionary<string, object> additionalProperties = default)
        {
            additionalProperties ??= new Dictionary<string, object>();
            return new PetAPObject(id, name, status, additionalProperties);
        }

        /// <summary> Initializes new instance of PetAPString class. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="additionalProperties"> . </param>
        /// <returns> A new <see cref="Models.PetAPString"/> instance for mocking. </returns>
        public static PetAPString PetAPString(int id = default, string name = default, bool? status = default, IDictionary<string, string> additionalProperties = default)
        {
            additionalProperties ??= new Dictionary<string, string>();
            return new PetAPString(id, name, status, additionalProperties);
        }

        /// <summary> Initializes new instance of PetAPInProperties class. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="additionalProperties"> Dictionary of &lt;number&gt;. </param>
        /// <returns> A new <see cref="Models.PetAPInProperties"/> instance for mocking. </returns>
        public static PetAPInProperties PetAPInProperties(int id = default, string name = default, bool? status = default, IDictionary<string, float> additionalProperties = default)
        {
            additionalProperties ??= new Dictionary<string, float>();
            return new PetAPInProperties(id, name, status, additionalProperties);
        }

        /// <summary> Initializes new instance of PetAPInPropertiesWithAPString class. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="odataLocation"> . </param>
        /// <param name="additionalProperties"> Dictionary of &lt;number&gt;. </param>
        /// <param name="moreAdditionalProperties"> . </param>
        /// <returns> A new <see cref="Models.PetAPInPropertiesWithAPString"/> instance for mocking. </returns>
        public static PetAPInPropertiesWithAPString PetAPInPropertiesWithAPString(int id = default, string name = default, bool? status = default, string odataLocation = default, IDictionary<string, float> additionalProperties = default, IDictionary<string, string> moreAdditionalProperties = default)
        {
            additionalProperties ??= new Dictionary<string, float>();
            moreAdditionalProperties ??= new Dictionary<string, string>();
            return new PetAPInPropertiesWithAPString(id, name, status, odataLocation, additionalProperties, moreAdditionalProperties);
        }
    }
}
