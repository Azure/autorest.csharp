// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class Metrics : IXmlSerializable, IModelSerializable<Metrics>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement(nameHint ?? "Metrics");
            if (Optional.IsDefined(Version))
            {
                writer.WriteStartElement("Version");
                writer.WriteValue(Version);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (Optional.IsDefined(IncludeAPIs))
            {
                writer.WriteStartElement("IncludeAPIs");
                writer.WriteValue(IncludeAPIs.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(RetentionPolicy))
            {
                writer.WriteObjectValue(RetentionPolicy, "RetentionPolicy");
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static Metrics DeserializeMetrics(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            string version = default;
            bool enabled = default;
            bool? includeAPIs = default;
            RetentionPolicy retentionPolicy = default;
            if (element.Element("Version") is XElement versionElement)
            {
                version = (string)versionElement;
            }
            if (element.Element("Enabled") is XElement enabledElement)
            {
                enabled = (bool)enabledElement;
            }
            if (element.Element("IncludeAPIs") is XElement includeAPIsElement)
            {
                includeAPIs = (bool?)includeAPIsElement;
            }
            if (element.Element("RetentionPolicy") is XElement retentionPolicyElement)
            {
                retentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicyElement);
            }
            return new Metrics(version, enabled, includeAPIs, retentionPolicy, default);
        }

        BinaryData IModelSerializable<Metrics>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            options ??= ModelSerializerOptions.DefaultWireOptions;
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            Serialize(writer, null, options);
            writer.Flush();
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        Metrics IModelSerializable<Metrics>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeMetrics(XElement.Load(data.ToStream()), options);
        }

        /// <summary> Converts a <see cref="Metrics"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Metrics"/> to convert. </param>
        public static implicit operator RequestContent(Metrics model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Metrics"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Metrics(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeMetrics(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
