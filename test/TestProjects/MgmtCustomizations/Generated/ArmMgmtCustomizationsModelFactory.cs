// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtCustomizations;

namespace MgmtCustomizations.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtCustomizationsModelFactory
    {
        /// <summary> Initializes a new instance of PetStoreData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The properties. </param>
        /// <returns> A new <see cref="MgmtCustomizations.PetStoreData"/> instance for mocking. </returns>
        public static PetStoreData PetStoreData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, PetStoreProperties properties = null)
        {
            return new PetStoreData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <returns> A new <see cref="Models.Pet"/> instance for mocking. </returns>
        public static Pet Pet(string name = null, int size = default)
        {
            return new UnknownPet(default, name, size);
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="meow"> A cat can meow. </param>
        /// <returns> A new <see cref="Models.Cat"/> instance for mocking. </returns>
        public static Cat Cat(string name = null, int size = default, string meow = null)
        {
            return new Cat(PetKind.Cat, name, size, meow);
        }

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="bark"> A dog can bark. </param>
        /// <returns> A new <see cref="Models.Dog"/> instance for mocking. </returns>
        public static Dog Dog(string name = null, int size = default, string bark = null)
        {
            return new Dog(PetKind.Dog, name, size, bark);
        }
    }
}
