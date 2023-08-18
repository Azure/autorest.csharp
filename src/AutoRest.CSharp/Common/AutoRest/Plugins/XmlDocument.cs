// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Xml.Linq;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    public record XmlDocument(string TestFileName, XDocument XmlDocDocument);
}
