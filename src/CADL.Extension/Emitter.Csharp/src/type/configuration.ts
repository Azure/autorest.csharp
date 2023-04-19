// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface Configuration {
    OutputFolder: string;
    Namespace: string;
    LibraryName: string | null;
    SharedSourceFolders: string[];
    SingleTopLevelClient?: boolean;
    "unreferenced-types-handling"?:
        | "removeOrInternalize"
        | "internalize"
        | "keepAll";
    "model-namespace"?: boolean;
    "dynamic-json-in-samples"?: boolean;
    "models-to-treat-empty-string-as-null"?: string[];
    "additional-intrinsic-types-to-treat-empty-string-as-null"?: string[];
}
