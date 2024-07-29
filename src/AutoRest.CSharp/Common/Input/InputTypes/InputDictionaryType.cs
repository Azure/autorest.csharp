// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputDictionaryType(string Name, InputType KeyType, InputType ValueType, IReadOnlyList<InputDecoratorInfo> Decorators) : InputType(Name, Decorators) { }
