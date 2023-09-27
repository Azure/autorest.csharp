// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Experimental;

namespace OpenAI.Models
{
    /// <summary> The CreateEditRequest. </summary>
    public partial class CreateEditRequest
    {
        /// <summary> Initializes a new instance of CreateEditRequest. </summary>
        /// <param name="model">
        /// ID of the model to use. You can use the `text-davinci-edit-001` or `code-davinci-edit-001`
        /// model with this endpoint.
        /// </param>
        /// <param name="instruction"> The instruction that tells the model how to edit the prompt. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instruction"/> is null. </exception>
        public CreateEditRequest(EditModels model, string instruction)
        {
            ClientUtilities.AssertNotNull(instruction, nameof(instruction));

            Model = model;
            Instruction = instruction;
        }

        /// <summary> Initializes a new instance of CreateEditRequest. </summary>
        /// <param name="model">
        /// ID of the model to use. You can use the `text-davinci-edit-001` or `code-davinci-edit-001`
        /// model with this endpoint.
        /// </param>
        /// <param name="input"> The input text to use as a starting point for the edit. </param>
        /// <param name="instruction"> The instruction that tells the model how to edit the prompt. </param>
        /// <param name="n"> How many edits to generate for the input and instruction. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        ///
        /// We generally recommend altering this or `top_p` but not both.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising
        /// the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or `temperature` but not both.
        /// </param>
        internal CreateEditRequest(EditModels model, string input, string instruction, long? n, double? temperature, double? topP)
        {
            Model = model;
            Input = input;
            Instruction = instruction;
            N = n;
            Temperature = temperature;
            TopP = topP;
        }

        /// <summary>
        /// ID of the model to use. You can use the `text-davinci-edit-001` or `code-davinci-edit-001`
        /// model with this endpoint.
        /// </summary>
        public EditModels Model { get; }
        /// <summary> The input text to use as a starting point for the edit. </summary>
        public string Input { get; set; }
        /// <summary> The instruction that tells the model how to edit the prompt. </summary>
        public string Instruction { get; }
        /// <summary> How many edits to generate for the input and instruction. </summary>
        public long? N { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        ///
        /// We generally recommend altering this or `top_p` but not both.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising
        /// the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or `temperature` but not both.
        /// </summary>
        public double? TopP { get; set; }
    }
}
