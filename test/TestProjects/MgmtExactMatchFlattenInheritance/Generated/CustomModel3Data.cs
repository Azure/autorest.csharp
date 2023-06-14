// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using MgmtExactMatchFlattenInheritance.Models;

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary>
    /// A class representing the CustomModel3 data model.
    /// Pure custom model, the purpose is to pull in a WritableSubResource model so that it can be generated.
    /// </summary>
    public partial class CustomModel3Data : AzureResourceFlattenModel7
    {
        /// <summary> Initializes a new instance of CustomModel3Data. </summary>
        public CustomModel3Data()
        {
        }

        /// <summary> Initializes a new instance of CustomModel3Data. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="foo"></param>
        internal CustomModel3Data(string id, string name, string resourceType, string foo) : base(id, name, resourceType)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
