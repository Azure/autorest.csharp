// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ArmClientExtensions
    {
        /// <summary> Gets an object representing a the rest api operations. </summary>
        /// <returns> Returns a <see cref="RestApiContainer" /> object. </returns>
        public static RestApiContainer GetSampleRestApis(this ArmClient armClient)
        {
            return armClient.GetContainer((clientOptions, credential, baseUri, pipeline) =>
            {
                return new RestApiContainer(new ClientContext(clientOptions, credential, baseUri, pipeline));
            }
            );
        }
    }
}
