// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(IReadOnlyList<Method> ConvenienceMethods, IReadOnlyList<Method> ProtocolMethods, Method RequestMethod, IReadOnlyList<RestClientMethod> RequestMethods, InputType? RequestBodyType, InputType? ResponseBodyType, bool IsPaging, bool IsLongRunning, string PagingItemName);

    internal record LegacyMethods(InputOperation Operation, IReadOnlyList<RestClientMethod> CreateMessageMethods, IReadOnlyList<Method> ConvenienceMethods, Method RequestMethod);
}
