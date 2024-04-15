// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models
{
    internal record ConvenienceMethodOmittingMessage
    {
        private ConvenienceMethodOmittingMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public static ConvenienceMethodOmittingMessage NotMeaningful = new("The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method");
    }
}
