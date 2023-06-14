// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// LogAnalytics operation status response
    /// Serialized Name: LogAnalyticsOperationResult
    /// </summary>
    public partial class LogAnalytics
    {
        /// <summary> Initializes a new instance of LogAnalytics. </summary>
        internal LogAnalytics()
        {
        }

        /// <summary> Initializes a new instance of LogAnalytics. </summary>
        /// <param name="properties">
        /// LogAnalyticsOutput
        /// Serialized Name: LogAnalyticsOperationResult.properties
        /// </param>
        /// <param name="contentType">
        /// The content type.
        /// Serialized Name: LogAnalyticsOperationResult.contentType
        /// </param>
        /// <param name="content">
        /// Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted.
        /// Serialized Name: LogAnalyticsOperationResult.content
        /// </param>
        /// <param name="requestMethod">
        /// Gets the workflow trigger callback URL HTTP method.
        /// Serialized Name: LogAnalyticsOperationResult.method
        /// </param>
        /// <param name="basePathUri">
        /// Gets the workflow trigger callback URL base path.
        /// Serialized Name: LogAnalyticsOperationResult.basePath
        /// </param>
        internal LogAnalytics(LogAnalyticsOutput properties, ContentType? contentType, BinaryData content, RequestMethod? requestMethod, Uri basePathUri)
        {
            Properties = properties;
            ContentType = contentType;
            Content = content;
            RequestMethod = requestMethod;
            BasePathUri = basePathUri;
        }

        /// <summary>
        /// LogAnalyticsOutput
        /// Serialized Name: LogAnalyticsOperationResult.properties
        /// </summary>
        internal LogAnalyticsOutput Properties { get; }
        /// <summary>
        /// Output file Uri path to blob container.
        /// Serialized Name: LogAnalyticsOutput.output
        /// </summary>
        public string LogAnalyticsOutput
        {
            get => Properties?.Output;
        }

        /// <summary>
        /// The content type.
        /// Serialized Name: LogAnalyticsOperationResult.contentType
        /// </summary>
        public ContentType? ContentType { get; }
        /// <summary>
        /// Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted.
        /// Serialized Name: LogAnalyticsOperationResult.content
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public BinaryData Content { get; }
        /// <summary>
        /// Gets the workflow trigger callback URL HTTP method.
        /// Serialized Name: LogAnalyticsOperationResult.method
        /// </summary>
        public RequestMethod? RequestMethod { get; }
        /// <summary>
        /// Gets the workflow trigger callback URL base path.
        /// Serialized Name: LogAnalyticsOperationResult.basePath
        /// </summary>
        public Uri BasePathUri { get; }
    }
}
