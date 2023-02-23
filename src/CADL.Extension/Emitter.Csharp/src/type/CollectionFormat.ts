// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export enum CollectionFormat {
    CSV = "csv",
    SSV = "ssv",
    TSV = "tsv",
    Pipes = "pipes",
    Multi = "multi"
}

export const collectionFormatToDelimMap: { [key in CollectionFormat]: string|undefined } = {
    [CollectionFormat.CSV]: ",",
    [CollectionFormat.SSV]: " ",
    [CollectionFormat.TSV]: "\t",
    [CollectionFormat.Pipes]: "|",
    [CollectionFormat.Multi]: undefined
};
