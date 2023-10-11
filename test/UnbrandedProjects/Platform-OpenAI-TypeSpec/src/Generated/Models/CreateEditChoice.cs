// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Internal;

namespace OpenAI.Models
{
    /// <summary> The CreateEditChoice. </summary>
    public partial class CreateEditChoice
    {
        /// <summary> Initializes a new instance of CreateEditChoice. </summary>
        /// <param name="text"> The edited result. </param>
        /// <param name="index"> The index of the choice in the list of choices. </param>
        /// <param name="finishReason">
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, or `length` if the maximum number of tokens
        /// specified in the request was reached.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        internal CreateEditChoice(string text, long index, CreateEditChoiceFinishReason finishReason)
        {
            ClientUtilities.AssertNotNull(text, nameof(text));

            Text = text;
            Index = index;
            FinishReason = finishReason;
        }

        /// <summary> The edited result. </summary>
        public string Text { get; }
        /// <summary> The index of the choice in the list of choices. </summary>
        public long Index { get; }
        /// <summary>
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, or `length` if the maximum number of tokens
        /// specified in the request was reached.
        /// </summary>
        public CreateEditChoiceFinishReason FinishReason { get; }
    }
}
