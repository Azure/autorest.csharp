// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_string.Models.V100
{
    public readonly partial struct Colors
    {
        private const string RedColorValue = "red color";
        private const string GreenColorValue = "green-color";
        private const string BlueColorValue = "blue_color";

        public static Colors RedColor { get; } = new Colors(RedColorValue);
        public static Colors GreenColor { get; } = new Colors(GreenColorValue);
        public static Colors BlueColor { get; } = new Colors(BlueColorValue);
    }
}
