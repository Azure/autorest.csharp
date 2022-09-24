// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Output.Models;

internal record ScopeResourceTypeConstraint(FormattableString ScopePathGetter, ResourceTypeSegment ScopeResourceType);
