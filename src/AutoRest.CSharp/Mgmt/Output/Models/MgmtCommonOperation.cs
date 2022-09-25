// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Output.Models;

internal record MgmtCommonOperation(MgmtClientOperation ClientOperation, MgmtClientOperation CoreOperation);
