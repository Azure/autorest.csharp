// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ServiceClientMethodParameter
    {
        public ServiceClientMethodParameter(string name, ClientTypeReference type, ClientConstant? defaultValue, bool isRequired)
        {
            Name = name;
            Type = type;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }

        public ClientTypeReference Type { get; }
        public string Name { get; }
        public ClientConstant? DefaultValue { get; }
        public bool IsRequired { get; }
    }
}
