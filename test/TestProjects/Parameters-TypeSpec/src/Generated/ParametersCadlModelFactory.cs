// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ParametersCadl.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ParametersCadlModelFactory
    {
        /// <summary> Initializes a new instance of Result. </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <returns> A new <see cref="Models.Result"/> instance for mocking. </returns>
        public static Result Result(string id = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return new Result(id);
        }
    }
}
