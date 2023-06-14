// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithArrayOfEnum. </summary>
    internal partial class ModelWithArrayOfEnum
    {
        /// <summary> Initializes a new instance of ModelWithArrayOfEnum. </summary>
        public ModelWithArrayOfEnum()
        {
            ArrayOfEnum = new ChangeTrackingList<EnumForModelWithArrayOfEnum>();
            ArrayOfEnumCustomizedToNullable = new ChangeTrackingList<EnumForModelWithArrayOfEnum?>();
        }

        /// <summary> Initializes a new instance of ModelWithArrayOfEnum. </summary>
        /// <param name="arrayOfEnum"></param>
        /// <param name="arrayOfEnumCustomizedToNullable"></param>
        internal ModelWithArrayOfEnum(IReadOnlyList<EnumForModelWithArrayOfEnum> arrayOfEnum, IReadOnlyList<EnumForModelWithArrayOfEnum?> arrayOfEnumCustomizedToNullable)
        {
            ArrayOfEnum = arrayOfEnum;
            ArrayOfEnumCustomizedToNullable = arrayOfEnumCustomizedToNullable;
        }
    }
}
