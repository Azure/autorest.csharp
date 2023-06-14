// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_formdata_urlencoded.Models
{
    /// <summary> The Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
    internal partial class Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
    {
        /// <summary> Initializes a new instance of Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        internal Paths14Hl8BdFormsdataurlencodedPetAddPetidPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(PetType petType, PetFood petFood, int petAge)
        {
            PetType = petType;
            PetFood = petFood;
            PetAge = petAge;
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
