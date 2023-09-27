// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Experimental;

namespace OpenAI.Models
{
    /// <summary> The CreateEditResponse. </summary>
    [Obsolete("deprecated")]
    public partial class CreateEditResponse
    {
        /// <summary> Initializes a new instance of CreateEditResponse. </summary>
        /// <param name="created"> The Unix timestamp (in seconds) of when the edit was created. </param>
        /// <param name="choices"> description: A list of edit choices. Can be more than one if `n` is greater than 1. </param>
        /// <param name="usage"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="choices"/> or <paramref name="usage"/> is null. </exception>
        internal CreateEditResponse(DateTimeOffset created, BinaryData choices, CompletionUsage usage)
        {
            ClientUtilities.AssertNotNull(choices, nameof(choices));
            ClientUtilities.AssertNotNull(usage, nameof(usage));

            Created = created;
            Choices = choices;
            Usage = usage;
        }

        /// <summary> Initializes a new instance of CreateEditResponse. </summary>
        /// <param name="object"> The object type, which is always `edit`. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the edit was created. </param>
        /// <param name="choices"> description: A list of edit choices. Can be more than one if `n` is greater than 1. </param>
        /// <param name="usage"></param>
        internal CreateEditResponse(CreateEditResponseObject @object, DateTimeOffset created, BinaryData choices, CompletionUsage usage)
        {
            Object = @object;
            Created = created;
            Choices = choices;
            Usage = usage;
        }

        /// <summary> The object type, which is always `edit`. </summary>
        public CreateEditResponseObject Object { get; } = CreateEditResponseObject.Edit;

        /// <summary> The Unix timestamp (in seconds) of when the edit was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary>
        /// description: A list of edit choices. Can be more than one if `n` is greater than 1.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public BinaryData Choices { get; }
        /// <summary> Gets the usage. </summary>
        public CompletionUsage Usage { get; }
    }
}
