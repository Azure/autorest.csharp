// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtOmitOperationGroups;

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtOmitOperationGroupsModelFactory
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtOmitOperationGroups.Models.ModelZ
        ///
        /// </summary>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <returns> A new <see cref="Models.ModelZ"/> instance for mocking. </returns>
        public static ModelZ ModelZ(string h = null, string i = null)
        {
            return new ModelZ(h, i, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtOmitOperationGroups.Models.ModelQ
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="m"></param>
        /// <returns> A new <see cref="Models.ModelQ"/> instance for mocking. </returns>
        public static ModelQ ModelQ(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string m = null)
        {
            return new ModelQ(id, name, resourceType, systemData, m, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtOmitOperationGroups.Model2Data
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="b"></param>
        /// <param name="modelx"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns> A new <see cref="MgmtOmitOperationGroups.Model2Data"/> instance for mocking. </returns>
        public static Model2Data Model2Data(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string b = null, ModelX modelx = null, string f = null, string g = null)
        {
            return new Model2Data(id, name, resourceType, systemData, b, modelx, f, g, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtOmitOperationGroups.Models.Model4
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="j"></param>
        /// <param name="modelz"></param>
        /// <returns> A new <see cref="Models.Model4"/> instance for mocking. </returns>
        public static Model4 Model4(string id = null, string j = null, ModelZ modelz = null)
        {
            return new Model4(id, j, modelz, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtOmitOperationGroups.Models.Model5
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="k"></param>
        /// <param name="modelqs"></param>
        /// <returns> A new <see cref="Models.Model5"/> instance for mocking. </returns>
        public static Model5 Model5(string id = null, string k = null, IEnumerable<ModelQ> modelqs = null)
        {
            modelqs ??= new List<ModelQ>();

            return new Model5(id, k, modelqs?.ToList(), default);
        }
    }
}
