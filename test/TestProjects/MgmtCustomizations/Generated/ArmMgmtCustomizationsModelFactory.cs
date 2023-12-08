// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtCustomizations;

namespace MgmtCustomizations.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtCustomizationsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="MgmtCustomizations.PetStoreData"/>. </summary>
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

        /// <summary> Initializes a new instance of <see cref="Models.Pet"/>. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <returns> A new <see cref="Models.Pet"/> instance for mocking. </returns>
        public static Pet Pet(string name = null, int size = default, DateTimeOffset? dateOfBirth = null)
        {
            return new UnknownPet(default, name, size, dateOfBirth);
        }

        /// <summary> Initializes a new instance of <see cref="Models.Cat"/>. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <param name="sleep"> A cat can sleep. </param>
        /// <param name="jump"> A cat can jump. </param>
        /// <param name="meow"> A cat can meow. </param>
        /// <returns> A new <see cref="Models.Cat"/> instance for mocking. </returns>
        public static Cat Cat(string name = null, int size = default, DateTimeOffset? dateOfBirth = null, string sleep = null, string jump = null, string meow = null)
        {
            return new Cat(PetKind.Cat, name, size, dateOfBirth, sleep, jump, meow);
        }

        /// <summary> Initializes a new instance of <see cref="Models.Dog"/>. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <param name="bark"> A dog can bark. </param>
        /// <param name="jump"> A dog can jump. </param>
        /// <returns> A new <see cref="Models.Dog"/> instance for mocking. </returns>
        public static Dog Dog(string name = null, int size = default, DateTimeOffset? dateOfBirth = null, string bark = null, string jump = null)
        {
            return new Dog(PetKind.Dog, name, size, dateOfBirth, bark, jump);
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <param name="meow"> A cat can meow. </param>
        /// <returns> A new <see cref="T:MgmtCustomizations.Models.Cat" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Cat Cat(string name, int size, DateTimeOffset? dateOfBirth, string meow)
        {
            return Cat(name, size, dateOfBirth, sleep: default, jump: default, meow);
        }

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <param name="bark"> A dog can bark. </param>
        /// <returns> A new <see cref="T:MgmtCustomizations.Models.Dog" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dog Dog(string name, int size, DateTimeOffset? dateOfBirth, string bark)
        {
            return Dog(name, size, dateOfBirth, bark, jump: default);
        }
    }
}
