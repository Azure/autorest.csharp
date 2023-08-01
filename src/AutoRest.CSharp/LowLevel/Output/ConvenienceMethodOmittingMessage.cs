// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;

namespace AutoRest.CSharp.Output.Models
{
    internal class ConvenienceMethodOmittingMessage
    {
        private readonly ConvenienceMethodOmitReason _reason;
        private ConvenienceMethodOmittingMessage(ConvenienceMethodOmitReason reason)
        {
            _reason = reason;
            Message = reason switch
            {
                ConvenienceMethodOmitReason.PatchOperation => "The convenience method of this operation is not generated because this operation has a http verb of PATCH which we do not support yet.",
                ConvenienceMethodOmitReason.TypeNotConfident => "The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.",
                _ => throw new InvalidOperationException("should never happen"),
            };
        }

        public string Message { get; }

        public static ConvenienceMethodOmittingMessage? Create(ConvenienceMethodOmitReason? reason)
        {
            if (reason != null)
                return new ConvenienceMethodOmittingMessage(reason.Value);
            return null;
        }
    }
}
