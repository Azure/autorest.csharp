// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithInternalModel. </summary>
    public partial class ModelWithInternalModel
    {
        /// <summary> Initializes a new instance of ModelWithInternalModel. </summary>
        internal ModelWithInternalModel()
        {
        }

        /// <summary> Initializes a new instance of ModelWithInternalModel. </summary>
        /// <param name="internalProperty"></param>
        internal ModelWithInternalModel(InternalModel internalProperty)
        {
            InternalProperty = internalProperty;
        }
    }
}
