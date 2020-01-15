// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ServiceClientParameter
    {
        public ServiceClientParameter(string name, string? description, ClientTypeReference type, ClientConstant? defaultValue, bool isRequired)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }

        public ClientTypeReference Type { get; }
        public string Name { get; }
        public string? Description { get; }
        public ClientConstant? DefaultValue { get; }
        public bool IsRequired { get; }
    }
}
