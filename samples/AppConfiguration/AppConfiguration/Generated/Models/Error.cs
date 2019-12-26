// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AppConfiguration.Models.V10
{
    public partial class Error
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public int? Status { get; set; }
    }
}
