// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithAbstractModel. </summary>
    public partial class ModelWithAbstractModel
    {
        /// <summary> Initializes a new instance of ModelWithAbstractModel. </summary>
        internal ModelWithAbstractModel()
        {
        }

        /// <summary> Initializes a new instance of ModelWithAbstractModel. </summary>
        /// <param name="abstractModelProperty">
        /// Please note <see cref="AbstractModel"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedFromAbstractModel"/>.
        /// </param>
        internal ModelWithAbstractModel(AbstractModel abstractModelProperty)
        {
            AbstractModelProperty = abstractModelProperty;
        }

        /// <summary>
        /// Gets the abstract model property
        /// Please note <see cref="AbstractModel"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedFromAbstractModel"/>.
        /// </summary>
        public AbstractModel AbstractModelProperty { get; }
    }
}
