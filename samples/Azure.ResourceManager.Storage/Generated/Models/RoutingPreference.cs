// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Routing preference defines the type of network, either microsoft or internet routing to be used to deliver the user data, the default option is microsoft routing. </summary>
    public partial class RoutingPreference
    {
        /// <summary> Initializes a new instance of <see cref="RoutingPreference"/>. </summary>
        public RoutingPreference()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RoutingPreference"/>. </summary>
        /// <param name="routingChoice"> Routing Choice defines the kind of network routing opted by the user. </param>
        /// <param name="publishMicrosoftEndpoints"> A boolean flag which indicates whether microsoft routing storage endpoints are to be published. </param>
        /// <param name="publishInternetEndpoints"> A boolean flag which indicates whether internet routing storage endpoints are to be published. </param>
        internal RoutingPreference(RoutingChoice? routingChoice, bool? publishMicrosoftEndpoints, bool? publishInternetEndpoints)
        {
            RoutingChoice = routingChoice;
            PublishMicrosoftEndpoints = publishMicrosoftEndpoints;
            PublishInternetEndpoints = publishInternetEndpoints;
        }

        /// <summary> Routing Choice defines the kind of network routing opted by the user. </summary>
        public RoutingChoice? RoutingChoice { get; set; }
        /// <summary> A boolean flag which indicates whether microsoft routing storage endpoints are to be published. </summary>
        public bool? PublishMicrosoftEndpoints { get; set; }
        /// <summary> A boolean flag which indicates whether internet routing storage endpoints are to be published. </summary>
        public bool? PublishInternetEndpoints { get; set; }
    }
}
