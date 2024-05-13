// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface InputEnumTypeValue {
    Name: string;
    /* eslint-disable @typescript-eslint/no-explicit-any -- TODO: can we specify the range of value types? */
    Value: any;
    /* eslint-enable @typescript-eslint/no-explicit-any */
    Description?: string;
}
