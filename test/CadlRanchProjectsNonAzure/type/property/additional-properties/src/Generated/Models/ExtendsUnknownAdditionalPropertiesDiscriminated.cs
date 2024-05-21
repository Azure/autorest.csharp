// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    /// <summary>
    /// The model extends from Record&lt;unknown&gt; with a discriminator.
    /// Please note <see cref="ExtendsUnknownAdditionalPropertiesDiscriminated"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ExtendsUnknownAdditionalPropertiesDiscriminatedDerived"/>.
    /// </summary>
    public abstract partial class ExtendsUnknownAdditionalPropertiesDiscriminated
    {
        /// <summary> Initializes a new instance of <see cref="ExtendsUnknownAdditionalPropertiesDiscriminated"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected ExtendsUnknownAdditionalPropertiesDiscriminated(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            AdditionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ExtendsUnknownAdditionalPropertiesDiscriminated"/>. </summary>
        /// <param name="kind"> The discriminator. </param>
        /// <param name="name"> The name property. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal ExtendsUnknownAdditionalPropertiesDiscriminated(string kind, string name, IDictionary<string, BinaryData> additionalProperties)
        {
            Kind = kind;
            Name = name;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Initializes a new instance of <see cref="ExtendsUnknownAdditionalPropertiesDiscriminated"/> for deserialization. </summary>
        internal ExtendsUnknownAdditionalPropertiesDiscriminated()
        {
        }

        /// <summary> The discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> The name property. </summary>
        public string Name { get; set; }
        /// <summary>
        /// Additional Properties
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
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
        public IDictionary<string, BinaryData> AdditionalProperties { get; }
    }
}
