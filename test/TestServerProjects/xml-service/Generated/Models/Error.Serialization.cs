// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    internal partial class Error
    {
        internal static Error DeserializeError(XElement element)
        {
            int? status = default;
            string message = default;
            if (element.Element("status") is XElement statusElement)
            {
                status = (int?)statusElement;
            }
            if (element.Element("message") is XElement messageElement)
            {
                message = (string)messageElement;
            }
            return new Error(status, message);
        }
    }
}
