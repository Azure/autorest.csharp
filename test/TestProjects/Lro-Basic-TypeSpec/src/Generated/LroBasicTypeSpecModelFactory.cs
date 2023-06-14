// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace LroBasicTypeSpec.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class LroBasicTypeSpecModelFactory
    {
        /// <summary> Initializes a new instance of Project. </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <returns> A new <see cref="Models.Project"/> instance for mocking. </returns>
        public static Project Project(string id = null, string description = null, string name = null)
        {
            return new Project(id, description, name);
        }
    }
}
