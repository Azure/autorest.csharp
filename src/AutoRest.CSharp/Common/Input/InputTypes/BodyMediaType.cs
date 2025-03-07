// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AutoRest.CSharp.Common.Input;

internal enum BodyMediaType
{
    None,
    Binary,
    Form,
    Json,
    Multipart,
    Text,
    Xml
}

public static class BodyMediaTypeHelper
{
    internal static BodyMediaType DetermineBodyMediaType(IReadOnlyList<string> contentTypes)
    {
        var mediaTypes = new HashSet<BodyMediaType>();
        foreach (var contentType in contentTypes)
        {
            mediaTypes.Add(FromString(contentType));
        }

        if (mediaTypes.Count > 1)
        {
            return BodyMediaType.Binary;
        }
        return mediaTypes.FirstOrDefault();
    }

    internal static BodyMediaType FromString(string contentType)
    {
        // TODO: This is a temporary solution. We will move this part to some common place.
        // This logic is a twist from https://github.com/Azure/autorest/blob/faf5c1168232ba8a1e8fe02fbc28667c00db8c96/packages/libs/codegen/src/media-types.ts#L53
        const string pattern = @"(application|audio|font|example|image|message|model|multipart|text|video|x-(?:[0-9A-Za-z!#$%&'*+.^_`|~-]+))\/([0-9A-Za-z!#$%&'*.^_`|~-]+)\s*(?:\+([0-9A-Za-z!#$%&'*.^_`|~-]+))?\s*(?:;.\s*(\S*))?";

        var matches = Regex.Matches(contentType, pattern);
        if (matches.Count == 0)
        {
            throw new NotSupportedException($"Content type {contentType} is not supported.");
        }

        var type = matches[0].Groups[1].Value;
        var subType = matches[0].Groups[2].Value;
        var suffix = matches[0].Groups[3].Value;
        var parameter = matches[0].Groups[4].Value;

        var typeSubs = contentType.Split('/');
        if (typeSubs.Length != 2)
        {
            throw new NotSupportedException($"Content type {contentType} is not supported.");
        }

        if (subType == "json" && (type == "application" || type == "text") && suffix == "" && parameter == "")
        {
            return BodyMediaType.Json;
        }

        // application/vnd.microsoft.appconfig.kv+json, where type is "application", subType is "vnd.microsoft.appconfig.kv", suffix is "json", and parameter is ""
        if (suffix == "json" && (type == "application" || type == "text") && parameter == "")
        {
            return BodyMediaType.Json;
        }

        if ((subType == "xml" || suffix == "xml") && (type == "application" || type == "text"))
        {
            return BodyMediaType.Xml;
        }

        if (type == "audio" || type == "image" || type == "video" || subType == "octet-stream" || parameter == "serialization=Avro")
        {
            return BodyMediaType.Binary;
        }

        if (type == "application" && (subType == "formEncoded" || subType == "x-www-form-urlencoded"))
        {
            return BodyMediaType.Form;
        }

        if (type == "multipart" && subType == "form-data")
        {
            return BodyMediaType.Multipart;
        }

        if (type == "application")
        {
            return BodyMediaType.Binary;
        }

        if (type == "text")
        {
            return BodyMediaType.Text;
        }

        throw new NotSupportedException($"Content type {contentType} is not supported.");
    }
}
