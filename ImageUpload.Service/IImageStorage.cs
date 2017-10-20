// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImageStorage.cs" company="">
//   
// </copyright>
// <summary>
//   The mageStorage interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Service
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// The mageStorage interface.
    /// </summary>
    public interface IImageStorage
    {
        /// <summary>
        /// The upload file to storage.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <param name="fileName">
        /// The form file file name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> UploadFileToStorage(Stream stream, string fileName);

        /// <summary>
        /// The get thumbnails url.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<string>> GetThumbnailsUrls();
    }
}