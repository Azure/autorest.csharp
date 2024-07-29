// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputDecoratorInfo(string Name, IReadOnlyDictionary<string, object> Arguments);
