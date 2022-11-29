// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using SupersetInheritance;

namespace SupersetInheritance.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class SupersetInheritanceModelFactory
    {

        /// <summary> Initializes a new instance of SupersetModel7Data. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="new"></param>
        /// <param name="systemData"> Metadata pertaining to creation and last modification of the resource. </param>
        /// <returns> A new <see cref="SupersetInheritance.SupersetModel7Data"/> instance for mocking. </returns>
        public static SupersetModel7Data SupersetModel7Data(string id = null, string name = null, string resourceType = null, string @new = null, SupersetModel7SystemData systemData = null)
        {
            return new SupersetModel7Data(id, name, resourceType, @new, systemData);
        }

        /// <summary> Initializes a new instance of SupersetModel7SystemData. </summary>
        /// <param name="createdBy"> The identity that created the resource. </param>
        /// <param name="createdOn"> The timestamp of resource creation (UTC). </param>
        /// <param name="lastModifiedBy"> The identity that last modified the resource. </param>
        /// <returns> A new <see cref="Models.SupersetModel7SystemData"/> instance for mocking. </returns>
        public static SupersetModel7SystemData SupersetModel7SystemData(string createdBy = null, DateTimeOffset? createdOn = null, string lastModifiedBy = null)
        {
            return new SupersetModel7SystemData(createdBy, createdOn, lastModifiedBy);
        }
    }
}
