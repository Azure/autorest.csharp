// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export enum Usage {
    None = "None",
    Input = "Input",
    Output = "Output",
    RoundTrip = "RoundTrip",
    Multipart = "Multipart"
}

export function append(usageString: string, usage: Usage): string {
    if (!usageString.includes(usage)) {
        if (usageString.trim().length === 0) {
            return usageString.concat(usage);
        } else {
            return usageString.concat("," + usage);
        }
    }
    return usageString;
}
