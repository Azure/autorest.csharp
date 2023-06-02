// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace MgmtCustomizations.Models
{
    public partial class Cat : Pet
    {
        /// <summary> A cat can meow. We changed the readonly flag of this property using customization code </summary>
        public string Meow { get; set; }

        /// <summary> This is an old property that already been removed on the current spec, we add this back using customization code to keep backward compatibility </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [CodeGenMemberSerialization("oldProperty")]
        public string OldProperty { get; set; }
    }
}
