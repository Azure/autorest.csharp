// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> Plan for the resource. </summary>
    [PropertyReferenceType]
    public partial class MgmtReferenceTypesPlan
    {
        /// <summary> Initializes a new instance of MgmtReferenceTypesPlan. </summary>
        /// <param name="name"> A user defined name of the 3rd Party Artifact that is being procured. </param>
        /// <param name="publisher"> The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic. </param>
        /// <param name="product"> The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="publisher"/> or <paramref name="product"/> is null. </exception>
        [InitializationConstructor]
        public MgmtReferenceTypesPlan(string name, string publisher, string product)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(publisher, nameof(publisher));
            Argument.AssertNotNull(product, nameof(product));

            Name = name;
            Publisher = publisher;
            Product = product;
        }

        /// <summary> Initializes a new instance of MgmtReferenceTypesPlan. </summary>
        /// <param name="name"> A user defined name of the 3rd Party Artifact that is being procured. </param>
        /// <param name="publisher"> The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic. </param>
        /// <param name="product"> The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. </param>
        /// <param name="promotionCode"> A publisher provided promotion code as provisioned in Data Market for the said product/artifact. </param>
        /// <param name="version"> The version of the desired product/artifact. </param>
        [SerializationConstructor]
        internal MgmtReferenceTypesPlan(string name, string publisher, string product, string promotionCode, string version)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            PromotionCode = promotionCode;
            Version = version;
        }

        /// <summary> A user defined name of the 3rd Party Artifact that is being procured. </summary>
        public string Name { get; set; }
        /// <summary> The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic. </summary>
        public string Publisher { get; set; }
        /// <summary> The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. </summary>
        public string Product { get; set; }
        /// <summary> A publisher provided promotion code as provisioned in Data Market for the said product/artifact. </summary>
        public string PromotionCode { get; set; }
        /// <summary> The version of the desired product/artifact. </summary>
        public string Version { get; set; }
    }
}
