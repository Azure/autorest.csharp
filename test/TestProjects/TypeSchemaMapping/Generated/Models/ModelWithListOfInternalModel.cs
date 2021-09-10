// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithListOfInternalModel. </summary>
    public partial class ModelWithListOfInternalModel
    {
        /// <summary> Initializes a new instance of ModelWithListOfInternalModel. </summary>
        internal ModelWithListOfInternalModel()
        {
            InternalListProperty = new ChangeTrackingList<InternalModel>();
        }

        /// <summary> Initializes a new instance of ModelWithListOfInternalModel. </summary>
        /// <param name="stringProperty"> The StringProperty. </param>
        /// <param name="internalListProperty"> The InternalListProperty. </param>
        internal ModelWithListOfInternalModel(string stringProperty, IReadOnlyList<InternalModel> internalListProperty)
        {
            StringProperty = stringProperty;
            InternalListProperty = internalListProperty;
        }

        /// <summary> The StringProperty. </summary>
        public string StringProperty { get; }
    }
}
