// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;

namespace xml_service.Models
{
    public partial class ObjectWithXMsTextProperty
    {
        internal static ObjectWithXMsTextProperty DeserializeObjectWithXMsTextProperty(XElement element)
        {
            string language = default;
            string content = default;
            if (element.Attribute("language") is XAttribute languageAttribute)
            {
                language = (string)languageAttribute;
            }
            content = element.Value;
            return new ObjectWithXMsTextProperty(language, content);
        }
    }
}
