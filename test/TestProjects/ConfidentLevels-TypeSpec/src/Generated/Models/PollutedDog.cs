// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> The dog with a union type. </summary>
    public partial class PollutedDog : PollutedPet
    {
        /// <summary> Initializes a new instance of PollutedDog. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="woof"> Woof. </param>
        /// <param name="color"> Color, could be specified by a string or by an array of int as RGB. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="woof"/> or <paramref name="color"/> is null. </exception>
        public PollutedDog(string name, string woof, BinaryData color) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(woof, nameof(woof));
            Argument.AssertNotNull(color, nameof(color));

            Kind = "dog";
            Woof = woof;
            Color = color;
        }

        /// <summary> Initializes a new instance of PollutedDog. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="woof"> Woof. </param>
        /// <param name="color"> Color, could be specified by a string or by an array of int as RGB. </param>
        internal PollutedDog(string kind, string name, string woof, BinaryData color) : base(kind, name)
        {
            Woof = woof;
            Color = color;
        }

        /// <summary> Woof. </summary>
        public string Woof { get; set; }
        /// <summary>
        /// Color, could be specified by a string or by an array of int as RGB
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> Where <c>T</c> is of type <see cref="int"/></description>
        /// </item>
        /// </list>
        /// </remarks>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Color { get; set; }
    }
}
