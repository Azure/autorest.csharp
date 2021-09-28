// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    [AttributeUsage(AttributeTargets.Assembly)]
    internal sealed class BuildPropertiesAttribute : Attribute
    {
        public string ArtifactsDirectory { get; }

        public BuildPropertiesAttribute(string artifactsDirectory)
        {
            ArtifactsDirectory = artifactsDirectory;
        }
    }
}
