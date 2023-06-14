// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class SpecsAzureClientGeneratorCoreInternalModelFactory
    {
        /// <summary> Initializes a new instance of PublicModel. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.PublicModel"/> instance for mocking. </returns>
        public static PublicModel PublicModel(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new PublicModel(name);
        }

        /// <summary> Initializes a new instance of SharedModel. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.SharedModel"/> instance for mocking. </returns>
        public static SharedModel SharedModel(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new SharedModel(name);
        }
    }
}
