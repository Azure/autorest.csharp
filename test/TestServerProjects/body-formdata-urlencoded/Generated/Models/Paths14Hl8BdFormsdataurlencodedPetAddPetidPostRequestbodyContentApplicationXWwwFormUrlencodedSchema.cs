// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_formdata_urlencoded.Models
{
    /// <summary> The Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
    internal partial class Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::body_formdata_urlencoded.Models.Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
        ///
        /// </summary>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        internal Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(PetType petType, PetFood petFood, int petAge)
        {
            PetType = petType;
            PetFood = petFood;
            PetAge = petAge;
        }

        /// <summary>
        /// Initializes a new instance of global::body_formdata_urlencoded.Models.Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
        ///
        /// </summary>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        /// <param name="name"> Updated name of the pet. </param>
        /// <param name="status"> Updated status of the pet. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(PetType petType, PetFood petFood, int petAge, string name, string status, Dictionary<string, BinaryData> rawData)
        {
            PetType = petType;
            PetFood = petFood;
            PetAge = petAge;
            Name = name;
            Status = status;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema"/> for deserialization. </summary>
        internal Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema()
        {
        }

        /// <summary> Can take a value of dog, or cat, or fish. </summary>
        public PetType PetType { get; }
        /// <summary> Can take a value of meat, or fish, or plant. </summary>
        public PetFood PetFood { get; }
        /// <summary> How many years is it old?. </summary>
        public int PetAge { get; }
        /// <summary> Updated name of the pet. </summary>
        public string Name { get; }
        /// <summary> Updated status of the pet. </summary>
        public string Status { get; }
    }
}
