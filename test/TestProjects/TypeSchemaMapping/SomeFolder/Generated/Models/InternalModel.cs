// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The InternalModel. </summary>
    internal partial class InternalModel
    {
        /// <summary> Initializes a new instance of InternalModel. </summary>
        internal InternalModel()
        {
        }

        /// <summary> Initializes a new instance of InternalModel. </summary>
        /// <param name="stringProperty"></param>
        internal InternalModel(string stringProperty)
        {
            StringProperty = stringProperty;
        }

        /// <summary> Gets the string property. </summary>
        public string StringProperty { get; }
    }
}
