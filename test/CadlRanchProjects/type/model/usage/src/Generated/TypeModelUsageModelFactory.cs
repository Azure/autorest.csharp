// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Type.Model.Usage.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypeModelUsageModelFactory
    {
        /// <summary> Initializes a new instance of OutputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        /// <returns> A new <see cref="Models.OutputRecord"/> instance for mocking. </returns>
        public static OutputRecord OutputRecord(string requiredProp = null)
        {
            if (requiredProp == null)
            {
                throw new ArgumentNullException(nameof(requiredProp));
            }

            return new OutputRecord(requiredProp);
        }
    }
}
