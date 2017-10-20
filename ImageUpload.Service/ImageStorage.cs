// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageStorage.cs" company="">
//   
// </copyright>
// <summary>
//   The image storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// The image storage.
    /// </summary>
    public class ImageStorage : IImageStorage
    {
        /// <summary>
        /// The azure storage account.
        /// </summary>
        private readonly IAzureStorageAccount azureStorageAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageStorage"/> class.
        /// </summary>
        /// <param name="azureStorageAccount">
        /// The azure storage account.
        /// </param>
        public ImageStorage(IAzureStorageAccount azureStorageAccount)
        {
            this.azureStorageAccount = azureStorageAccount;
        }

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
        public async Task<bool> UploadFileToStorage(Stream stream, string fileName)
        {
            var imageContainer = this.azureStorageAccount.GetImageBlobContainer();

            var blockBlob = imageContainer.GetBlockBlobReference(fileName);

            if (await blockBlob.ExistsAsync())
            {
                fileName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
                blockBlob = imageContainer.GetBlockBlobReference(fileName);
            }

            await blockBlob.UploadFromStreamAsync(stream);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// The get thumbnails Url.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<string>> GetThumbnailsUrls()
        {
            var thumbnailContainer = this.azureStorageAccount.GetThumbnailContainer();

            BlobContinuationToken continuationToken = null;

            var thumbnailUrls = new List<string>();

            do
            {
                var resultSegment = await thumbnailContainer.ListBlobsSegmentedAsync(
                                                      string.Empty,
                                                      true,
                                                      BlobListingDetails.All,
                                                      10,
                                                      continuationToken,
                                                      null,
                                                      null);

                thumbnailUrls.AddRange(resultSegment.Results.Select(blobItem => blobItem.StorageUri.PrimaryUri.ToString()));
                
                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);

            return await Task.FromResult(thumbnailUrls);
        }
    }
}