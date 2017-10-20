// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The image helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Helper
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The image helper.
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// The is image.
        /// </summary>
        /// <param name="formFile">
        /// The form file.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsImage(IFormFile formFile)
        {
            if (formFile.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => formFile.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}