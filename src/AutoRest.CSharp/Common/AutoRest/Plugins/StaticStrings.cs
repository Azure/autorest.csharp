// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal static class StaticStrings
    {
        internal const string publicKeyAssemblyInfo = ", PublicKey = 0024000004800000940000000602000000240000525341310004000001000100d15ddcb29688295338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593daa7b11b4";
        internal const string assemblyInfoContentAssemblyInfo = @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(""{0}.Tests{1}"")]
{2}";
        internal const string resourceProviderAssemblyIfno = @"
// Replace Microsoft.Test with the correct resource provider namepace for your service and uncomment.
// See https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/azure-services-resource-providers
// for the list of possible values.
[assembly: Azure.Core.AzureResourceProviderNamespace(""{0}"")]
";
    }
}
