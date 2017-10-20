// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAzureStorageAccount.cs" company="">
//   
// </copyright>
// <summary>
//   The AzureStorageAccount interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Service
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// The AzureStorageAccount interface.
    /// </summary>
    public interface IAzureStorageAccount
    {
        /// <summary>
        /// The get cloud storage account.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudStorageAccount"/>.
        /// </returns>
        CloudStorageAccount GetCloudStorageAccount();

        /// <summary>
        /// The get cloud blob client.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobClient"/>.
        /// </returns>
        CloudBlobClient GetCloudBlobClient();

        /// <summary>
        /// The get image blob container.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobContainer"/>.
        /// </returns>
        CloudBlobContainer GetImageBlobContainer();

        /// <summary>
        /// The get thumbnail container.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobContainer"/>.
        /// </returns>
        CloudBlobContainer GetThumbnailContainer();
    }
}