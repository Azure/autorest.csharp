// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class LongRunningOperationInfo
    {
        public LongRunningOperationInfo(string accessibility, string clientPrefix)
        {
            Accessibility = accessibility;
            ClientPrefix = clientPrefix;
        }

        public string Accessibility { get; }

        public string ClientPrefix { get; }

    }
}
