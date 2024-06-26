// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

export interface InputAuth {
    ApiKey?: InputApiKeyAuth;
    OAuth2?: InputOAuth2Auth;
}

export interface InputApiKeyAuth {
    Name: string;
    Prefix?: string;
}

export interface InputOAuth2Auth {
    Scopes?: string[];
}