// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// since the convenience method could be omitted by multiple reasons, should we use flags here?
export enum ConvenienceMethodOmitReason {
    TypeNotConfident = "TypeNotConfident",
    PatchOperation = "PatchOperation",
    SuppressedInTypeSpec = "SuppressedInTypeSpec"
}
