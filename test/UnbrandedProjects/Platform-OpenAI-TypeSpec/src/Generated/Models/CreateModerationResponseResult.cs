// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The CreateModerationResponseResult. </summary>
    public partial class CreateModerationResponseResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CreateModerationResponseResult"/>. </summary>
        /// <param name="flagged"> Whether the content violates [OpenAI's usage policies](/policies/usage-policies). </param>
        /// <param name="categories"> A list of the categories, and whether they are flagged or not. </param>
        /// <param name="categoryScores"> A list of the categories along with their scores as predicted by model. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="categories"/> or <paramref name="categoryScores"/> is null. </exception>
        internal CreateModerationResponseResult(bool flagged, CreateModerationResponseResultCategories categories, CreateModerationResponseResultCategoryScores categoryScores)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
            if (categoryScores == null)
            {
                throw new ArgumentNullException(nameof(categoryScores));
            }

            Flagged = flagged;
            Categories = categories;
            CategoryScores = categoryScores;
        }

        /// <summary> Initializes a new instance of <see cref="CreateModerationResponseResult"/>. </summary>
        /// <param name="flagged"> Whether the content violates [OpenAI's usage policies](/policies/usage-policies). </param>
        /// <param name="categories"> A list of the categories, and whether they are flagged or not. </param>
        /// <param name="categoryScores"> A list of the categories along with their scores as predicted by model. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateModerationResponseResult(bool flagged, CreateModerationResponseResultCategories categories, CreateModerationResponseResultCategoryScores categoryScores, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Flagged = flagged;
            Categories = categories;
            CategoryScores = categoryScores;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateModerationResponseResult"/> for deserialization. </summary>
        internal CreateModerationResponseResult()
        {
        }

        /// <summary> Whether the content violates [OpenAI's usage policies](/policies/usage-policies). </summary>
        public bool Flagged { get; }
        /// <summary> A list of the categories, and whether they are flagged or not. </summary>
        public CreateModerationResponseResultCategories Categories { get; }
        /// <summary> A list of the categories along with their scores as predicted by model. </summary>
        public CreateModerationResponseResultCategoryScores CategoryScores { get; }
    }
}
