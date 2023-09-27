// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Experimental;

namespace OpenAI.Models
{
    /// <summary> The CreateImageVariationRequest. </summary>
    public partial class CreateImageVariationRequest
    {
        /// <summary> Initializes a new instance of CreateImageVariationRequest. </summary>
        /// <param name="image">
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="image"/> is null. </exception>
        public CreateImageVariationRequest(BinaryData image)
        {
            ClientUtilities.AssertNotNull(image, nameof(image));

            Image = image;
        }

        /// <summary> Initializes a new instance of CreateImageVariationRequest. </summary>
        /// <param name="image">
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// </param>
        /// <param name="n"> The number of images to generate. Must be between 1 and 10. </param>
        /// <param name="size"> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`. </param>
        /// <param name="responseFormat"> The format in which the generated images are returned. Must be one of `url` or `b64_json`. </param>
        /// <param name="user"></param>
        internal CreateImageVariationRequest(BinaryData image, long? n, ImageSizes? size, ImageResponseFormat? responseFormat, string user)
        {
            Image = image;
            N = n;
            Size = size;
            ResponseFormat = responseFormat;
            User = user;
        }

        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Image { get; }
        /// <summary> The number of images to generate. Must be between 1 and 10. </summary>
        public long? N { get; set; }
        /// <summary> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`. </summary>
        public ImageSizes? Size { get; set; }
        /// <summary> The format in which the generated images are returned. Must be one of `url` or `b64_json`. </summary>
        public ImageResponseFormat? ResponseFormat { get; set; }
        /// <summary> Gets or sets the user. </summary>
        public string User { get; set; }
    }
}
