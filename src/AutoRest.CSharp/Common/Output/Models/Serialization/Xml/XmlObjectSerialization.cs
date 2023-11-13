// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System.Net.ClientModel.Core;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectSerialization
    {
        public XmlObjectSerialization(string name,
            SerializableObjectType model,
            XmlObjectElementSerialization[] elements,
            XmlObjectAttributeSerialization[] attributes,
            XmlObjectArraySerialization[] embeddedArrays,
            XmlObjectContentSerialization? contentSerialization)
        {
            Type = model.Type;
            Elements = elements;
            Attributes = attributes;
            Name = name;
            EmbeddedArrays = embeddedArrays;
            ContentSerialization = contentSerialization;

            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            IModelInterface = new CSharpType(typeof(IPersistableModel<>), modelType);
            // we only need this interface when the model is a struct
            IModelObjectInterface = model.IsStruct ? (CSharpType)typeof(IPersistableModel<object>) : null;
            IXmlInterface = Configuration.ApiTypes.IXmlSerializableType;
        }

        public string Name { get; }
        public XmlObjectElementSerialization[] Elements { get; }
        public XmlObjectAttributeSerialization[] Attributes { get; }
        public XmlObjectArraySerialization[] EmbeddedArrays { get; }
        public XmlObjectContentSerialization? ContentSerialization { get; }
        public CSharpType Type { get; }

        /// <summary>
        /// The interface IXmlSerializable
        /// </summary>
        public CSharpType IXmlInterface { get; }
        /// <summary>
        /// The interface IModel{T}
        /// </summary>
        public CSharpType IModelInterface { get; }
        /// <summary>
        /// The interface IModel{object}
        /// </summary>
        public CSharpType? IModelObjectInterface { get; }
    }
}
